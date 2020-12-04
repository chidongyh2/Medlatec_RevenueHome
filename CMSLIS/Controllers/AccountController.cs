using CaptchaMvc.HtmlHelpers;
using CMS_Core.Entity;
using CMS_Core.Implementtion;
using CMSLIS.Common;
using CMSLIS.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CMSLIS.Controllers
{

    public class AccountController : BaseController
    {
        ILog logIn = log4net.LogManager.GetLogger("CMSLISLogError");
        private ImpAccount_Login impAccount_Login;
        private ImpCms_Account impCms_Account  ;

        public AccountController()
        {
            impAccount_Login = new ImpAccount_Login();
            impCms_Account = new ImpCms_Account();
        }


        // GET: Account
        public ActionResult Index()
        {
            


            return View();
        }


        #region --> Login GET Method 

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            // We do not want to use any existing identity information           
            EnsureLoggedOut();



            string keyDecrypt = "MedCOm20190401";


            string ConnStr = CMS_Core.Common.AES.EncryptString(ConfigurationSettings.AppSettings["ConnStr1"], keyDecrypt);


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                int countNOKLogin = 0;

                if (!ModelState.IsValid)
                    return View(model);

                List<Account_Login> _Logins = new List<Account_Login>();
                _Logins = impAccount_Login.GetAccount_LoginNOKByUsername(model.Username);
                if (_Logins != null)
                {
                    countNOKLogin = _Logins.Count;
                }

                ViewBag.countNOKLogin = countNOKLogin;

                // kiểm tra số lần đăng nhập không thành công 
                if (countNOKLogin < 3)
                {
                    string salt = SaltedHash.GetSHA512(model.Username + model.Password);
                    salt = salt.Substring(0, 10);
                    model.Password = SaltedHash.GetSHA512(salt + model.Password);

                    List<cms_Account> accountInfo = impCms_Account.Getcms_Account(model.Username, model.Password);
                    if (accountInfo != null)
                    {
                        if (accountInfo.Count > 0)
                        {
                            //Login Success
                            //For Set Authentication in Cookie (Remeber ME Option)
                            SignInRemember(model.Username, model.RememberMe);
                            //Set A Unique ID in session
                            Session["UserInfo"] = accountInfo[0];
                            //Log account login
                            AddLogin(Common.Constant.StatusLoginOK, accountInfo[0].Username);
                            if (string.IsNullOrWhiteSpace(returnUrl))
                            {
                                return RedirectToLocal("/Home/index");
                            }
                            else if (returnUrl.Length < 5)
                            {
                                return RedirectToLocal("/Home/index");
                            }
                            else
                            {
                                return RedirectToLocal(returnUrl);
                            }
                        }
                        else
                        {
                            AddLogin(Common.Constant.StatusLoginNOK, model.Username);
                            ModelState.AddModelError("", "Đăng nhập không thành công.");
                            TempData["ErrorMSG"] = "Đăng nhập không thành công. Mời bạn đăng nhập lại";
                            return View(model);
                        }
                    }
                    else
                    {
                        AddLogin(Common.Constant.StatusLoginNOK, model.Username);
                        ModelState.AddModelError("", "Đăng nhập không thành công.");
                        TempData["ErrorMSG"] = "Đăng nhập không thành công. Mời bạn đăng nhập lại!";
                        return View(model);
                    }

                }
                else if (countNOKLogin < 5)
                {
                    if (!this.IsCaptchaValid("Validate your captcha"))
                    {
                        ModelState.AddModelError("", "Captcha nhập không đúng.");
                        return View(model);
                    }
                    else
                    {
                        string salt = SaltedHash.GetSHA512(model.Username + model.Password);
                        salt = salt.Substring(0, 10);
                        model.Password = SaltedHash.GetSHA512(salt + model.Password);

                        List<cms_Account> accountInfo = impCms_Account.Getcms_Account(model.Username, model.Password);
                        if (accountInfo != null)
                        {
                            if (accountInfo.Count > 0)
                            {
                                //Login Success
                                //For Set Authentication in Cookie (Remeber ME Option)
                                SignInRemember(model.Username, model.RememberMe);
                                //Set A Unique ID in session
                                Session["UserInfo"] = accountInfo[0];
                                //Log account login
                                AddLogin(Common.Constant.StatusLoginOK, accountInfo[0].Username);
                                if (string.IsNullOrWhiteSpace(returnUrl))
                                {
                                    return RedirectToLocal("/Home/index");
                                }
                                else if (returnUrl.Length < 5)
                                {
                                    return RedirectToLocal("/Home/index");
                                }
                                else
                                {
                                    return RedirectToLocal(returnUrl);
                                }
                            }
                            else
                            {
                                AddLogin(Common.Constant.StatusLoginNOK, model.Username);
                                ModelState.AddModelError("", "Đăng nhập không thành công.");
                                TempData["ErrorMSG"] = "Đăng nhập không thành công. Mời bạn đăng nhập lại";
                                return View(model);
                            }
                        }
                        else
                        {
                            AddLogin(Common.Constant.StatusLoginNOK, model.Username);
                            ModelState.AddModelError("", "Đăng nhập không thành công.");
                            TempData["ErrorMSG"] = "Đăng nhập không thành công. Mời bạn đăng nhập lại!";
                            return View(model);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Số lần đăng nhập sai quá 5 lần, Xin đợi 15 phút đăng nhập lại!");
                    TempData["ErrorMSG"] = "Số lần đăng nhập sai quá 5 lần, Xin đợi 15 phút đăng nhập lại!";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                AddLogin(Common.Constant.StatusLoginNOK, model.Username);
                logIn.Info("Login:" + ex.ToString());
                ModelState.AddModelError("", "Có lỗi trong quá trình đăng nhập.");
                throw;
            }
        }


        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel model, string returnUrl)
        //{
        //    try
        //    {
        //        int countNOKLogin = 0;

        //        if (!ModelState.IsValid)
        //            return View(model);

        //        List<Account_Login> _Logins = new List<Account_Login>();                
        //        _Logins = impAccount_Login.GetAccount_LoginNOKByUsername(model.Username);
        //        if (_Logins != null)
        //        {
        //            countNOKLogin = _Logins.Count;
        //        }

        //        ViewBag.countNOKLogin = countNOKLogin;

        //        // kiểm tra số lần đăng nhập không thành công 
        //        if (countNOKLogin < 3)
        //        {
                     
                  
        //            model.Password = Common.Common.Encrypt(model.Password);

        //            List<Sys_User> accountInfo = impCms_Account.Getcms_Account(model.Username, model.Password);
        //            if (accountInfo != null)
        //            {
        //                if (accountInfo.Count > 0)
        //                {
        //                    //Login Success
        //                    //For Set Authentication in Cookie (Remeber ME Option)
        //                    SignInRemember(model.Username, model.RememberMe);
        //                    //Set A Unique ID in session
        //                    Session["UserInfo"] = accountInfo[0];
        //                    //Log account login
        //                    AddLogin(Common.Constant.StatusLoginOK, accountInfo[0].UserID);
        //                    if (string.IsNullOrWhiteSpace(returnUrl))
        //                    {
        //                        return RedirectToLocal("/Home/index");
        //                    }
        //                    else if (returnUrl.Length < 5)
        //                    {
        //                        return RedirectToLocal("/Home/index");
        //                    }
        //                    else
        //                    {
        //                        return RedirectToLocal(returnUrl);
        //                    }
        //                }
        //                else
        //                {
        //                    AddLogin(Common.Constant.StatusLoginNOK, model.Username);
        //                    ModelState.AddModelError("", "Đăng nhập không thành công.");
        //                    TempData["ErrorMSG"] = "Đăng nhập không thành công. Mời bạn đăng nhập lại";
        //                    return View(model);
        //                }
        //            }
        //            else
        //            {
        //                AddLogin(Common.Constant.StatusLoginNOK, model.Username);
        //                ModelState.AddModelError("", "Đăng nhập không thành công.");
        //                TempData["ErrorMSG"] = "Đăng nhập không thành công. Mời bạn đăng nhập lại!";
        //                return View(model);
        //            }

        //        }
        //        else if (countNOKLogin < 5)
        //        {
        //            if (!this.IsCaptchaValid("Validate your captcha"))
        //            {
        //                ModelState.AddModelError("", "Captcha nhập không đúng.");
        //                return View(model);
        //            }
        //            else
        //            {
        //                model.Password = Common.Common.Encrypt(model.Password);

        //                List<Sys_User> accountInfo = impCms_Account.Getcms_Account(model.Username, model.Password);
                      
        //                if (accountInfo != null)
        //                {
        //                    if (accountInfo.Count > 0)
        //                    {
        //                        //Login Success
        //                        //For Set Authentication in Cookie (Remeber ME Option)
        //                        SignInRemember(model.Username, model.RememberMe);
        //                        //Set A Unique ID in session
        //                        Session["UserInfo"] = accountInfo[0];
        //                        //Log account login
        //                        AddLogin(Common.Constant.StatusLoginOK, accountInfo[0].UserID);
        //                        if (string.IsNullOrWhiteSpace(returnUrl))
        //                        {
        //                            return RedirectToLocal("/Home/index");
        //                        }
        //                        else if (returnUrl.Length < 5)
        //                        {
        //                            return RedirectToLocal("/Home/index");
        //                        }
        //                        else
        //                        {
        //                            return RedirectToLocal(returnUrl);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        AddLogin(Common.Constant.StatusLoginNOK, model.Username);
        //                        ModelState.AddModelError("", "Đăng nhập không thành công.");
        //                        TempData["ErrorMSG"] = "Đăng nhập không thành công. Mời bạn đăng nhập lại";
        //                        return View(model);
        //                    }
        //                }
        //                else
        //                {
        //                    AddLogin(Common.Constant.StatusLoginNOK, model.Username);
        //                    ModelState.AddModelError("", "Đăng nhập không thành công.");
        //                    TempData["ErrorMSG"] = "Đăng nhập không thành công. Mời bạn đăng nhập lại!";
        //                    return View(model);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Số lần đăng nhập sai quá 5 lần, Xin đợi 15 phút đăng nhập lại!");
        //            TempData["ErrorMSG"] = "Số lần đăng nhập sai quá 5 lần, Xin đợi 15 phút đăng nhập lại!";
        //            return View(model);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AddLogin(Common.Constant.StatusLoginNOK, model.Username);
        //        logIn.Info("Login:" + ex.ToString());
        //        ModelState.AddModelError("", "Có lỗi trong quá trình đăng nhập.");
        //        throw;
        //    }
        //}

        #endregion


        #region --> Pre Required Method For Login

        //GET: EnsureLoggedOut
        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }


        //POST: Logout
        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always
                //required NameSpace: using System.Web.Security;
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication
                //required NameSpace: using System.Security.Principal;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request


                return RedirectToAction("login", "Account");
            }
            catch (Exception ex)
            {
                logIn.Info("Logout:" + ex.ToString());
                return View();
            }

            // return View();
        }

        //GET: RedirectToLocal
        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site
                // so we will redirect to this "action"
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                    return Redirect(returnURL);

                // If we cannot verify if the url is local to our host we redirect to a default location
                return RedirectToAction("Index", "home");
            }
            catch (Exception ex)
            {
                logIn.Info("RedirectToLocal:" + ex.ToString());
                throw;
            }
        }

        //GET: SignInAsync   
        private void SignInRemember(string userName, bool isPersistent = false)
        {
            // Clear any lingering authencation data
            FormsAuthentication.SignOut();

            // Write the authentication cookie
            //  FormsAuthentication.SetAuthCookie(userName, isPersistent);

            DateTime utcNow = DateTime.UtcNow;

            DateTime utcExpires = isPersistent
                ? utcNow.AddDays(5)
                : utcNow.AddMinutes(20);

            var authTicket = new FormsAuthenticationTicket(
                2,
               userName,
                utcNow,
                utcExpires,
                isPersistent,
                string.Empty,
                "/"
            );

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
            cookie.HttpOnly = true;

            if (isPersistent)
            {
                cookie.Expires = authTicket.Expiration;
            }

            Response.Cookies.Add(cookie);


        }

        #endregion



        #region --> Profile Method 
        [HttpGet]
        public ActionResult ProfileUser(string returnUrl)
        {
            try
            {
                AddPageHeader("Profile", "");
                AddBreadcrumb("Hệ thống", "");
                AddBreadcrumb("Profile", "/Account/ProfileUser");

                ViewBag.ReturnUrl = returnUrl;
                if (Session["UserInfo"] == null)
                {
                    Logout();
                    return RedirectToAction("Login", "Account");
                }
                var UserInfo = ((cms_Account)Session["UserInfo"]);

                cms_Account _Account = new cms_Account();

                _Account = impCms_Account.Get(UserInfo.uid);
                return View(_Account);
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                return View();

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfileUser(cms_Account _Account)
        {
            AddPageHeader("Profile", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Profile", "/Account/ProfileUser");


            if (ModelState.IsValid)
            {
                var UserInfo = ((cms_Account)Session["UserInfo"]);
                ImpCms_Account impCms_Account = new ImpCms_Account();
                _Account.LastLogin = DateTime.Now;
                _Account.Password = string.Empty;


                bool validate = true;

                try
                {
                    if (!string.IsNullOrEmpty(_Account.NgaysinhText.Trim()))
                        _Account.Ngaysinh = DateTime.ParseExact(_Account.NgaysinhText.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));

                    if (_Account.Ngaysinh > DateTime.Now)
                    {
                        validate = false;
                        ViewBag.TitleSuccsess = "Ngày sinh lớn hơn ngày ngày hiện tại.";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }
                    if (_Account.Ngaysinh.Year < 1920)
                    {
                        validate = false;
                        ViewBag.TitleSuccsess = "Năm sinh nhỏ hơn năm 1920";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }

                }
                catch
                {
                    validate = false;
                }

                #region Check input data
                try
                {
                    if (validate)
                    {
                        _Account.Hoten = _Account.Hoten.Trim();
                        _Account.UpdateBy = UserInfo.uid;
                        _Account.Update_date = DateTime.Now;
                        _Account.IsFirstLogin = false;
                        _Account.LastLogin = DateTime.Now;

                        string result = impCms_Account.UpdateProfile(_Account);
                        if (!string.IsNullOrEmpty(result))
                        {
                            ViewBag.TitleSuccsess = "Cập nhật thông tin thành công";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                            AddLogAction(result, Constant.ActionUpdateOK.ToString());
                        }
                        else
                        {
                            ViewBag.TitleSuccsess = "Cập nhật thông tin không thành công";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            AddLogAction(result, Constant.ActionUpdateNOK.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {

                    ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    logIn.Info("ProfileUser: " + ex.ToString());
                    logIn.Info("ProfileUser: " + ex.ToString());
                }
                #endregion
            }

            return View(_Account);
        }


        #endregion

        #region --> ChangePassword  Method

        public ActionResult ChangePassword()
        {
            AddPageHeader("Đổi mật khẩu", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Đổi mật khẩu", "/Account/ChangePassword");
            return View();
        }

        //
        // POST: Account/ChangePassword
        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            AddPageHeader("Đổi mật khẩu", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Đổi mật khẩu", "/Account/ChangePassword");

            cms_Account _Account = new cms_Account();
            _Account = ((cms_Account)Session["UserInfo"]);


            try
            {


                if (ModelState.IsValid)
                {
                    if (model.OldPassword.Equals(model.Password))
                    {
                        ViewBag.TitleSuccsess = "Password new trùng với Password cũ, Mời bạn nhập lại";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }
                    else if (!model.Password.Equals(model.ConfirmPassword))
                    {
                        ViewBag.TitleSuccsess = "Nhập password new không trùng với confirm password, Mời bạn nhập lại";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }
                    else
                    {
                        string salt = SaltedHash.GetSHA512(_Account.Username + model.OldPassword);
                        salt = salt.Substring(0, 10);
                        model.OldPassword = SaltedHash.GetSHA512(salt + model.OldPassword);

                        List<cms_Account> accountInfo = impCms_Account.Getcms_Account(_Account.Username, model.OldPassword);


                        if (accountInfo != null)
                        {
                            if (accountInfo.Count > 0)
                            {
                                salt = SaltedHash.GetSHA512(_Account.Username + model.Password);
                                salt = salt.Substring(0, 10);
                                model.Password = SaltedHash.GetSHA512(salt + model.Password);

                                List<cms_Account> cms_Accounts = impCms_Account.ChangePasswordCms_Account(_Account.uid, model.Password);

                                if (!string.IsNullOrEmpty(cms_Accounts[0].Username))
                                {
                                    ViewBag.TitleSuccsess = Constant.ChangePasswordSuccess;
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                    AddLogAction(_Account.uid.ToString(), Constant.ActionChangePasswordOK.ToString());
                                }
                                else
                                {
                                    ViewBag.TitleSuccsess = Constant.ChangePasswordError;
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                    AddLogAction(_Account.uid.ToString(), Constant.ActionChangePasswordOK.ToString());
                                }
                            }
                            else
                            {
                                ViewBag.TitleSuccsess = Constant.NoFindAccount;
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                AddLogAction(_Account.uid.ToString(), Constant.ActionChangePasswordOK.ToString());
                            }
                        }
                        else
                        {
                            ViewBag.TitleSuccsess = Constant.Error;
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            AddLogAction(_Account.uid.ToString(), Constant.ActionChangePasswordOK.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddLogAction(_Account.uid.ToString(), Constant.ActionChangePasswordOK.ToString());
                ViewBag.TitleSuccsess = Constant.Error;
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logIn.Info("ChangePassword: " + ex.ToString());
            }
            return View();
        }
        #endregion


        #region --> forgot-password  Method

        public ActionResult ForgotPassword()
        {
            AddBreadcrumb("Reset Password", "/Account/ForgotPassword");
            AddBreadcrumb("Chi tiet", "/Home/About");
            return View();
        }


        #endregion



    }
}