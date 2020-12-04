using CMS_Core.Entity;
using CMS_Core.Implementtion;
using CMS_Medicons.DigitalSignatures;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CMSLIS.Common
{
    public class Common
    {
        #region Properties
        private static string ConnStr = ConfigurationSettings.AppSettings["ConnStr"];
        private static ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        private static string ImagePath = ConfigurationSettings.AppSettings["ImagePath"];
        private static string ImageLink = ConfigurationSettings.AppSettings["ImageLink"];
        private static string KeyPrivate = ConfigurationSettings.AppSettings["KeyPrivate"];
        private static Random rnd = new Random();
        static string sDefaultWHEEL1 = "ABCDEFGHIJKLMNOPQRSTVUWXYZabcdefghijklmnopqrstuvwxyz1357986420-+*/;.,?><=|[] ";
        static string sDefaultWHEEL2 = "BNMQRYUASD-+*/;.,?><=|[]XCIWEHJKTLZVOPFG0246897531qwert yuiopasdfghjklzxcvbnm";
        #endregion Properties

        #region GetData

        /// <summary>
        /// getImagePath
        /// </summary>        
        /// <returns></returns> 
        public static string getImagePath()
        {

            return ImagePath;
        }

        /// <summary>
        /// getKeyPrivate
        /// </summary>        
        /// <returns></returns> 
        public static string getKeyPrivate()
        {

            return KeyPrivate;
        }


        /// <summary>
        /// getKeyPrivate
        /// </summary>        
        /// <returns></returns> 
        public static string generalKeyPrivate(string sid, string pid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sid))
                {
                    sid = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(pid))
                {
                    pid = string.Empty;
                }

                return SaltedHash.GenerateSHA512String(sid + getKeyPrivate() + pid);

            }
            catch
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// getKeyPrivate
        /// </summary>        
        /// <returns></returns> 
        public static string generalKeyPrivate(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    id = string.Empty;
                }
                return SaltedHash.GenerateSHA512String(id + getKeyPrivate());
            }
            catch
            {
                return string.Empty;
            }

        }


        /// <summary>
        /// getKeyPrivate
        /// </summary>        
        /// <returns></returns> 
        public static string getAction(string input, string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    if ("Item".Equals(value))
                    {
                        return "active";
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    if (input.Equals(value))
                    {
                        return "active";
                    }

                    else
                    {
                        return string.Empty;
                    }


                }

            }
            catch
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// getKeyPrivate
        /// </summary>        
        /// <returns></returns> 
        public static bool CheckKeyPrivate(string sid, string pid, string keyPrivate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sid))
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(pid))
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(keyPrivate))
                {
                    return false;
                }
                else
                {
                    if (keyPrivate.Equals(SaltedHash.GenerateSHA512String(sid + getKeyPrivate() + pid)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

        }


        /// <summary>
        /// getKeyPrivate
        /// </summary>        
        /// <returns></returns> 
        public static bool CheckKeyPrivate(string id, string keyPrivate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(keyPrivate))
                {
                    return false;
                }
                else
                {
                    if (keyPrivate.Equals(SaltedHash.GenerateSHA512String(id + getKeyPrivate())))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

        }



        /// <summary>
        /// getImagePath
        /// </summary>        
        /// <returns></returns> 
        public static string getImageLink()
        {

            return ImageLink;
        }

        /// <summary>  
        /// Get Getcms_AccountType method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_AccountType()
        {
            try
            {
                List<cms_AccountType> data = null;
                if (HttpContext.Current.Session["Getcms_AccountType"] != null)
                {
                    data = (List<cms_AccountType>)HttpContext.Current.Session["Getcms_AccountType"];
                }
                else
                {
                    Impcms_AccountType _AccountType = new Impcms_AccountType();
                    data = _AccountType.GetAll();
                    HttpContext.Current.Session["Getcms_AccountType"] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        items.Add(new SelectListItem { Text = value.AName, Value = value.AccountTypeId.ToString() });
                    }
                }

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_AccountType:" + ex.ToString());
                return null;
            }
        }

        public static void AddToLogFile(string content)
        {
            string fn = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";
            try
            {

                String path = "";

                path = ConfigurationSettings.AppSettings["LOG_PATH"];

                path += "/" + fn;
                if (path != "")
                {
                    System.IO.StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.UTF8);
                    writer.WriteLine(content);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeStatus()
        {
            try
            {
                //List<cms_TypeStatus> data = null;
                //if (HttpContext.Current.Session["GetTypeStatus"] != null)
                //{
                //    data = (List<cms_TypeStatus>)HttpContext.Current.Session["GetTypeStatus"];
                //}
                //else
                //{
                //    Impcms_TypeStatus impcms_TypeStatus = new Impcms_TypeStatus();
                //    data = impcms_TypeStatus.GetAllcms_TypeStatus();
                //    HttpContext.Current.Session["GetTypeStatus"] = data;
                //}

                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "-1" });
                items.Add(new SelectListItem { Text = "Ẩn", Value = "0" });
                items.Add(new SelectListItem { Text = "Chờ duyệt", Value = "1" });
                items.Add(new SelectListItem { Text = "Hoạt động", Value = "2" });


                //if (data != null)
                //{
                //    foreach (var value in data)
                //    {
                //        items.Add(new SelectListItem { Text = value.TypeStatusName, Value = value.TypeStatusId.ToString() });
                //    }
                //}

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeStatus: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "PID", Value = "1" });
                items.Add(new SelectListItem { Text = "Tên bệnh nhân", Value = "2" });
                items.Add(new SelectListItem { Text = "Số điện thoại", Value = "3" });
                items.Add(new SelectListItem { Text = "Email", Value = "4" });
                // items.Add(new SelectListItem { Text = "Mã khám bệnh", Value = "5" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeMenuKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên menu", Value = "1" });
                items.Add(new SelectListItem { Text = "Link", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeNewsKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên bài viết", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetCategoryKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên chuyên mục", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả chuyên mục", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeAccountKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Username", Value = "1" });
                items.Add(new SelectListItem { Text = "Email", Value = "2" });
                items.Add(new SelectListItem { Text = "Mobile", Value = "3" });
                items.Add(new SelectListItem { Text = "Họ tên", Value = "4" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetAccountTypeKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên nhóm", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả nhóm", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetUnitTypeKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên đơn vị", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả đơn vị", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeStatusKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên trạng thái", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả trạng thái", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeColorKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên mầu sắc", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả mầu sắc", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeMeterialKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên loại nguyên liệu", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả loại nguyên liệu", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeProducerKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên nhà sản xuất", Value = "1" });
                items.Add(new SelectListItem { Text = "Số điện thoại", Value = "2" });
                items.Add(new SelectListItem { Text = "Số email", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeItemKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên sản phẩm", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả sản phẩm", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeMaterialKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên nguyên liệu", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả nguyên liệu", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeRevenueKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên khách hàng", Value = "1" });
                items.Add(new SelectListItem { Text = "Số điện thoại", Value = "2" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeResultKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Mã dịch vụ", Value = "1" });
                items.Add(new SelectListItem { Text = "Tên dịch vụ", Value = "2" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeResulAlltKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "SID", Value = "1" });
                items.Add(new SelectListItem { Text = "Mã dịch vụ", Value = "2" });
                items.Add(new SelectListItem { Text = "Tên dịch vụ", Value = "3" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        public static List<SelectListItem> GetTypeRevenueAllKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "SID", Value = "1" });
                items.Add(new SelectListItem { Text = "Tên khách hàng", Value = "2" });
                items.Add(new SelectListItem { Text = "Số điện thoại", Value = "3" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        public static List<SelectListItem> GetTypeRevenueVoidKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Chi Nhánh", Value = "1" });
                items.Add(new SelectListItem { Text = "Tên cán bộ", Value = "2" });
               
                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeBillKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Mã hóa đơn", Value = "1" });
                items.Add(new SelectListItem { Text = "Mã đơn hàng", Value = "2" });
                items.Add(new SelectListItem { Text = "Tên khách hàng", Value = "3" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeDebtProducteKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Ghi chú", Value = "1" });
                items.Add(new SelectListItem { Text = "Tên đối tác", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeOrderExportKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Mã hóa đơn", Value = "1" });
                items.Add(new SelectListItem { Text = "Tên khách hàng", Value = "2" });
                items.Add(new SelectListItem { Text = "Ghi chú", Value = "3" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        public static string DecimalToStringVietnamese(decimal number, string ccyCode)
        {
            string s = number.ToString("0.##");
            if (s.EndsWith(".00"))
                s = s.Substring(s.Length - 3); //Khong co phan thap phan
            else
                if (s.Contains(".") && s.EndsWith("0"))
                s = s.Substring(s.Length - 1); //Bo chu so 0 cuoi cung di

            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            decimal decS = 0;
            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                bool isDecima = s.Contains("."); //La so co phan thap phan

                while (i > 0)
                {
                    if (isDecima && s.Substring(i - 1, 1) != ".")
                    {
                        int sodecima1 = Convert.ToInt32(s.Substring(i - 1, 1));
                        i--;
                        if (i > 0 && s.Substring(i - 1, 1) != ".")
                        {
                            int sodecima2 = Convert.ToInt32(s.Substring(i - 1, 1));
                            i--;
                            if (sodecima2 == 1)
                            {
                                str = " mười " + so[sodecima1] + str;
                            }
                            else
                                if (sodecima2 != 0 && sodecima1 == 1)
                                str = so[sodecima2] + " mốt " + str;
                            else
                                str = so[sodecima2] + " " + so[sodecima1] + str;
                        }
                        else
                        {
                            str = so[sodecima1] + str;
                        }

                        if (i > 0 && s.Substring(i - 1, 1) == ".")
                        {
                            str = "phẩy " + str;
                            i--;
                            isDecima = false;//Het phan thap phan
                        }
                    }

                    if (i <= 0)
                        break;

                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "mốt " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                    {
                        if (donvi == 0)
                            str = "không " + str;
                        break;
                    }
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;

            #region Doc phan cuoi
            switch (ccyCode)
            {
                case "VND":
                    str = str + " đồng";
                    break;

                case "USD":
                    str = str + " đô la Mỹ";
                    break;

                case "EUR":
                    str = str + " euro";
                    break;

                case "JPY":
                    str = str + " yên Nhật";
                    break;

                case "GBP":
                    str = str + " bảng Anh";
                    break;

                case "AUD":
                    str = str + " đô la Úc";
                    break;

                case "SGD":
                    str = str + " đô la Sing";
                    break;

                default:
                    str = str + " " + ccyCode;
                    break;
            }

            str = s.Contains(".") ? str + "." : str + " chẵn./.";
            #endregion Doc phan cuoi

            str = str.Replace("  ", " ").Trim();

            return char.ToUpper(str[0]) + str.Substring(1);

        }


        public static string GetFormatImage(string newsImages)
        {
            try
            {
                if (!string.IsNullOrEmpty(newsImages))
                {

                    newsImages = newsImages.Replace("Upload/", "").Replace("\\", "/");

                }
                return newsImages;

            }
            catch
            {
                return newsImages;
            }
        }


        public static string getNumber(int number)
        {
            try
            {
                int numberValue = 100000 + number;

                return numberValue.ToString().Substring(1, 5);

            }
            catch
            {
                return string.Empty;
            }
        }

        //public static void AddToLogFile(string content)
        //{
        //    string fn = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";
        //    try
        //    {

        //        String path = "";

        //        path = ConfigurationSettings.AppSettings["LOG_PATH"];

        //        path += "/" + fn;
        //        if (path != "")
        //        {
        //            System.IO.StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.UTF8);
        //            writer.WriteLine(content);
        //            writer.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}



        public static List<SelectListItem> GetTypeOrderKeyword()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Mã hóa đơn", Value = "1" });
                items.Add(new SelectListItem { Text = "Tên khách hàng", Value = "2" });
                items.Add(new SelectListItem { Text = "Số điện thoại", Value = "3" });
                items.Add(new SelectListItem { Text = "Email", Value = "4" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }
        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeKeywordWeirdo()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "PID", Value = "1" });
                items.Add(new SelectListItem { Text = "Email", Value = "2" });
                items.Add(new SelectListItem { Text = "Số điện thoại", Value = "3" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeKeywordSick()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên bệnh", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }
        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeKeywordMedicine()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Tên thuốc", Value = "1" });
                items.Add(new SelectListItem { Text = "Mô tả", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeyword: " + ex.ToString());
                return null;
            }
        }



        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeKeywordMedicalAppointment()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "Mã khám bệnh", Value = "1" });
                items.Add(new SelectListItem { Text = "Tên bệnh nhân", Value = "2" });
                items.Add(new SelectListItem { Text = "Số điện thoại", Value = "3" });
                items.Add(new SelectListItem { Text = "Email", Value = "4" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeywordMedicalAppointment: " + ex.ToString());
                return null;
            }
        }


        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetTypeKeywordWaitingForMedical()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                items.Add(new SelectListItem { Text = "PID", Value = "1" });
                items.Add(new SelectListItem { Text = "SID", Value = "2" });
                items.Add(new SelectListItem { Text = "SĐT", Value = "3" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetTypeKeywordWaitingForMedical: " + ex.ToString());
                return null;
            }
        }




        /// <summary>  
        /// Get Getcms_MenuParrent method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_MenuParrent()
        {
            try
            {
                List<cms_Menu> data = null;
                if (HttpContext.Current.Session["Getcms_MenuParrent"] != null)
                {
                    data = (List<cms_Menu>)HttpContext.Current.Session["Getcms_MenuParrent"];
                }
                else
                {
                    Impcms_Menu impcms_Menu = new Impcms_Menu();
                    data = impcms_Menu.GetAllcms_MenuParent();
                    HttpContext.Current.Session["Getcms_MenuParrent"] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        items.Add(new SelectListItem { Text = value.menName, Value = value.menId.ToString() });
                    }
                }

                items.Add(new SelectListItem { Text = "Menu gốc", Value = "0" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_MenuParrent:" + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get Getcms_MenuParrent method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<Sys_GroupMenuControlPermission> GetControlPermission(int GroupID)
        {
            try
            {
                List<Sys_GroupMenuControlPermission> data = null;
                List<Sys_GroupMenuControlPermission> ValueReturn = new List<Sys_GroupMenuControlPermission>();
                string url = HttpContext.Current.Request.RawUrl.ToLower();

                if (HttpContext.Current.Session["GetControlPermission"] != null)
                {
                    data = (List<Sys_GroupMenuControlPermission>)HttpContext.Current.Session["GetControlPermission"];
                }
                else
                {
                    ImpSys_GroupMenuControlPermission impSys_GroupMenuControlPermission = new ImpSys_GroupMenuControlPermission();
                    data = impSys_GroupMenuControlPermission.GetSys_GroupMenuControlPermissionByGroupID(GroupID);
                    HttpContext.Current.Session["GetControlPermission"] = data;
                }

                if (data != null)
                {
                    foreach (var value in data)
                    {
                        if (url.IndexOf(value.MenLink.ToLower()) != -1)
                        {
                            ValueReturn.Add(value);
                        }
                    }
                }

                return ValueReturn;

            }
            catch (Exception ex)
            {
                logError.Info("GetControlPermission:" + ex.ToString());
                return null;
            }
        }





        /// <summary>  
        /// Get Getcms_MenuChild method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_MenuChild(int ParrentID)
        {
            try
            {
                List<cms_Menu> data = null;
                if (HttpContext.Current.Session["Getcms_MenuChild" + ParrentID] != null)
                {
                    data = (List<cms_Menu>)HttpContext.Current.Session["Getcms_MenuChild" + ParrentID];
                }
                else
                {
                    Impcms_Menu impcms_Menu = new Impcms_Menu();
                    data = impcms_Menu.GetAllcms_MenuChild(ParrentID);
                    HttpContext.Current.Session["Getcms_MenuChild" + ParrentID] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        items.Add(new SelectListItem { Text = value.menName, Value = value.menId.ToString() });
                    }
                }

                items.Add(new SelectListItem { Text = "Menu Con ", Value = "0" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_MenuChild: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get Getcms_CategoryParrent method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_CategoryParrent()
        {
            try
            {
                List<cms_Category> data = null;
                if (HttpContext.Current.Session["Getcms_CategoryParrent"] != null)
                {
                    data = (List<cms_Category>)HttpContext.Current.Session["Getcms_CategoryParrent"];
                }
                else
                {
                    Impcms_Category impcms_Category = new Impcms_Category();
                    data = impcms_Category.Getcms_CategoryParent();
                    HttpContext.Current.Session["Getcms_CategoryParrent"] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();

                CMS_Core.Common.ComboBoxFinal<cms_Category> comboBoxFinal = new CMS_Core.Common.ComboBoxFinal<cms_Category>();
                items = comboBoxFinal.GetComboBox(data, "cateId", "cateName", true);



                //if (data != null)
                //{
                //    foreach (var value in data)
                //    {
                //        items.Add(new SelectListItem { Text = value.cateName, Value = value.cateId.ToString() });
                //    }
                //}

                // items.Add(new SelectListItem { Text = "Chuyên mục gốc", Value = "0" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_CategoryParrent:" + ex.ToString());
                return null;
            }
        }





        /// <summary>  
        /// Get Getcms_CategoryParrent method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_Account()
        {
            try
            {
                List<cms_Account> data = null;
                if (HttpContext.Current.Session["Getcms_Account"] != null)
                {
                    data = (List<cms_Account>)HttpContext.Current.Session["Getcms_Account"];
                }
                else
                {
                    ImpCms_Account impCms_Account = new ImpCms_Account();
                    data = impCms_Account.GetAll();
                    HttpContext.Current.Session["Getcms_Account"] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        items.Add(new SelectListItem { Text = value.Username, Value = value.uid.ToString() });
                    }
                }

                items.Add(new SelectListItem { Text = "Chọn tất cả", Value = "0" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_CategoryParrent:" + ex.ToString());
                return null;
            }
        }






        /// <summary>  
        /// Get Getcms_Permissiont method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_Permissiont()
        {
            try
            {
                List<cms_Permission> data = null;
                if (HttpContext.Current.Session["Getcms_Permissiont"] != null)
                {
                    data = (List<cms_Permission>)HttpContext.Current.Session["Getcms_Permissiont"];
                }
                else
                {
                    Impcms_Permission impcms_Permission = new Impcms_Permission();
                    data = impcms_Permission.GetAllcms_Permission();
                    HttpContext.Current.Session["Getcms_Permissiont"] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        items.Add(new SelectListItem { Text = value.permissionName, Value = value.permissionId.ToString() });
                    }
                }


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_Permissiont:" + ex.ToString());
                return null;
            }
        }




        ///// <summary>  
        ///// Get Getcms_Permissiont method.  
        ///// </summary>  
        ///// <returns>Return Type for drop down list.</returns>  
        //public static List<SelectListItem> GetComboBox(List<AnyType> data,  int selected)
        //{
        //    try
        //    {
        //        List<AnyType> data = null;
        //        if (HttpContext.Current.Session["Getcms_Permissiont"] != null)
        //        {
        //            data = (List<cms_Permission>)HttpContext.Current.Session["Getcms_Permissiont"];
        //        }
        //        else
        //        {
        //            Impcms_Permission impcms_Permission = new Impcms_Permission();
        //            data = impcms_Permission.GetAllcms_Permission();
        //            HttpContext.Current.Session["Getcms_Permissiont"] = data;
        //        }

        //        List<SelectListItem> items = new List<SelectListItem>();
        //        if (data != null)
        //        {
        //            foreach (var value in data)
        //            {
        //                if (value.permissionId == selected)
        //                {
        //                    items.Add(new SelectListItem { Text = value.permissionName, Value = value.permissionId.ToString(), Selected = true });
        //                }
        //                else
        //                {
        //                    items.Add(new SelectListItem { Text = value.permissionName, Value = value.permissionId.ToString() });
        //                }
        //            }
        //        }


        //        return items;
        //    }
        //    catch (Exception ex)
        //    {
        //        logError.Info("Getcms_Permissiont:" + ex.ToString());
        //        return null;
        //    }
        //}



        /// <summary>  
        /// Get Getcms_Permissiont method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_Permissiont(int selected)
        {
            try
            {
                List<cms_Permission> data = null;
                if (HttpContext.Current.Session["Getcms_Permissiont"] != null)
                {
                    data = (List<cms_Permission>)HttpContext.Current.Session["Getcms_Permissiont"];
                }
                else
                {
                    Impcms_Permission impcms_Permission = new Impcms_Permission();
                    data = impcms_Permission.GetAllcms_Permission();
                    HttpContext.Current.Session["Getcms_Permissiont"] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        if (value.permissionId == selected)
                        {
                            items.Add(new SelectListItem { Text = value.permissionName, Value = value.permissionId.ToString(), Selected = true });
                        }
                        else
                        {
                            items.Add(new SelectListItem { Text = value.permissionName, Value = value.permissionId.ToString() });
                        }
                    }
                }


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_Permissiont:" + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetStatus(int selected)
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                if (selected == 1)
                {
                    items.Add(new SelectListItem { Text = "Chờ duyệt", Value = "1", Selected = true });
                }
                else
                {
                    items.Add(new SelectListItem { Text = "Chờ duyệt", Value = "1" });
                }
                if (selected == 2)
                {
                    items.Add(new SelectListItem { Text = "Duyệt", Value = "2", Selected = true });
                }
                else
                {
                    items.Add(new SelectListItem { Text = "Duyệt", Value = "2" });
                }

                if (selected == 0)
                {
                    items.Add(new SelectListItem { Text = "Xóa", Value = "0", Selected = true });
                }
                else
                {
                    items.Add(new SelectListItem { Text = "Xóa", Value = "0" });
                }


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetStatus: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetStatus()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Chờ duyệt", Value = "1", Selected = true });

                items.Add(new SelectListItem { Text = "Duyệt", Value = "2", Selected = true });

                items.Add(new SelectListItem { Text = "Xóa", Value = "0", Selected = true });
                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetStatus: " + ex.ToString());
                return null;
            }
        }



        /// <summary>  
        /// Get GetStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_Language(int selected)
        {
            try
            {

                List<cms_Language> data = null;
                if (HttpContext.Current.Session["Getcms_Language"] != null)
                {
                    data = (List<cms_Language>)HttpContext.Current.Session["Getcms_Language"];
                }
                else
                {
                    Impcms_Language impcms_Language = new Impcms_Language();
                    data = impcms_Language.Getcms_LanguageAll(CMSLIS.Common.Constant.TypeStatusAll);
                    HttpContext.Current.Session["Getcms_Language"] = data;
                }


                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        if (selected == value.ID)
                        {
                            items.Add(new SelectListItem { Text = value.LanguageName, Value = value.ID.ToString(), Selected = true });
                        }
                        else
                        {
                            items.Add(new SelectListItem { Text = value.LanguageName, Value = value.ID.ToString() });
                        }
                    }
                }
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_Language: " + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_Language()
        {
            try
            {

                List<cms_Language> data = null;
                if (HttpContext.Current.Session["Getcms_Language"] != null)
                {
                    data = (List<cms_Language>)HttpContext.Current.Session["Getcms_Language"];
                }
                else
                {
                    Impcms_Language impcms_Language = new Impcms_Language();
                    data = impcms_Language.Getcms_LanguageAll(CMSLIS.Common.Constant.TypeStatusAll);
                    HttpContext.Current.Session["Getcms_Language"] = data;
                }


                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        items.Add(new SelectListItem { Text = value.LanguageName, Value = value.ID.ToString() });
                    }
                }
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });


                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_Language: " + ex.ToString());
                return null;
            }
        }




        /// <summary>  
        /// Get Getcms_Permissiont method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_NewsSource()
        {
            try
            {
                List<cms_NewsSource> data = null;
                if (HttpContext.Current.Session["Getcms_NewsSource"] != null)
                {
                    data = (List<cms_NewsSource>)HttpContext.Current.Session["Getcms_NewsSource"];
                }
                else
                {
                    Impcms_NewsSource impcms_NewsSource = new Impcms_NewsSource();
                    data = impcms_NewsSource.GetAllcms_NewsSource();
                    HttpContext.Current.Session["Getcms_NewsSource"] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        items.Add(new SelectListItem { Text = value.SourceName, Value = value.SourceId.ToString() });
                    }
                }
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_NewsSource: " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get Getcms_Permissiont method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getcms_NewsTypeMessage()
        {
            try
            {
                List<cms_NewsTypeMessage> data = null;
                if (HttpContext.Current.Session["Getcms_NewsTypeMessage"] != null)
                {
                    data = (List<cms_NewsTypeMessage>)HttpContext.Current.Session["Getcms_NewsTypeMessage"];
                }
                else
                {
                    Impcms_NewsTypeMessage impcms_NewsTypeMessage = new Impcms_NewsTypeMessage();

                    data = impcms_NewsTypeMessage.GetAllcms_NewsTypeMessage();
                    HttpContext.Current.Session["Getcms_NewsTypeMessage"] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        items.Add(new SelectListItem { Text = value.TypeMessageName, Value = value.TypeMessageId.ToString() });
                    }
                }
                items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_NewsTypeMessage: " + ex.ToString());
                return null;
            }
        }

        #endregion


        #region private

        /// <summary>
        /// get IP Logcal
        /// </summary>        
        /// <returns></returns> 
        public static string GetIPHelper()
        {
            string ip = string.Empty;
            try
            {
                ip = HttpContext.Current.Request.UserHostAddress;
            }
            catch { }

            return ip;
        }

        /// <summary>
        /// Mã hóa chuỗi ký tự
        /// </summary>
        /// <param name="sINPUT"> Chuỗi ký tự đầu vào</param>
        /// <returns> Trả ra chuỗi mã hóa</returns>
        public static string Encrypt(string sINPUT)
        {
            if (sINPUT == null) return "";
            string sWHEEL1 = (string)sDefaultWHEEL1.Clone();
            string sWHEEL2 = (string)sDefaultWHEEL2.Clone();
            int k, i;
            string sRESULT = "";
            char C;

            for (i = 0; i < sINPUT.Length; i++)
            {
                C = sINPUT[i];
                k = sWHEEL1.IndexOf(C);
                if (k == -1) sRESULT += C.ToString();
                else sRESULT += sWHEEL2[k].ToString();
                sWHEEL1 = LeftShift(sWHEEL1);
                sWHEEL2 = RightShift(sWHEEL2);
            }

            return sRESULT;
        }


        private static string LeftShift(string S)
        {
            int len = S.Length;
            string s = "";
            if (len > 0) s = S.Substring(1, len - 1) + S.Substring(0, 1);
            return s;
        }

        private static string RightShift(string S)
        {
            int len = S.Length;
            string s = "";
            if (len > 0) s = S.Substring(len - 1, 1) + S.Substring(0, len - 1);
            return s;
        }
        public static string RenderFinal(int GroupID, string url)
        {
            var strBuilder = new StringBuilder();
            // check null URL
            if (string.IsNullOrEmpty(url))
            {
                url = string.Empty;
            }
            if (!string.IsNullOrEmpty(url))
            {
                url = url.Substring(1);
            }


            Impcms_Menu impcms_Menu = new Impcms_Menu();
            List<cms_Menu> dataParent = null;
            if (HttpContext.Current.Session["GetAllcms_MenuParentByUserid" + GroupID] != null)
            {
                dataParent = (List<cms_Menu>)HttpContext.Current.Session["GetAllcms_MenuParentByUserid" + GroupID];
            }
            else
            {
                dataParent = impcms_Menu.GetAllcms_MenuParentByGroupID(GroupID);
                HttpContext.Current.Session["GetAllcms_MenuParentByUserid" + GroupID] = dataParent;
            }

            if (dataParent != null)
            {
                strBuilder.Append("<li class=\"treeview\">\n");
                dataParent.ForEach(x =>
                {
                    List<cms_Menu> listChild = null;

                    if (HttpContext.Current.Session["GetAllcms_MenuChildByUserid" + x.menId] != null)
                    {
                        listChild = (List<cms_Menu>)HttpContext.Current.Session["GetAllcms_MenuChildByUserid" + x.menId];
                    }
                    else
                    {
                        listChild = impcms_Menu.GetAllcms_MenuChildByGroupID(x.menId, GroupID);
                        HttpContext.Current.Session["GetAllcms_MenuChildByUserid" + x.menId] = listChild;
                    }



                    //tag open <li> parent
                    strBuilder.Append(listChild != null && listChild.Count > 0 ? "<li>\n" : "<li>\n");
                    if (listChild != null && listChild.Count > 0)
                    {
                        bool isAuthorization = false;
                        foreach (var Child in listChild)
                        {
                            if (url.Equals(Child.menLinks.ToLower()))
                            {
                                isAuthorization = true;
                                break;
                            }

                            if ((url.IndexOf("catalogsystem/categorydynamic") == -1) && (url.IndexOf("Clinic/ListPatientWaitingForMedical") == -1) && (url.IndexOf(Child.menLinks.ToLower()) != -1))
                            {
                                isAuthorization = true;
                                break;
                            }
                            if ((url.IndexOf("Clinic/ListPatientWaitingForMedical") == -1) && (url.IndexOf(Child.menLinks.ToLower()) != -1))
                            {
                                isAuthorization = true;
                                break;
                            }


                        }

                        if (isAuthorization == true)
                        {
                            //tag open <li> parent
                            strBuilder.Append("<li class=\"treeview menu-open\">\n");
                            //tên menu cha
                            strBuilder.AppendFormat("<a href=\"#\"><i class=\"{1}\"></i><span>{0}</span><span class=\"pull-right-container\"><i class=\"fa fa-angle-left pull-right\"></i></span></a>\n", x.menName, x.Style);
                            //menu con
                            strBuilder.Append("<ul class=\"treeview-menu\"  style =\"display: block;\">\n");
                        }
                        else
                        {
                            //tag open <li> parent
                            strBuilder.Append("<li class=\"treeview\">\n");
                            //tên menu cha
                            strBuilder.AppendFormat("<a href=\"#\"><i class=\"{1}\"></i><span>{0}</span><span class=\"pull-right-container\"><i class=\"fa fa-angle-left pull-right\"></i></span></a>\n", x.menName, x.Style);
                            //menu con
                            strBuilder.Append("<ul class=\"treeview-menu\">\n");
                        }



                        strBuilder.Append(LoopBackChildMenu(listChild, GroupID, url));
                        //end ul tag child
                        strBuilder.Append("</ul>\n");
                    }
                    else
                    {
                        strBuilder.Append("<li>\n");
                        strBuilder.AppendFormat("<a href=\"{0}\"><i class=\"{1}\"></i><span>{2}</span></a>\n", x.menLinks, x.Style, x.menName);

                        //  strBuilder.AppendFormat("<a href=\"{0}\"><i class=\"{1}\"></i><span>{2}</span></a></li>\n", x.menLinks, x.Style, x.menName);
                    }
                });

                //end tag <li> parent
                strBuilder.Append("</li>\n");
            }
            return strBuilder.ToString();
        }



        public static List<SelectListItem> Getcms_CategoryParrentNews()
        {
            try
            {
                List<cms_Category> data = null;
                List<cms_Category> listChild = null;
                List<SelectListItem> items = new List<SelectListItem>();
                Impcms_Category impcms_Category = new Impcms_Category();

                if (HttpContext.Current.Session["Getcms_CategoryParrent"] != null)
                {
                    items = (List<SelectListItem>)HttpContext.Current.Session["Getcms_CategoryParrent"];
                }
                else
                {


                    data = impcms_Category.Getcms_CategoryParent();


                    if (data != null)
                    {
                        foreach (var value in data)
                        {

                            items.Add(new SelectListItem { Text = value.cateName, Value = value.cateId.ToString() });

                            listChild = impcms_Category.Getcms_CategoryChild(value.cateId);
                            if (listChild != null)
                            {
                                foreach (var valueChild in listChild)
                                {
                                    items.Add(new SelectListItem { Text = "|--->" + valueChild.cateName, Value = valueChild.cateId.ToString() });
                                }
                            }
                        }
                    }

                    items.Add(new SelectListItem { Text = "Chuyên mục gốc", Value = "0" });

                    //  HttpContext.Current.Session["Getcms_CategoryParrent"] = items;
                }

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_CategoryParrent:" + ex.ToString());
                return null;
            }
        }


        public static List<cms_Menu> GetsortCut(int UserID)
        {
            List<cms_Menu> dataSortCut = null;
            try
            {
                Impcms_Menu impcms_Menu = new Impcms_Menu();
                if (HttpContext.Current.Session["GetsortCut" + UserID] != null)
                {
                    dataSortCut = (List<cms_Menu>)HttpContext.Current.Session["GetsortCut" + UserID];
                }
                else
                {
                    dataSortCut = impcms_Menu.GetAllcms_MenuBySortCut(UserID);
                    HttpContext.Current.Session["GetsortCut" + UserID] = dataSortCut;
                }
            }
            catch { }

            return dataSortCut;
        }



        public static string LoopBackChildMenu(List<cms_Menu> listSys, int UserID, string url)
        {
            var strLoop = new StringBuilder();
            listSys.ForEach(x =>
            {

                if (!string.IsNullOrEmpty(url))
                {
                    bool isAuthorization = false;
                    if (url.Equals(x.menLinks.ToLower()))
                    {
                        isAuthorization = true;
                    }
                    else
                        if ((url.IndexOf("catalogsystem/categorydynamic") == -1) && (url.IndexOf("Clinic/ListPatientWaitingForMedical") == -1) && (url.IndexOf(x.menLinks.ToLower()) != -1))
                    {
                        isAuthorization = true;
                    }
                    //else
                    //    if ((url.IndexOf("Clinic/ListPatientWaitingForMedical") == -1) && (url.IndexOf(x.menLinks.ToLower()) != -1))
                    //{
                    //    isAuthorization = true;
                    //}

                    if (isAuthorization)
                    {
                        strLoop.Append("<li class=\"active\">");
                    }
                    else
                    {
                        strLoop.Append("<li>");
                    }

                    strLoop.AppendFormat("<a  href=\"/{0}\"><i class=\"{1}\"></i><span>{2}</span></a>\n", x.menLinks, x.Style, x.menName);
                    strLoop.Append("</li>\n");

                }
                else
                {
                    strLoop.AppendFormat("<li><a href=\"/{0}\"><i class=\"{1}\"></i><span>{2}</span></a></li>\n", x.menLinks, x.Style, x.menName);
                }

            });

            return strLoop.ToString();
        }




        public static bool Base64ToImage(string base64String, string path)
        {
            bool result = true;
            try
            {
                base64String = base64String.Replace("data:image/jpeg;base64,", "");

                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                image.Save(path);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


        // <summary>
        /// format datetime
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static string ReFmtTime(object obj)
        {
            try
            {
                string ss = convertString(obj);

                if (DateTime.Parse(ss) < DateTime.Now.AddYears(-100))
                    return "";
                else return DateTime.Parse(ss).ToString("dd/MM/yyyy HH:mm");
            }
            catch
            {
                return "";
            }
        }


        public static string getRandom()
        {
            return rnd.Next(99999).ToString();
        }

        public static string getNiceUrl(Object objurl)
        {
            try
            {
                String url = objurl.ToString();
                String niceurl = ConvertEN(url);
                niceurl = niceurl.Replace("-", "");
                niceurl = niceurl.Replace(" ", "-");
                niceurl = niceurl.Replace("_", "-");
                niceurl = niceurl.Replace("nbsp;", "-");
                niceurl = niceurl.Replace("'", "");
                niceurl = niceurl.Replace("-", "_");

                niceurl = removeChar(niceurl, new String[] { "/", "m²", ":", ",", "<", ">", "”", "“", ".", "!", "?", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "~", "`", "'", "'", "\"" });
                return niceurl;
            }
            catch
            {
                return "";
            }
        }

        public static String removeChar(String niceurl, String[] danhsach)
        {
            foreach (String xoa in danhsach)
            {
                niceurl = niceurl.Replace(xoa, "");
            }
            return niceurl;
        }
        public static string ConvertVietnameseCharacterToEN(string sCharacter)
        {
            string sTemplate = "ĂẮẰẲẴẶăắằẳẵặÂẤẦẨẪẬâấầẩẫậÁÀẢÃẠáàảãạÔỐỒỔỖỘôốồổỗộƠỚỜỞỠỢơớờởỡợÓÒỎÕỌóòỏõọĐđÊẾỀỂỄỆêếềểễệÉÈẺẼẸéèẻẽẹƯỨỪỬỮỰưứừửữựÚÙỦŨỤúùủũụÍÌỈĨỊíìỉĩịÝỲỶỸỴýỳỷỹỵ";
            string sReplate = "AAAAAAaaaaaaAAAAAAaaaaaaAAAAAaaaaaOOOOOOooooooOOOOOOooooooOOOOOoooooDdEEEEEEeeeeeeEEEEEeeeeeUUUUUUuuuuuuUUUUUuuuuuIIIIIiiiiiYYYYYyyyyy";
            char[] arrChar = sTemplate.ToCharArray();
            char[] arrReChar = sReplate.ToCharArray();
            string sResult = "";//sCharacter;
            char digit;

            for (int ch = 0; ch < sCharacter.Length; ch++)
            {
                digit = Convert.ToChar(sCharacter.Substring(ch, 1));//arrChar[ch].ToString();;
                for (int i = 0; i < arrChar.Length; i++)
                    if (digit.Equals(arrChar[i]))
                        digit = arrReChar[i];
                sResult += digit;
            }

            return sResult;
        }
        public static string ConvertEN(string sCharacter)
        {
            string sTemplate = "ĂẮẰẲẴẶăắằẳẵặÂẤẦẨẪẬâấầẩẫậÁÀẢÃẠáàảãạÔỐỒỔỖỘôốồổỗộƠỚỜỞỠỢơớờởỡợÓÒỎÕỌóòỏõọĐđÊẾỀỂỄỆêếềểễệÉÈẺẼẸéèẻẽẹƯỨỪỬỮỰưứừửữựÚÙỦŨỤúùủũụÍÌỈĨỊíìỉĩịÝỲỶỸỴýỳỷỹỵ";
            string sReplate = "AAAAAAaaaaaaAAAAAAaaaaaaAAAAAaaaaaOOOOOOooooooOOOOOOooooooOOOOOoooooDdEEEEEEeeeeeeEEEEEeeeeeUUUUUUuuuuuuUUUUUuuuuuIIIIIiiiiiYYYYYyyyyy";
            string sDau = "[̣̃́̉̀]"; // dấu ngã, sắc, nặng, hỏi, ngã
            char[] arrChar = sTemplate.ToCharArray();
            char[] arrReChar = sReplate.ToCharArray();
            string sResult = "";//sCharacter;
            char digit;
            // modified by datnd - 1/4/2010
            // xoa di tat ca cac dau
            Regex reg = new Regex(sDau);
            sCharacter = reg.Replace(sCharacter, "");
            // xoa dia tat ca cac ki tu ma hoa html	http://www.kamol.info/html-encoding-of-foreign-language-characters/		
            try
            {
                sCharacter = Regex.Replace(sCharacter, @"&(\w)(\w){4,5};", "$1");
            }
            catch (ArgumentException ex) { }

            // end modified
            for (int ch = 0; ch < sCharacter.Length; ch++)
            {
                digit = Convert.ToChar(sCharacter.Substring(ch, 1));//arrChar[ch].ToString();;
                for (int i = 0; i < arrChar.Length; i++)
                {
                    if (digit.Equals(arrChar[i]))
                        digit = arrReChar[i];
                }
                sResult += digit;
            }

            return sResult;
        }


        /// <summary>
        /// convert object to string
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static string convertString(object obj)
        {
            try
            {
                return obj.ToString().Trim();
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// convert object to string
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static string getStatusActive(bool action)
        {
            try
            {
                if (action)
                {
                    return "<span style=\"width: 100px; \"><span class=\"badge-text badge-text-small success\">Hoạt động</span></span>";
                }
                else
                {
                    return "<span style=\"width: 100px; \"><span class=\"badge-text badge-text-small danger\">Ẩn</span></span>";
                }
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// convert object to string
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static string getTypeStatus(int Status)
        {
            try
            {
                if (Status == 2)
                {
                    return "<span style=\"width: 130px; \"><span class=\"btn btn-info btn-xs\">Hoạt động</span></span>";
                }
                else if (Status == 0)
                {
                    return "<span style=\"width: 130px; \"><span class=\"btn btn-danger btn-xs \">Ẩn</span></span>";
                }
                else
                {
                    return "<span style=\"width: 130px; \"><span class=\"btn btn-warning  btn-xs \">Chờ duyệt</span></span>";
                }
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// format tiền tệ
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static string ReFmtAmt(object oj, bool isCutoff)
        {
            try
            {
                string ss = convertString(oj);
                if (ss.Length > 2 && isCutoff)
                    ss = ss.Substring(0, ss.Length - 2);

                return FmtAmt(convertInt(ss));
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// format datetime
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static string ReFmtDate(object obj)
        {
            try
            {
                string ss = convertString(obj);

                if (DateTime.Parse(ss) < DateTime.Now.AddYears(-100))
                    return "";
                else return DateTime.Parse(ss).ToString("dd/MM/yyyy");
            }
            catch
            {
                return "";
            }
        }

        public static string FirstCharToUpper(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.  
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.  
            // ... Uppercase the lowercase letters following spaces.  
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        //public static string FirstCharToUpper(string s)
        //{
        //    // Check for empty string.  
        //    if (string.IsNullOrEmpty(s))
        //    {
        //        return string.Empty;
        //    }
        //    // Return char and concat substring.  
        //    return char.ToUpper(s[0]) + s.Substring(1);
        //}


        /// <summary>
        /// convert object to int
        /// </summary>
        /// <param name="obj">input</param>
        /// <returns></returns>
        public static int convertInt(object obj)
        {
            try
            {
                return int.Parse(obj.ToString().Trim());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// convert object  
        /// </summary>
        /// <param name="obj">input</param>
        /// <returns></returns>
        public static string FmtAmt(object obj)
        {
            try
            {
                double dobj = double.Parse(obj.ToString());
                CultureInfo cultureToUse = new CultureInfo("en-GB");

                string ss = dobj.ToString("N", cultureToUse);
                ss = ss.Replace(".00", "");
                return ss;
            }
            catch
            {
                return convertString(obj);
            }
        }
        /// <summary>
        /// convert object  
        /// </summary>
        /// <param name="obj">input</param>
        /// <returns></returns>
        public static string FmtAmtWithDecimal(object obj)
        {
            try
            {
                double dobj = double.Parse(obj.ToString());
                CultureInfo cultureToUse = new CultureInfo("en-GB");

                string ss = dobj.ToString("N", cultureToUse);
                //ss = ss.Replace(".00", "");
                return ss;
            }
            catch
            {
                return convertString(obj);
            }
        }


        /// <summary>
        /// convert string to datatime
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj)
        {
            DateTime retVal;
            try
            {
                retVal = Convert.ToDateTime(obj);
            }
            catch
            {
                retVal = DateTime.Now;
            }
            if (retVal == new DateTime(1, 1, 1)) return DateTime.Now;

            return retVal;
        }

        /// <summary>
        /// convert string to datatime
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj, DateTime defaultValue)
        {
            DateTime retVal;
            try
            {
                retVal = Convert.ToDateTime(obj);
            }
            catch
            {
                retVal = DateTime.Now;
            }
            if (retVal == new DateTime(1, 1, 1)) return defaultValue;

            return retVal;
        }


        /// <summary>
        /// Trả về ngày tháng tiếng việt
        /// </summary>
        /// <param name="date">datetime</param>
        /// <returns></returns>
        public static string VNFormatDate(DateTime date)
        {
            string sDate = "";

            try
            {

                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        sDate = "Thứ Hai  &bull;   ";
                        break;
                    case DayOfWeek.Tuesday:
                        sDate = "Thứ Ba  &bull;  ";
                        break;
                    case DayOfWeek.Wednesday:
                        sDate = "Thứ Tư  &bull;  ";
                        break;
                    case DayOfWeek.Thursday:
                        sDate = "Thứ Năm  &bull;  ";
                        break;
                    case DayOfWeek.Friday:
                        sDate = "Thứ Sáu   &bull; ";
                        break;
                    case DayOfWeek.Saturday:
                        sDate = "Thứ Bảy   &bull; ";
                        break;
                    case DayOfWeek.Sunday:
                        sDate = "Chủ Nhật  &bull;  ";
                        break;
                }


            }
            catch
            {

            }
            sDate += " " + date.ToString("dd/MM/yyyy &bull;   HH:mm");
            return sDate;
        }

        /// <summary>
        /// kiểm tra xem có phải là số không
        /// </summary>
        /// <param name="input">input validate</param>
        /// <returns></returns>
        public static bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }



        public static string FormatSave(string Html)
        {


            Html = Html.Replace(ImageLink, "./");
            Html = Html.Replace(ImagePath, "./");
            Html = Html.Replace("/../", "../");
            Html = Html.Replace("../../../ImagePath/images", "./ImagePath/images");
            Html = Html.Replace("../../ImagePath/images", "./ImagePath/images");
            Html = Html.Replace("../ImagePath/images", "./ImagePath/images");
            Html = Html.Replace(ImageLink + "ImagePath/images", "/ImagePath/images");
            Html = Html.Replace(ImagePath + "ImagePath/images", "/ImagePath/images");

            Html = Html.Replace("/ImagePath/images", "./ImagePath/images");

            Html = Html.Replace(".http://", "http://");
            Html = Html.Replace(".//", "./");
            Html = Html.Replace(".//", "./");
            Html = Html.Replace(".\\", "./");
            Html = Html.Replace("\\", "/");


            Html = Html.Replace(".../http://", "http://");
            Html = Html.Replace("<span style=\"font-family: Times New Roman;\">&nbsp;</span>", "");
            Html = Html.Replace("<p></p>", "");
            Html = Html.Replace("<p> </p>", "");
            Html = Html.Replace("&rsquo;", "'");
            Html = Html.Replace("muted = \"\"", "");
            Html = Html.Replace(".JPG", ".jpg");
            Html = Html.Replace(".PNG", ".png");
            Html = Html.Replace(".GIF", ".gif");

            return Html;
        }

        public static string FormatView(string Html)
        {



            Html = Html.Replace("/cms/", "/");
            Html = Html.Replace("../../../ImagePath/images", "/ImagePath/images");
            Html = Html.Replace("../../ImagePath/images", "/ImagePath/images");
            Html = Html.Replace("../ImagePath/images", "/ImagePath/images");
            Html = Html.Replace("./ImagePath/images", "/ImagePath/images");
            Html = Html.Replace(".../http://", "http://");


            Html = Html.Replace("./ImagePath/images", "/ImagePath/images");
            Html = Html.Replace("../ImagePath/media", "/ImagePath/media");




            Html = Html.Replace("/ImagePath/images", ImageLink + "ImagePath/images"); //swich to new ip

            Html = Html.Replace("../ImagePath/media", "/ImagePath/media");
            Html = Html.Replace("./ImagePath/media", "/ImagePath/media");
            Html = Html.Replace("ImagePath/media", "/ImagePath/media");
            Html = Html.Replace("//ImagePath/media", "/ImagePath/media");
            Html = Html.Replace("/ImagePath/media", ImageLink + "ImagePath/media"); //swich to new ip



            Html = Html.Replace("/http://", "http://");
            Html = Html.Replace("//http://", "//http://");



            return Html;
        }



        /// <summary>
        /// Get giới tính
        /// </summary>
        /// <param name="obj">input</param>
        /// <returns></returns>
        public static string GetGENDERName(string GENDER)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(GENDER))
                    GENDER = string.Empty;
                if (GENDER.Equals("1"))
                    return "Nam";
                else if (GENDER.Equals("0"))
                    return "Nữ";
                else
                    return "Khác";
            }
            catch
            {
                return "Khác";
            }
        }
        /// <summary>
        /// Get giới tính
        /// </summary>
        /// <param name="obj">input</param>
        /// <returns></returns>
        public static string GetStatusWaiting(int status)
        {
            try
            {

                if (status == 1)
                    return "Chờ gọi";
                else return "Qua lượt";
            }
            catch
            {
                return "Khác";
            }
        }


        public static byte[] ReadFileToByte(String filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException("File name is null");
                }
                if (!File.Exists(filePath))
                {
                    throw new NullReferenceException("File not found. check file name.");
                }
                return File.ReadAllBytes(filePath);
            }
            catch (Exception)
            {

            }
            return null;
        }
        public static Boolean WriteFileFromByte(byte[] data, String filePath)
        {
            Boolean result = false;
            try
            {
                if (data == null || data.Length <= 0)
                {
                    throw new ArgumentNullException("Data null");
                }
                using (FileStream fsattach = new FileStream(filePath, System.IO.FileMode.Create, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fsattach);
                    bw.Write(data);
                    bw.Flush();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        // Sign
        public static byte[] SignXML(byte[] input)
        {
            String XML_WORKER_NAME = "XMLSigner";
            CMS_Medicons.DigitalSignatures.ClientWSClient service = new CMS_Medicons.DigitalSignatures.ClientWSClient();

            try
            {
                dataResponse response = service.processData(XML_WORKER_NAME, null, input);
                return response.data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public static byte[] SignPDF(byte[] input)
        {
            try
            {
                String PDF_WORKER_NAME = "PDFSigner_14";
                CMS_Medicons.DigitalSignatures.ClientWSClient service = new CMS_Medicons.DigitalSignatures.ClientWSClient();

                // meta data               
                metadata rec = new metadata();
                rec.name = "VISIBLE_SIGNATURE_RECTANGLE";
                rec.Value = "10,10,150,70"; // tọa độ chữ ký

                metadata validateStatus = new metadata();
                validateStatus.name = "SIGNATURE_VALIDATIONSTATUS";
                validateStatus.Value = "1"; // hiển thị dấu validate hay không?

                metadata recPage = new metadata();
                recPage.name = "VISIBLE_SIGNATURE_PAGE";
                recPage.Value = "2"; // trang đặt chữ ký

                List<metadata> metaData = new List<metadata>();
                metaData.Add(rec);
                metaData.Add(validateStatus);
                metaData.Add(recPage);

                dataResponse response = service.processData(PDF_WORKER_NAME, metaData.ToArray(), input);
                return response.data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
        public static byte[] SignOOXML(byte[] input)
        {

            try
            {
                String OOXML_WORKER_NAME = "OOXMLSigner";
                CMS_Medicons.DigitalSignatures.ClientWSClient service = new CMS_Medicons.DigitalSignatures.ClientWSClient();
                dataResponse response = service.processData(OOXML_WORKER_NAME, null, input);
                return response.data;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public static byte[] SignCMS(byte[] input)
        {
            String XML_WORKER_NAME = "CMSSigner";
            CMS_Medicons.DigitalSignatures.ClientWSClient service = new CMS_Medicons.DigitalSignatures.ClientWSClient();

            dataResponse response = service.processData(XML_WORKER_NAME, null, input);
            return response.data;
        }
        // Verify
        public static string ValidateCMS(byte[] input)
        {
            try
            {
                String OOXML_WORKER_NAME = "CMSValidator";
                CMS_Medicons.DigitalSignatures.ClientWSClient client = new CMS_Medicons.DigitalSignatures.ClientWSClient();
                return client.validateData(OOXML_WORKER_NAME, null, input);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public static string ValidateXML(byte[] input)
        {
            try
            {
                String WORKER_NAME = "XMLValidator";
                CMS_Medicons.DigitalSignatures.ClientWSClient service = new CMS_Medicons.DigitalSignatures.ClientWSClient();
                return service.validateData(WORKER_NAME, null, input);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public static string ValidatePDF(byte[] input)
        {
            try
            {
                String WORKER_NAME = "PDFValidator";
                CMS_Medicons.DigitalSignatures.ClientWSClient service = new CMS_Medicons.DigitalSignatures.ClientWSClient();
                return service.validateData(WORKER_NAME, null, input);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public static string ValidateOOXML(byte[] input)
        {
            try
            {
                String WORKER_NAME = "OOXMLValidator";
                CMS_Medicons.DigitalSignatures.ClientWSClient service = new CMS_Medicons.DigitalSignatures.ClientWSClient();
                return service.validateData(WORKER_NAME, null, input);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        // validate certificate
        public static void ValidateCertificate()
        {
            String certUser = ""; // base64 của chứng thư số
            String CERT_VALIDATOR = "CertificateValidator";

            CMS_Medicons.DigitalSignatures.ClientWSClient service = new CMS_Medicons.DigitalSignatures.ClientWSClient();
            try
            {
                
                var result = service.validateData(CERT_VALIDATOR, null, Convert.FromBase64String(certUser));
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

    }
}