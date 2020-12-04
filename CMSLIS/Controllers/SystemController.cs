using CMS_Core.Entity;
using CMS_Core.Implementtion;
using CMSLIS.Common;
using CMSLIS.Models;
using CMSNEW.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSLIS.Controllers
{
    [CheckAuthorization]
    public class SystemController : BaseController
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        private ImpCms_Account impCms_Account;
        private Impcms_AccountType impcms_AccountType;
        private Impcms_Menu impcms_Menu;
        private Impcms_Permission impcms_Permission;
        private ImpSys_GroupMenuPermissioncs impSys_GroupMenuPermissioncs;
        private ImpSys_GroupMenuControlPermission impSys_GroupMenuControlPermission;

        public SystemController()
        {
            impCms_Account = new ImpCms_Account();
            impcms_AccountType = new Impcms_AccountType();
            impcms_Menu = new Impcms_Menu();
            impcms_Permission = new Impcms_Permission();
            impSys_GroupMenuPermissioncs = new ImpSys_GroupMenuPermissioncs();
            impSys_GroupMenuControlPermission = new ImpSys_GroupMenuControlPermission();

        }

        // GET: System
        public ActionResult Index()
        {
            return View();
        }




        #region --> Danh sách user

        public ActionResult listAccount(string accounttypeid)
        {
            // Initialization.  
            AddPageHeader("Danh sách user", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách user", "/System/listAccount");
            var UserInfo = ((cms_Account)Session["UserInfo"]);

            if (string.IsNullOrEmpty(accounttypeid))
            {
                accounttypeid = "0";
            }
            SearchMenuViewModel obj = new SearchMenuViewModel();
            obj.accounttypeid = accounttypeid;
            obj.Status = Constant.TypeStatusPublic.ToString();
            obj.TypeKeyword = 0;
            obj.keyword = string.Empty;
            obj.parentID = UserInfo.AccountTypeId.ToString();
            try
            {

                this.ViewBag.GetTypeKeyword = Common.Common.GetTypeAccountKeyword();
                this.ViewBag.GetTypeStatus = Common.Common.GetTypeStatus();
                List<cms_Account> _Accounts = null;
                _Accounts = impCms_Account.GetAllcms_AccountByStatus(UserInfo.AccountTypeId, Convert.ToInt32(obj.accounttypeid), Constant.TypeStatusPublic, obj.TypeKeyword, obj.keyword);
                ViewBag.Accounts = _Accounts;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("listAccount:" + ex.ToString());
            }



            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult listAccount(SearchMenuViewModel obj, string submit)
        {
            // Initialization.  
            AddPageHeader("Danh sách user", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách user", "/System/listAccount");
            var UserInfo = ((cms_Account)Session["UserInfo"]);
            try
            {
                switch (submit)
                {
                    case "SearchlistAccount":
                        this.ViewBag.GetTypeKeyword = Common.Common.GetTypeAccountKeyword();
                        this.ViewBag.GetTypeStatus = Common.Common.GetTypeStatus();

                        List<cms_Account> _Accounts = impCms_Account.GetAllcms_AccountByStatus(UserInfo.AccountTypeId, Convert.ToInt32(obj.accounttypeid), Convert.ToInt32(obj.Status), obj.TypeKeyword, obj.keyword);
                        ViewBag.Accounts = _Accounts;

                        break;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("listAccount:" + ex.ToString());
            }

            obj.PartneridUser = UserInfo.PARTNERID.ToString();
            // Info.  
            return View(obj);
        }


        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult listAccountDelete(string[] customerIDs)
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách user", "/System/listAccountDelete");
            var UserInfo = ((cms_Account)Session["UserInfo"]);
            string listID = string.Empty;
            string listIDError = string.Empty;
            string result = string.Empty;
            try
            {
                // Kiểm tra xem có bản ghi nào được chọn không?
                if (customerIDs != null)
                {

                    // xóa dữ liệu
                    foreach (string customerID in customerIDs)
                    {
                        result = impCms_Account.Delete(Convert.ToInt32(customerID));
                        if (!string.IsNullOrEmpty(result))
                        {
                            if (result.Equals(CMS_Core.Common.Constant.typeORAForeign.ToString()))
                            {
                                listIDError += customerID + ",";
                            }
                            else
                            {
                                AddLogAction(customerID, Constant.ActionDeleteOK.ToString());
                                listID += customerID + ",";
                            }
                        }
                        else
                        {
                            AddLogAction(customerID, Constant.ActionDeleteOK.ToString());
                            listID += customerID + ",";
                        }
                    }
                    if (listID.IndexOf(",") != -1)
                    {
                        listID = listID.Substring(0, listID.Length - 1);
                    }
                    if (listIDError.IndexOf(",") != -1)
                    {
                        listIDError = listIDError.Substring(0, listIDError.Length - 1);
                    }
                }
                else
                {
                    return Json("Chưa có bản tin nào được chọn để xóa");
                }
            }
            catch (Exception ex)
            {
                logError.Info("listAccountDelete:" + ex.ToString());
                return Json("Có lỗi trong quá trình xóa bản ghi. Mời bạn thực hiện lại!");
            }

            if (listIDError.Length > 0)
            {
                return Json("Xóa thành công bản ghi có id là: " + listID + ", Các bản ghi lỗi: " + listIDError + " do bản ghi đã được chọn rồi!");
            }
            else
            {
                return Json("Xóa thành công bản ghi có id là: " + listID);
            }
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult listAccountPublic(string[] customerIDs)
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách user", "/System/listAccountPublic");
            var UserInfo = ((cms_Account)Session["UserInfo"]);
            string listID = string.Empty;
            try
            {
                // Kiểm tra xem có bản ghi nào được chọn không?
                if (customerIDs != null)
                {
                    // duyệt dữ liệu
                    foreach (string customerID in customerIDs)
                    {
                        impCms_Account.Publish(Convert.ToInt32(customerID));
                        AddLogAction(customerID, Constant.ActionPublicOK.ToString());
                        listID += customerID + ",";
                    }
                    if (listID.IndexOf(",") != -1)
                    {
                        listID = listID.Substring(0, listID.Length - 1);
                    }
                }
                else
                {
                    return Json("Chưa có bản tin nào được chọn để duyệt");
                }
            }
            catch (Exception ex)
            {
                logError.Info("danhmucvitri:" + ex.ToString());
            }

            return Json("Duyệt thành công bản ghi có id là: " + listID);
        }


        public ActionResult listAccountAdd(string accounttypeid, string uid)
        {
            // Initialization.             
            AddBreadcrumb("Hệ thống", "/System/listAccount");

            cms_Account account = new cms_Account();
            List<cms_Account> _Accounts = null;

            if (string.IsNullOrEmpty(accounttypeid))
            {
                accounttypeid = "0";
            }

            var UserInfo = ((cms_Account)Session["UserInfo"]);
            try
            {
                if (string.IsNullOrEmpty(uid))
                {
                    AddPageHeader("Thêm mới user", "");
                    AddBreadcrumb("Thêm mới user", "/System/listAccountAdd");
                    ViewBag.Title = "Thêm mới user";
                    account.Username = string.Empty;
                    account.Password = string.Empty;
                    account.AccountTypeId = Convert.ToInt32(accounttypeid.ToString());

                }
                else
                {
                    AddPageHeader("Cập nhật user", "");
                    AddBreadcrumb("Cập nhật user", "/System/listAccountAdd");
                    ViewBag.Title = "Cập nhật user";
                    _Accounts = impCms_Account.Getcms_AccountByUserUid(uid);
                    if (_Accounts != null)
                    {
                        if (_Accounts.Count > 0)
                        {
                            return View(_Accounts[0]);
                        }
                        else
                        {
                            ViewBag.TitleSuccsess = "Không tìm thấy thông tin user";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                        }
                    }
                    else
                    {
                        ViewBag.TitleSuccsess = "Không tìm thấy thông tin user";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("listAccountAdd:" + ex.ToString());
            }

            // Info.  
            return View(account);
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult listAccountAdd(cms_Account account)
        {
            // Initialization.    
            if (account.uid == 0)
            {
                AddPageHeader("Thêm mới user", "");
                AddBreadcrumb("Hệ thống", "/System/listAccount");
                AddBreadcrumb("Thêm mới user", "/System/listAccountAdd");
                ViewBag.Title = "Thêm mới user";

            }
            else
            {

                AddPageHeader("Cập nhật user", "");
                AddBreadcrumb("Hệ thống", "/System/listAccount");
                AddBreadcrumb("Cập nhật user", "/System/listAccountAdd");
                ViewBag.Title = "Cập nhật user";
            }



            var UserInfo = ((cms_Account)Session["UserInfo"]);

            if (ModelState.IsValid)
            {
                ImpCms_Account impCms_Account = new ImpCms_Account();
                string result = string.Empty;
                List<cms_Account> _Accounts = null;

                bool validate = true;

                try
                {
                    if (!string.IsNullOrEmpty(account.NgaysinhText))
                        account.Ngaysinh = DateTime.ParseExact(account.NgaysinhText.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));

                    if (account.Ngaysinh > DateTime.Now)
                    {
                        validate = false;
                        ViewBag.TitleSuccsess = "Ngày sinh lớn hơn ngày ngày hiện tại.";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }
                    if (account.Ngaysinh.Year < 1920)
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



                if (validate)
                {
                    if (account.uid == 0)
                    {


                        #region Check input data
                        try
                        {
                            if (string.IsNullOrWhiteSpace(account.Password))
                            {
                                ViewBag.TitleSuccsess = "Mời bạn nhập vào Password.";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                return View(account);

                            }
                            else if (account.Password.Length < 6)
                            {
                                ViewBag.TitleSuccsess = "Password nhỏ hơn 6 ký tự.";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                return View(account);
                            }
                            else
                            {

                                account.Username = account.Username;

                                string salt = SaltedHash.GetSHA512(account.Username + account.Password);
                                salt = salt.Substring(0, 10);
                                account.Password = SaltedHash.GetSHA512(salt + account.Password);


                                account.Hoten = account.Hoten.Trim();
                                account.CreateBy = UserInfo.uid;
                                account.Create_date = DateTime.Now;
                                account.IsFirstLogin = true;
                                account.LastLogin = DateTime.Now;

                                // check exit username
                                _Accounts = impCms_Account.Getcms_AccountByUserName(account.Username);

                                if (_Accounts != null)
                                {
                                    if (_Accounts.Count > 0)
                                    {
                                        ViewBag.TitleSuccsess = "Đã tồn tại Username! Mời bạn chọn Username khác.";
                                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                    }
                                    else
                                    {

                                        result = impCms_Account.Add(account);
                                    }
                                }
                                else
                                {
                                    result = impCms_Account.Add(account);
                                }

                                if (!string.IsNullOrEmpty(result))
                                {
                                    ViewBag.TitleSuccsess = "Thêm mới user thành công";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                                    Response.Redirect("/System/listAccount?accounttypeid=" + account.AccountTypeId, false);
                                    AddLogAction(result, Constant.ActionInsertOK.ToString());
                                }
                                else
                                {
                                    ViewBag.TitleSuccsess = "Thêm mới user không thành công";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                    AddLogAction(result, Constant.ActionInsertNOK.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            logError.Info(ex.ToString());
                            ViewBag.TitleSuccsess = "Dữ liệu ngày tháng không đúng định dạng";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                        }
                        #endregion


                    }
                    else
                    {


                        if (!string.IsNullOrEmpty(account.Password))
                        {
                            string salt = SaltedHash.GetSHA512(account.Username + account.Password);
                            salt = salt.Substring(0, 10);
                            account.Password = SaltedHash.GetSHA512(salt + account.Password);
                        }

                        #region Check input data
                        try
                        {
                            if (!string.IsNullOrEmpty(account.NgaysinhText.Trim()))
                                account.Ngaysinh = DateTime.ParseExact(account.NgaysinhText.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                            account.LastLogin = DateTime.Now;

                            account.Hoten = account.Hoten.Trim();

                            account.UpdateBy = UserInfo.uid;
                            account.Update_date = DateTime.Now;
                            account.IsFirstLogin = false;
                            account.LastLogin = DateTime.Now;

                            result = impCms_Account.Update(account);
                            if (!string.IsNullOrEmpty(result))
                            {
                                ViewBag.TitleSuccsess = "Cập nhật thông tin user thành công";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                                AddLogAction(result, Constant.ActionUpdateOK.ToString());
                                Response.Redirect("/System/listAccount?accounttypeid=" + account.AccountTypeId, false);
                            }
                            else
                            {
                                ViewBag.TitleSuccsess = "Cập nhật thông tin user không thành công";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                AddLogAction(result, Constant.ActionUpdateNOK.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            logError.Info(ex.ToString());
                            ViewBag.TitleSuccsess = "Dữ liệu ngày tháng không đúng định dạng";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                        }

                        #endregion
                    }
                }
                else
                {
                    ViewBag.TitleSuccsess = "Dữ liệu ngày tháng không đúng định dạng";
                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                }
            }

            return View(account);
        }


        #endregion



        #region --> Danh sách GroupAccount

        public ActionResult GroupAccount()
        {
            // Initialization.  
            AddPageHeader("Danh sách nhóm account", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách nhóm", "/System/GroupAccount");
            var UserInfo = ((cms_Account)Session["UserInfo"]);
            try
            {
                this.ViewBag.GetTypeStatus = Common.Common.GetTypeStatus();
                this.ViewBag.GetTypeKeyword = Common.Common.GetAccountTypeKeyword();


                List<cms_AccountType> _AccountTypes = impcms_AccountType.Getcms_AccountTypeByStatus(Common.Constant.TypeStatusPublic, 0, string.Empty);
                ViewBag.AccountTypes = _AccountTypes;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("GroupAccount:" + ex.ToString());
            }
            SearchMenuViewModel obj = new SearchMenuViewModel();
            obj.Status = Common.Constant.TypeStatusPublic.ToString();
            obj.TypeKeyword = 0;
            obj.keyword = string.Empty;


            // Info.  
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GroupAccount(SearchMenuViewModel obj, string submit)
        {
            // Initialization.  
            AddPageHeader("Danh sách nhóm account", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách nhóm", "/System/GroupAccount");
            var UserInfo = ((cms_Account)Session["UserInfo"]);
            this.ViewBag.GetTypeStatus = Common.Common.GetTypeStatus();
            this.ViewBag.GetTypeKeyword = Common.Common.GetAccountTypeKeyword();
            try
            {
                switch (submit)
                {
                    case "SearchGroupAccount":

                        List<cms_AccountType> _AccountTypes = impcms_AccountType.Getcms_AccountTypeByStatus(Convert.ToInt32(obj.Status), obj.TypeKeyword, obj.keyword);
                        ViewBag.AccountTypes = _AccountTypes;
                        break;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("GroupAccount:" + ex.ToString());
            }


            // Info.  
            return View(obj);
        }



        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult GroupAccountDelete(string[] customerIDs)
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách nhóm", "/System/GroupAccountDelete");
            var UserInfo = ((cms_Account)Session["UserInfo"]);
            string listID = string.Empty;
            string listIDError = string.Empty;
            string result = string.Empty;
            try
            {
                // Kiểm tra xem có bản ghi nào được chọn không?
                if (customerIDs != null)
                {
                    // xóa dữ liệu
                    foreach (string customerID in customerIDs)
                    {
                        result = impcms_AccountType.Delete(Convert.ToInt32(customerID));
                        if (!string.IsNullOrEmpty(result))
                        {
                            if (result.Equals(CMS_Core.Common.Constant.typeORAForeign.ToString()))
                            {
                                listIDError += customerID + ",";
                            }
                            else
                            {
                                AddLogAction(customerID, Constant.ActionDeleteOK.ToString());
                                listID += customerID + ",";
                            }
                        }
                        else
                        {
                            AddLogAction(customerID, Constant.ActionDeleteOK.ToString());
                            listID += customerID + ",";
                        }
                    }
                    if (listID.IndexOf(",") != -1)
                    {
                        listID = listID.Substring(0, listID.Length - 1);
                    }
                    if (listIDError.IndexOf(",") != -1)
                    {
                        listIDError = listIDError.Substring(0, listIDError.Length - 1);
                    }
                }
                else
                {
                    return Json("Chưa có bản tin nào được chọn để xóa");
                }
            }
            catch (Exception ex)
            {
                logError.Info("GroupAccountDelete:" + ex.ToString());
                return Json("Có lỗi trong quá trình xóa bản ghi. Mời bạn thực hiện lại!");
            }

            if (listIDError.Length > 0)
            {
                return Json("Xóa thành công bản ghi có id là: " + listID + ", Các bản ghi lỗi: " + listIDError + " do bản ghi đã được chọn rồi!");
            }
            else
            {
                return Json("Xóa thành công bản ghi có id là: " + listID);
            }
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult GroupAccountPublic(string[] customerIDs)
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách nhóm", "/System/GroupAccountPublic");
            var UserInfo = ((cms_Account)Session["UserInfo"]);
            string listID = string.Empty;
            try
            {
                // Kiểm tra xem có bản ghi nào được chọn không?
                if (customerIDs != null)
                {
                    // xóa dữ liệu
                    foreach (string customerID in customerIDs)
                    {
                        impcms_AccountType.Publish(Convert.ToInt32(customerID));
                        AddLogAction(customerID, Constant.ActionPublicOK.ToString());
                        listID += customerID + ",";
                    }
                    if (listID.IndexOf(",") != -1)
                    {
                        listID = listID.Substring(0, listID.Length - 1);
                    }
                }
                else
                {
                    return Json("Chưa có bản tin nào được chọn để duyệt");
                }
            }
            catch (Exception ex)
            {
                logError.Info("GroupAccountPublic:" + ex.ToString());
            }

            return Json("Duyệt thành công bản ghi có id là: " + listID);
        }

        public ActionResult GroupAccountAdd(string AccountTypeId)
        {
            // Initialization.    

            AddBreadcrumb("Hệ thống", "");


            cms_AccountType _AccountType = new cms_AccountType();
            List<cms_AccountType> _AccountTypes = null;

            try
            {
                var UserInfo = ((cms_Account)Session["UserInfo"]);

                if (string.IsNullOrEmpty(AccountTypeId))
                {
                    AddPageHeader("Thêm mới nhóm", "");
                    AddBreadcrumb("Thêm mới nhóm", "/System/GroupAccountAdd");
                    ViewBag.Title = "Thêm mới nhóm";


                }
                else
                {
                    AddPageHeader("Cập nhật nhóm", "");
                    AddBreadcrumb("Cập nhật nhóm", "/System/GroupAccountAdd");
                    ViewBag.Title = "Cập nhật nhóm";
                    _AccountTypes = impcms_AccountType.Getcms_AccountTypeByID(Convert.ToInt32(AccountTypeId));
                    if (_AccountTypes != null)
                    {
                        if (_AccountTypes.Count > 0)
                        {
                            return View(_AccountTypes[0]);
                        }
                        else
                        {
                            ViewBag.TitleSuccsess = "Không tìm thấy thông tin nhóm account";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                        }
                    }
                    else
                    {
                        ViewBag.TitleSuccsess = "Không tìm thấy thông tin nhóm account";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("GroupAccountAdd:" + ex.ToString());
            }

            // Info.  
            return View(_AccountType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GroupAccountAdd(cms_AccountType _AccountType)
        {
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            if (_AccountType.AccountTypeId == 0)
            {
                AddPageHeader("Thêm mới nhóm", "");
                AddBreadcrumb("Thêm mới nhóm", "/System/GroupAccountAdd");
                ViewBag.Title = "Thêm mới nhóm";
            }
            else
            {
                AddPageHeader("Cập nhật nhóm", "");
                AddBreadcrumb("Cập nhật nhóm", "/System/GroupAccountAdd");
                ViewBag.Title = "Cập nhật nhóm";
            }

            try
            {

                if (ModelState.IsValid)
                {
                    List<cms_AccountType> _AccountTypes = null;

                    var UserInfo = ((cms_Account)Session["UserInfo"]);
                    string result = string.Empty;


                    if (_AccountType.AccountTypeId == 0)
                    {
                        _AccountType.CreateBy = UserInfo.uid;
                        _AccountType.CreateDate = DateTime.Now;
                        // check exit Group User
                        _AccountTypes = impcms_AccountType.Getcms_AccountTypeByName(_AccountType.AName);
                        if (_AccountTypes != null)
                        {
                            if (_AccountTypes.Count > 0)
                            {
                                ViewBag.TitleSuccsess = "Đã tồn tại Group User! Mời bạn chọn Group User khác.";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            }
                            else
                            {
                                result = impcms_AccountType.Add(_AccountType);
                                if (!string.IsNullOrEmpty(result))
                                {
                                    ViewBag.TitleSuccsess = "Thêm mới Group User thành công";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                                    Response.Redirect("/System/GroupAccount", false);
                                    AddLogAction(result, Constant.ActionInsertOK.ToString());
                                }
                                else
                                {
                                    ViewBag.TitleSuccsess = "Thêm mới Group User không thành công";
                                    ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                    AddLogAction(result, Constant.ActionInsertNOK.ToString());
                                }
                            }
                        }
                        else
                        {
                            result = impcms_AccountType.Add(_AccountType);
                            if (!string.IsNullOrEmpty(result))
                            {
                                ViewBag.TitleSuccsess = "Thêm mới Group User thành công";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                                Response.Redirect("/System/GroupAccount", false);
                                AddLogAction(result, Constant.ActionInsertOK.ToString());
                            }
                            else
                            {
                                ViewBag.TitleSuccsess = "Thêm mới Group User không thành công";
                                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                                AddLogAction(result, Constant.ActionInsertNOK.ToString());
                            }
                        }


                    }
                    else
                    {

                        _AccountType.UpdateBy = UserInfo.uid;
                        _AccountType.UpdateDate = DateTime.Now;
                        result = impcms_AccountType.Update(_AccountType);
                        if (!string.IsNullOrEmpty(result))
                        {
                            ViewBag.TitleSuccsess = "Cập nhật thông tin user thành công";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                            Response.Redirect("/System/GroupAccount", false);
                            AddLogAction(result, Constant.ActionUpdateOK.ToString());
                        }
                        else
                        {
                            ViewBag.TitleSuccsess = "Cập nhật thông tin user không thành công";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                            AddLogAction(result, Constant.ActionUpdateNOK.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("GroupAccountAdd:" + ex.ToString());
            }

            return View(_AccountType);
        }


        public ActionResult GroupAccountMenuPermission(string AccountTypeId)
        {
            // Initialization.    
            AddPageHeader("Phân quyền truy cập menu", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách nhóm", "/System/GroupAccountMenuPermission");


            List<cms_Menu> _Menus = null;
            List<cms_Menu> _MenusValue = new List<cms_Menu>();

            var UserInfo = ((cms_Account)Session["UserInfo"]);

            try
            {
                if (!string.IsNullOrEmpty(AccountTypeId))
                {
                    _Menus = impcms_Menu.GetAllcms_MenuParentByGroupID(Convert.ToInt32(AccountTypeId), UserInfo.AccountTypeId);

                    if (_Menus != null)
                    {
                        foreach (var data in _Menus)
                        {
                            _MenusValue.Add(data);
                            List<cms_Menu> DataChilds = impcms_Menu.GetAllcms_MenuChildAndGroupID(data.menId, Convert.ToInt32(AccountTypeId), UserInfo.AccountTypeId);
                            foreach (var DataChild in DataChilds)
                            {
                                _MenusValue.Add(DataChild);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("GroupAccountMenuPermission:" + ex.ToString());
            }

            GroupAccountMenuPermissionViewModel groupAccountMenuPermissionViewModel = new GroupAccountMenuPermissionViewModel();
            groupAccountMenuPermissionViewModel._Menus = _MenusValue;
            groupAccountMenuPermissionViewModel.parentID = "0";
            groupAccountMenuPermissionViewModel.GroupID = AccountTypeId;
            // Info.  
            return View(groupAccountMenuPermissionViewModel);

        }


        [HttpPost]
        public ActionResult GroupAccountMenuPermission(GroupAccountMenuPermissionViewModel obj, string submit)
        {
            // Initialization.  
            AddPageHeader("Phân quyền truy cập menu", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách nhóm", "/System/GroupAccountMenuPermission");
            var UserInfo = ((cms_Account)Session["UserInfo"]);
            List<cms_Menu> _Menus = null;

            try
            {
                switch (submit)
                {
                    case "SearchMenu":
                        ModelState.Clear();
                        _Menus = impcms_Menu.GetAllcms_MenuChildAndGroupID(Convert.ToInt32(obj.parentID), Convert.ToInt32(obj.GroupID), UserInfo.AccountTypeId);
                        obj._Menus = null;
                        obj._Menus = _Menus;

                        GroupAccountMenuPermissionViewModel groupAccountMenuPermissionViewModel = new GroupAccountMenuPermissionViewModel();
                        groupAccountMenuPermissionViewModel._Menus = _Menus;
                        groupAccountMenuPermissionViewModel.parentID = obj.parentID;
                        groupAccountMenuPermissionViewModel.GroupID = obj.GroupID;


                        return View(groupAccountMenuPermissionViewModel);
                    // break;

                    case "SaveMenu":

                        string listMenuID = string.Empty;
                        string listMenuIDDelete = string.Empty;

                        foreach (var data in obj._Menus)
                        {
                            if (data.view)
                            {
                                listMenuID = listMenuID + data.menId.ToString() + ",";
                            }
                            else
                            {
                                listMenuIDDelete = listMenuIDDelete + data.menId.ToString() + ",";
                            }

                        }

                        if (listMenuIDDelete.Length > 1)
                        {
                            listMenuIDDelete = listMenuIDDelete.Substring(0, listMenuIDDelete.Length - 1);
                            impSys_GroupMenuPermissioncs.DeleteListSys_GroupMenuPermission(Convert.ToInt32(obj.GroupID), listMenuIDDelete);
                        }

                        if (listMenuID.Length > 1)
                        {
                            listMenuID = listMenuID.Substring(0, listMenuID.Length - 1);
                            impSys_GroupMenuPermissioncs.InsertListSys_GroupMenuPermission(Convert.ToInt32(obj.GroupID), listMenuID, 1);
                        }

                        ViewBag.TitleSuccsess = "Cập nhật thành công";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;

                        break;

                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Cập nhật thành công";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("Menu:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }


        public ActionResult GroupAccountPermissionControl(string GroupID)
        {
            // Initialization.  
            AddPageHeader("Phân quyền control", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách nhóm", "/System/GroupAccountPermissionControl");


            PermissionControlViewModel obj = new PermissionControlViewModel();
            obj.GroupID = GroupID;
            obj.MenParent = "0";
            obj.MenChild = "0";
            // Info.  
            return View(obj);
        }

        [HttpPost]
        public ActionResult GroupAccountPermissionControl(PermissionControlViewModel obj, string submit)
        {
            // Initialization.  
            AddPageHeader("Phân quyền control", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách nhóm", "/System/GroupAccountPermissionControl");

            var UserInfo = ((cms_Account)Session["UserInfo"]);
            List<Sys_GroupMenuControlPermission> _GroupMenuControlPermissions = null;


            try
            {
                switch (submit)
                {
                    case "SearchGroupAccountPermissionControl":
                        _GroupMenuControlPermissions = impSys_GroupMenuControlPermission.GetSys_GroupMenuControlPermissionByGroupID(Convert.ToInt32(obj.GroupID), Convert.ToInt32(obj.MenChild), UserInfo.AccountTypeId);
                        obj._GroupMenuControlPermissions = _GroupMenuControlPermissions;
                        break;
                    case "SaveGroupAccountPermissionControl":

                        foreach (var data in obj._GroupMenuControlPermissions)
                        {
                            if (data.CheckPermision)
                            {
                                data.Permision = 1;

                                var errorsSave = data.Validate(new ValidationContext(data));
                                if (errorsSave.ToList().Count == 0)
                                {
                                    impSys_GroupMenuControlPermission.InsertSys_GroupMenuControlPermission(data);
                                }
                            }
                            else
                            {
                                data.Permision = 0;

                                var errorsSave = data.Validate(new ValidationContext(data));
                                if (errorsSave.ToList().Count == 0)
                                {
                                    impSys_GroupMenuControlPermission.InsertSys_GroupMenuControlPermission(data);
                                }

                            }
                        }
                        _GroupMenuControlPermissions = impSys_GroupMenuControlPermission.GetSys_GroupMenuControlPermissionByGroupID(Convert.ToInt32(obj.GroupID), Convert.ToInt32(obj.MenChild), UserInfo.AccountTypeId);
                        obj._GroupMenuControlPermissions = _GroupMenuControlPermissions;
                        ViewBag.TitleSuccsess = "Cập nhật thành công";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                        break;

                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("GroupAccountPermissionControl: " + ex.ToString());
            }

            // Info.  
            return View(obj);
        }



        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult GroupAccountPermissionControlByParrentMenu(string ParrentID)
        {
            try
            {
                var UserInfo = ((cms_Account)Session["UserInfo"]);

                IEnumerable<cms_Menu> modelList = new List<cms_Menu>();

                //  modelList = impcms_Menu.GetAllcms_MenuChildByUserid(  UserInfo.uid);
                return Json(modelList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logError.Info("PermissionControlByParrentMenu:" + ParrentID + "  " + ex.ToString());
                return Json(string.Empty);
            }
        }


        #endregion


        //#region --> Danh sách phân quyền control

        //public ActionResult PermissionControl(string GroupID)
        //{
        //    // Initialization.  
        //    AddBreadcrumb("Hệ thống", "/System/listAccount");
        //    AddBreadcrumb("Phân quyền control", "/System/PermissionControl");
        //    this.ViewBag.Getcms_MenuParrent = Common.Common.Getcms_MenuParrent();
        //    this.ViewBag.Getcms_MenuChild = Common.Common.Getcms_MenuChild(Common.Constant.TypeStatusAll);

        //    PermissionControlViewModel obj = new PermissionControlViewModel();
        //    obj.GroupID = GroupID;
        //    obj.MenParent = "0";
        //    obj.MenChild = "0";
        //    // Info.  
        //    return View(obj);
        //}

        //[HttpPost]
        //public ActionResult PermissionControl(PermissionControlViewModel obj, string submit)
        //{
        //    // Initialization.  
        //    AddBreadcrumb("Hệ thống", "/System/listAccount");
        //    AddBreadcrumb("Phân quyền control", "/System/PermissionControl");
        //    this.ViewBag.Getcms_MenuParrent = Common.Common.Getcms_MenuParrent();
        //    this.ViewBag.Getcms_MenuChild = Common.Common.Getcms_MenuChild(Convert.ToInt32(obj.MenParent));

        //    List<Sys_GroupMenuControlPermission> _GroupMenuControlPermissions = null;
        //    ImpSys_GroupMenuControlPermission impSys_GroupMenuControlPermission = new ImpSys_GroupMenuControlPermission();

        //    try
        //    {
        //        switch (submit)
        //        {
        //            case "SearchPermissionControl":
        //                _GroupMenuControlPermissions = impSys_GroupMenuControlPermission.GetSys_GroupMenuControlPermissionByGroupID(Convert.ToInt32(obj.GroupID), Convert.ToInt32(obj.MenChild));
        //                obj._GroupMenuControlPermissions = _GroupMenuControlPermissions;
        //                break;
        //            case "SavePermissionControl":

        //                foreach (var data in obj._GroupMenuControlPermissions)
        //                {
        //                    //if (data.Permision)
        //                    //{
        //                    impSys_GroupMenuControlPermission.InsertSys_GroupMenuControlPermission(data);
        //                    //}
        //                    //else
        //                    //{
        //                    //    impSys_GroupMenuControlPermission.DeleteSys_GroupMenuControlPermission(data);
        //                    //}
        //                }
        //                _GroupMenuControlPermissions = impSys_GroupMenuControlPermission.GetSys_GroupMenuControlPermissionByGroupID(Convert.ToInt32(obj.GroupID), Convert.ToInt32(obj.MenChild));
        //                obj._GroupMenuControlPermissions = _GroupMenuControlPermissions;
        //                ViewBag.TitleSuccsess = "Cập nhật thành công";
        //                break;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logError.Info("PermissionControl: " + ex.ToString());
        //    }

        //    // Info.  
        //    return View(obj);
        //}



        //[HttpPost]
        //public JsonResult PermissionControlByParrentMenu(string ParrentID)
        //{
        //    try
        //    {
        //        var UserInfo = ((cms_Account)Session["UserInfo"]);

        //        IEnumerable<cms_Menu> modelList = new List<cms_Menu>();
        //        Impcms_Menu impcms_Menu = new Impcms_Menu();                
        //        modelList = impcms_Menu.GetAllcms_MenuChildByUserid(Convert.ToInt32(ParrentID), UserInfo.accountid);
        //        return Json(modelList, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        logError.Info("PermissionControlByParrentMenu:" + ParrentID + "  " + ex.ToString());
        //        return Json(string.Empty);
        //    }
        //}


        //#endregion


        #region --> Danh sách control trên url

        public ActionResult ListControl()
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách control", "/System/ListControl");


            List<cms_Menu> _MenusValue = new List<cms_Menu>();
            Impcms_Menu impcms_Menu = new Impcms_Menu();

            ListControlViewModel obj = new ListControlViewModel();
            obj.MenParent = "0";
            obj.MenChild = "0";
            obj._ControlName = new cms_ControlName();
            obj._ControlName.ControlStatus = 2;
            obj._ControlName.LangID = 1;
            // Info.  
            return View(obj);
        }

        [HttpPost]
        public ActionResult ListControl(ListControlViewModel obj, string submit)
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách control", "/System/ListControl");


            Impcms_ControlName impcms_ControlName = new Impcms_ControlName();
            List<cms_ControlName> _ControlNames = null;
            try
            {
                switch (submit)
                {
                    case "SearchListControl":
                        _ControlNames = impcms_ControlName.GetAllcms_ControlNameByUrl(Common.Constant.TypeStatusAll, Convert.ToInt32(obj.MenChild));
                        obj._Menus = _ControlNames;
                        break;
                    case "SaveListControl":

                        var errors = obj._ControlName.Validate(new ValidationContext(obj._ControlName));



                        if (errors.ToList().Count == 0)
                        {
                            if (obj.MenChild != "0")
                            {
                                obj._ControlName.menID = Convert.ToInt32(obj.MenChild);
                                impcms_ControlName.Insertcms_ControlName(obj._ControlName);
                                ViewBag.TitleSuccsess = "Cập nhật thành công";
                            }
                            else
                            {
                                ViewBag.TitleSuccsess = "Bạn chưa chọn menu";
                            }
                        }
                        else
                        {
                            ViewBag.TitleSuccsess = errors.ToList()[0].ErrorMessage;
                        }

                        _ControlNames = impcms_ControlName.GetAllcms_ControlNameByUrl(Common.Constant.TypeStatusAll, Convert.ToInt32(obj.MenChild));
                        obj._Menus = _ControlNames;

                        break;

                }
            }
            catch (Exception ex)
            {
                logError.Info("Menu:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        public JsonResult ListControlUpdate(cms_ControlName ControlNameValue)
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách control", "/System/ListControl");
            Impcms_ControlName impcms_ControlName = new Impcms_ControlName();
            if (!string.IsNullOrEmpty(ControlNameValue.ControlID) && string.IsNullOrEmpty(ControlNameValue.ControlName))
            {
                impcms_ControlName.Updatecms_ControlName(ControlNameValue);
            }
            // Info.  
            return Json(string.Empty);
        }


        [HttpPost]
        public JsonResult ListControlInsert(cms_ControlName ControlNameValue)
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách control", "/System/ListControl");
            Impcms_ControlName impcms_ControlName = new Impcms_ControlName();
            // string url = Request.RawUrl.ToLower();
            //ControlNameValue.menName = url;
            if (!string.IsNullOrEmpty(ControlNameValue.menName))
            {
                ControlNameValue.menName = ControlNameValue.menName.Substring(1);
                if (!string.IsNullOrEmpty(ControlNameValue.ControlID) && !string.IsNullOrEmpty(ControlNameValue.ControlName))
                {
                    impcms_ControlName.Insertcms_ControlNameByMenName(ControlNameValue);
                }
            }

            // Info.  
            return Json(string.Empty);
        }


        #endregion

        #region --> Danh sách Menu

        public ActionResult Menu(string parentID)
        {
            // Initialization. 
            AddPageHeader("Danh sách menu", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách menu", "/System/Menu");
            var UserInfo = ((cms_Account)Session["UserInfo"]);

            if (string.IsNullOrEmpty(parentID))
            {
                parentID = "0";
            }

            SearchMenuViewModel obj = new SearchMenuViewModel();
            obj.Status = Constant.TypeStatusPublic.ToString();
            obj.parentID = parentID.ToString();
            obj.TypeKeyword = 0;
            obj.keyword = string.Empty;

            this.ViewBag.GetTypeStatus = Common.Common.GetTypeStatus();
            this.ViewBag.GetTypeKeyword = Common.Common.GetTypeMenuKeyword();

            try
            {

                List<cms_Menu> _Menus = impcms_Menu.GetAllcms_MenuByGroupID(UserInfo.AccountTypeId, Convert.ToInt32(obj.parentID), Constant.TypeStatusPublic, obj.TypeKeyword, obj.keyword);
                ViewBag.DataReport = _Menus;
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("Menu:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Menu(SearchMenuViewModel obj, string submit)
        {
            // Initialization.  
            AddPageHeader("Danh sách menu", "");
            AddBreadcrumb("Hệ thống", "");
            AddBreadcrumb("Danh sách menu", "/System/Menu");


            this.ViewBag.GetTypeStatus = Common.Common.GetTypeStatus();
            this.ViewBag.GetTypeKeyword = Common.Common.GetTypeMenuKeyword();

            try
            {
                var UserInfo = ((cms_Account)Session["UserInfo"]);

                switch (submit)
                {
                    case "SearchMenu":
                        List<cms_Menu> _Menus = impcms_Menu.GetAllcms_MenuByGroupID(UserInfo.AccountTypeId, Convert.ToInt32(obj.parentID), Convert.ToInt32(obj.Status), obj.TypeKeyword, obj.keyword);
                        //List<cms_Menu> _Menus = impcms_Menu.GetAllcms_MenuChildByUserid(Convert.ToInt32(obj.parentID), Convert.ToInt32(obj.Status), UserInfo.uid);
                        ViewBag.DataReport = _Menus;
                        break;
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("Menu:" + ex.ToString());
            }

            // Info.  
            return View(obj);
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult MenuDelete(string[] customerIDs)
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách menu", "/System/Menu");
            string listID = string.Empty;
            string listIDError = string.Empty;
            string result = string.Empty;
            var UserInfo = ((cms_Account)Session["UserInfo"]);

            try
            {
                // Kiểm tra xem có bản ghi nào được chọn không?
                if (customerIDs != null)
                {


                    // xóa dữ liệu
                    foreach (string customerID in customerIDs)
                    {
                        result = impcms_Menu.Delete(UserInfo.uid, Convert.ToInt32(customerID));
                        if (!string.IsNullOrEmpty(result))
                        {
                            if (result.Equals(CMS_Core.Common.Constant.typeORAForeign.ToString()))
                            {
                                listIDError += customerID + ",";
                            }
                            else
                            {
                                AddLogAction(customerID, Constant.ActionDeleteOK.ToString());
                                listID += customerID + ",";
                            }
                        }
                        else
                        {
                            AddLogAction(customerID, Constant.ActionDeleteOK.ToString());
                            listID += customerID + ",";
                        }
                    }
                    if (listID.IndexOf(",") != -1)
                    {
                        listID = listID.Substring(0, listID.Length - 1);
                    }
                    if (listIDError.IndexOf(",") != -1)
                    {
                        listIDError = listIDError.Substring(0, listIDError.Length - 1);
                    }
                }
                else
                {
                    return Json("Chưa có bản tin nào được chọn để xóa");
                }
            }
            catch (Exception ex)
            {
                logError.Info("MenuPublic: " + ex.ToString());
                return Json("Có lỗi trong quá trình xóa bản ghi. Mời bạn thực hiện lại!");
            }

            if (listIDError.Length > 0)
            {
                return Json("Xóa thành công bản ghi có id là: " + listID + ", Các bản ghi lỗi: " + listIDError + " do bản ghi đã được chọn rồi!");
            }
            else
            {
                return Json("Xóa thành công bản ghi có id là: " + listID);
            }

            // Info.  
            //return View();
        }


        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult MenuPublic(string[] customerIDs)
        {
            // Initialization.  
            AddBreadcrumb("Hệ thống", "/System/listAccount");
            AddBreadcrumb("Danh sách menu", "/System/Menu");
            string listID = string.Empty;
            try
            {
                // Kiểm tra xem có bản ghi nào được chọn không?
                if (customerIDs != null)
                {
                    var UserInfo = ((cms_Account)Session["UserInfo"]);

                    // duyệt dữ liệu
                    foreach (string customerID in customerIDs)
                    {
                        impcms_Menu.Publish(UserInfo.AccountTypeId, Convert.ToInt32(customerID));
                        AddLogAction(customerID, Constant.ActionPublicOK.ToString());
                        listID += customerID + ",";
                    }
                    if (listID.IndexOf(",") != -1)
                    {
                        listID = listID.Substring(0, listID.Length - 1);
                    }
                }
                else
                {
                    return Json("Chưa có bản tin nào được chọn để duyệt");
                }
            }
            catch (Exception ex)
            {
                logError.Info("MenuPublic: " + ex.ToString());
            }

            return Json("Duyệt thành công bản ghi có id là: " + listID);

            // Info.  
            //return View();
        }


        public ActionResult MenuAdd(string parentID, string menId)
        {
            // Initialization.   

            AddBreadcrumb("Hệ thống", "");

            cms_Menu _Menu = new cms_Menu();
            List<cms_Menu> _Menus = null;

            var UserInfo = ((cms_Account)Session["UserInfo"]);
            this.ViewBag.Getcms_MenuParrent = Common.Common.Getcms_MenuParrent();

            if (string.IsNullOrEmpty(parentID))
            {
                parentID = "0";
            }

            try
            {
                if (string.IsNullOrEmpty(menId))
                {
                    AddPageHeader("Thêm mới menu", "");
                    AddBreadcrumb("Thêm mới menu", "/System/MenuAdd");
                    ViewBag.Title = "Thêm mới menu";

                    _Menu.MENDISPLAY = 1;
                    _Menu.cateId = Convert.ToInt32(parentID);

                }
                else
                {
                    AddPageHeader("Cập nhật menu", "");
                    AddBreadcrumb("Cập nhật menu", "/System/MenuAdd");
                    ViewBag.Title = "Cập nhật menu";
                    _Menus = impcms_Menu.Getcms_MenuByID(Convert.ToInt32(menId));
                    if (_Menus != null)
                    {
                        if (_Menus.Count > 0)
                        {
                            //  _Menus[0].cateId = Convert.ToInt32(parentID);
                            return View(_Menus[0]);
                        }
                        else
                        {
                            ViewBag.TitleSuccsess = "Không tìm thấy thông tin menu";
                            ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                        }
                    }
                    else
                    {
                        ViewBag.TitleSuccsess = "Không tìm thấy thông tin menu";
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("MenuAdd:" + ex.ToString());
            }

            // Info.  
            return View(_Menu);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        public ActionResult MenuAdd(cms_Menu _Menu)
        {
            // Initialization.             
            AddBreadcrumb("Hệ thống", "");
            if (_Menu.menId == 0)
            {
                AddPageHeader("Thêm mới menu", "");
                AddBreadcrumb("Thêm mới menu", "/System/MenuAdd");

            }
            else
            {
                AddPageHeader("Cập nhật menu", "");
                AddBreadcrumb("Cập nhật menu", "/System/MenuAdd");
            }
            this.ViewBag.Getcms_MenuParrent = Common.Common.Getcms_MenuParrent();

            if (ModelState.IsValid)
            {
                var UserInfo = ((cms_Account)Session["UserInfo"]);

                _Menu.CreateBy = UserInfo.uid;
                _Menu.Create_date = DateTime.Now;
                _Menu.UpdateBy = UserInfo.uid;
                _Menu.Update_date = DateTime.Now;
                if (_Menu.view)
                    _Menu.MENDISPLAY = 1;
                else
                    _Menu.MENDISPLAY = 0;

                string result = string.Empty;
                if (_Menu.menId == 0)
                {
                    _Menu.MENStatus = 1;
                    result = impcms_Menu.Add(_Menu);
                    if (!string.IsNullOrEmpty(result))
                    {
                        ViewBag.TitleSuccsess = "Thêm mới Menu thành công";
                        AddLogAction(result, Constant.ActionInsertOK.ToString());
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                        Response.Redirect("/System/Menu?parentID=" + _Menu.cateId, false);
                    }
                    else
                    {
                        ViewBag.TitleSuccsess = "Thêm mới Menu không thành công";
                        AddLogAction(result, Constant.ActionInsertNOK.ToString());
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }
                }
                else
                {

                    result = impcms_Menu.Update(_Menu);
                    if (!string.IsNullOrEmpty(result))
                    {
                        ViewBag.TitleSuccsess = "Cập nhật thông tin menu thành công";
                        AddLogAction(result, Constant.ActionUpdateOK.ToString());
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeSuccsess;
                        Response.Redirect("/System/Menu?parentID=" + _Menu.cateId, false);
                    }
                    else
                    {
                        ViewBag.TitleSuccsess = "Cập nhật thông tin menu không thành công";
                        AddLogAction(result, Constant.ActionUpdateNOK.ToString());
                        ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                    }
                }
            }

            return View(_Menu);
        }

        #endregion







    }

}