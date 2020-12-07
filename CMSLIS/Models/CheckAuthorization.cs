using CMS_Core.Entity;
using CMS_Core.Implementtion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSLIS.Models
{
    public class CheckAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string url = filterContext.HttpContext.Request.Path.ToLower();

            string url1 = filterContext.HttpContext.Request.RawUrl.ToLower();

            if (url.IndexOf("account/login") == -1 && url.IndexOf("home/index") == -1 && url.IndexOf("revenuehome/revenuebyuserpdfipad") == -1 && url.IndexOf("revenuehome/revenueorderacceptpdf") == -1)
            {

                if (HttpContext.Current.Session["UserInfo"] == null || !HttpContext.Current.Request.IsAuthenticated)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.HttpContext.Response.StatusCode = 302; //Found Redirection to another page. Here- login page. Check Layout ajaxError() script.
                        filterContext.HttpContext.Response.End();
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("/account/login?ReturnUrl=" +
                             filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl));
                    }
                }
                else
                {


                    if (!string.IsNullOrEmpty(url))
                    {
                        url = url.Substring(1);
                    }
                    if (!string.IsNullOrEmpty(url1))
                    {
                        url1 = url1.Substring(1);
                    }

                    string submitName = HttpContext.Current.Request.Form["submit"];
                    if (string.IsNullOrEmpty(submitName))
                    {
                        submitName = string.Empty;



                        var UserInfo = ((cms_Account)HttpContext.Current.Session["UserInfo"]);
                        //   var ControlPermission = CMSLIS.Common.Common.GetControlPermission(UserInfo.AccountTypeId);

                        if (url.IndexOf("account/login") == -1 && url.IndexOf("home/index") == -1 && url.IndexOf("revenuehome/revenuebyuserpdfipad") == -1 && url.IndexOf("revenuehome/revenueorderacceptpdf") == -1)
                        {
                            List<cms_Menu> sys_Menus = null;
                            if (HttpContext.Current.Session["Sys_MenuByUser"] != null)
                            {
                                sys_Menus = (List<cms_Menu>)HttpContext.Current.Session["Sys_MenuByUser"];
                            }
                            else
                            {
                                Impcms_Menu impcms_Menu = new Impcms_Menu();
                                sys_Menus = impcms_Menu.GetAllcms_MenuByUserid(UserInfo.AccountTypeId);
                                HttpContext.Current.Session["Sys_MenuByUser"] = sys_Menus;
                            }

                            // Check Authorization 
                            if (sys_Menus != null)
                            {
                                bool isAuthorization = false;
                                foreach (var value in sys_Menus)
                                {
                                    if (!string.IsNullOrWhiteSpace(url) && !string.IsNullOrWhiteSpace(value.menLinks))
                                    {
                                        if (url.Equals(value.menLinks.ToLower()))
                                        {
                                            isAuthorization = true;
                                            break;
                                        }

                                        if (url1.Equals(value.menLinks.ToLower()))
                                        {
                                            isAuthorization = true;
                                            break;
                                        }
                                    }
                                }

                                //if (!isAuthorization)
                                //{
                                //    filterContext.Result = new RedirectResult("/Error/NoAuthorization?ReturnUrl=" +
                                //     filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl));
                                //}
                                //else
                                //{
                                //    foreach (var Permission in ControlPermission)
                                //    {
                                //        if (submitName.IndexOf(Permission.ControlID) != -1 && Permission.CheckPermision == false)
                                //        {
                                //            filterContext.Result = new RedirectResult("/Error/NoAuthorization?ReturnUrl=" +
                                //     filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl));
                                //        }
                                //    }


                                //}

                            }
                        }


                    }

                }
            }
        }
    }

}