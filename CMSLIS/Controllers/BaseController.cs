using CMS_Core.Entity;
using CMS_Core.Implementtion;
using CMSLIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 

namespace CMSLIS.Controllers
{
    
    public class BaseController :   Controller
    {

        internal void AddLogin(string status, string Username )
        {
            try
            {
                ImpAccount_Login impAccount_Login = new ImpAccount_Login();
                Account_Login account_Login = new Account_Login();
                account_Login.IP = Common.Common.GetIPHelper();
                account_Login.Status = status;
                account_Login.Username = Username;
                account_Login.DateLogin = DateTime.Now;               
                impAccount_Login.InsertAccount_Login(account_Login);
            } catch { }
        }

        internal void AddLogAction(string logID, string actionType)
        {
            try
            {
                ImpAccount_LogAction impAccount_LogAction = new ImpAccount_LogAction();
                Account_LogAction account_LogAction = new Account_LogAction();
                account_LogAction.DateLog = DateTime.Now;
                if(!string.IsNullOrEmpty(logID))
                {
                    account_LogAction.logActionID = logID;
                } else
                {
                    account_LogAction.logActionID = "";
                }

                account_LogAction.actionType = Convert.ToInt32(actionType);
                account_LogAction.IP = Common.Common.GetIPHelper();
                account_LogAction.Username = ((cms_Account)HttpContext.Session["UserInfo"]).Username;
                string url = HttpContext.Request.RawUrl.ToLower();
                account_LogAction.menu = url;

                impAccount_LogAction.InsertAccount_LogAction(account_LogAction);
            }
            catch { }
        }


        internal void AddBreadcrumb(string displayName, string urlPath)
        {
            List<Message> messages;

            if (ViewBag.Breadcrumb == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = ViewBag.Breadcrumb as List<Message>;
            }

            messages.Add(new Message { DisplayName = displayName, URLPath = urlPath });
            ViewBag.Breadcrumb = messages;
        }

        internal void AddPageHeader(string pageHeader = "", string pageDescription = "")
        {
            ViewBag.PageHeader = Tuple.Create(pageHeader, pageDescription);
        }

        internal void AddPageAlerts(PageAlertType pageAlertType, string description)
        {
            List<Message> messages;

            if (ViewBag.PageAlerts == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = ViewBag.PageAlerts as List<Message>;
            }

            messages.Add(new Message { Type = pageAlertType.ToString().ToLower(), ShortDesc = description });
            ViewBag.PageAlerts = messages;
        }

        internal enum PageAlertType
        {
            Error,
            Info,
            Warning,
            Success
        }


    }
}