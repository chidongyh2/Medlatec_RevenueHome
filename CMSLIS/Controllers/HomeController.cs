using CMS_Core.Entity;
using CMS_Core.Implementtion;
using CMS_Medicons.Common;
using CMSLIS.Models;
using CMSNEW.Models;
using DotNetOpenAuth.OAuth2;
using log4net;
 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Web;
using System.Web.Mvc;

namespace CMSLIS.Controllers
{
    [CheckAuthorization]
    public class HomeController : BaseController
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        private WebServerClient _webServerClient;
        public ActionResult Index()
        {
            try
            {

                // Initialization.       
                AddPageHeader("Hệ thống CMS MEDCOM", "");
                AddBreadcrumb("Hệ thống CMS MEDCOM", "/Home/index");


            }
            catch (Exception ex)
            {
                ViewBag.TitleSuccsess = "Có lỗi xẩy ra trong quá trình thực hiện, Mời bạn thực hiện lại!";
                ViewBag.TypeAlert = CMSLIS.Common.Constant.typeError;
                logError.Info("Index:" + ex.ToString());
            }
            // Info.  
            return View();

        }
        [AjaxValidateAntiForgeryToken]
      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        //[HttpGet]
        //public ActionResult ResourceOwner(string mesg)
        //{
        //    ViewBag.AccessToken = Session["access_token"];
        //    ViewBag.RefreshToken = Session["refresh_token"];
        //    ViewBag.Message = mesg;
        //    return View("ResourceOwner");
        //}

        ///// <summary>
        ///// Resource owner password grant flow
        ///// </summary>
        ///// <param name="Email"></param>
        ///// <param name="Password"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult Login(string Email, string Password)
        //{
        //    if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        //    {
        //        return RedirectToAction("ResourceOwner", new { mesg = "Both Email and Password are required" });
        //    }

        //    // Exchange email and password for access_token
        //    _initializeWebServerClient();
        //    try
        //    {
        //        var userAuthorization = _webServerClient.ExchangeUserCredentialForToken(Email, Password, scopes: new[] { "public_profile", "sign_request" });
        //        if (userAuthorization != null)
        //        {
        //            var x = userAuthorization.AccessTokenExpirationUtc;
        //            var y = TimeZoneInfo.ConvertTimeFromUtc(x.Value, TimeZoneInfo.Local);
        //            Session.Add("access_token", userAuthorization.AccessToken);
        //            Session.Add("refresh_token", userAuthorization.RefreshToken);
        //            return RedirectToAction("ResourceOwner");
        //        }
        //        return RedirectToAction("ResourceOwner", new { mesg = "Cannot get access_token, response null" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("ResourceOwner", new { mesg = $"Exception: {ex.Message}" });
        //    }
        //}


        /// <summary>
        /// Init OAuth2 client
        /// </summary>
        private void _initializeWebServerClient()
        {
            var baseUrl = ConfigurationManager.AppSettings["AUTH_SERVER_BASE_URL"];
            var authorizationServerUri = new Uri(baseUrl);
            var clientId = ConfigurationManager.AppSettings["CLIENT_ID"];
            var clientSecret = ConfigurationManager.AppSettings["CLIENT_SECRET"];
            var authorizationServer = new AuthorizationServerDescription
            {
                AuthorizationEndpoint = new Uri(authorizationServerUri, "/signservice/v4/oauth/authorize"),
                TokenEndpoint = new Uri(authorizationServerUri, "/signservice/v4/oauth/token"),
            };

            // SSL configure
            ServicePointManager.ServerCertificateValidationCallback
                += new RemoteCertificateValidationCallback(CoreServiceClient.ValidateRemoteCertificate);


            _webServerClient = new WebServerClient(authorizationServer, clientId, clientSecret);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}