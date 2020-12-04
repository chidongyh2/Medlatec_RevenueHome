using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMS_Core.Common
{
    public class ComboBoxFinal<AnyType>
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        /// <summary>  
        /// Get GetComboBox method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public List<SelectListItem> GetComboBox(List<AnyType> data, string IDField, string NameField, bool withEmtyRow)
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        string textCombobox = string.Empty;
                        string valueCombobox = string.Empty;

                        foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var propertyName = prop.Name;
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                if (propertyName.ToLower().Equals(NameField.ToLower()))
                                {
                                    textCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                                if (propertyName.ToLower().Equals(IDField.ToLower()))
                                {
                                    valueCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(textCombobox))
                        {
                            items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                        }
                    }
                }

                if (withEmtyRow)
                {
                    items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                }

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetComboBox:" + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetComboBox method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public List<SelectListItem> GetComboBox(string sql, string IDField, string NameField, bool withEmtyRow)
        {
            try
            {
                string key = SaltedHash.EncodeMD5(sql);
                List<AnyType> data = null;
                if (HttpContext.Current.Session[key] != null)
                {
                    data = (List<AnyType>)HttpContext.Current.Session[key];
                }
                else
                {
                    SQLServerConnection<AnyType> sQLServer = new SQLServerConnection<AnyType>();                   
                    data = sQLServer.SelectQuery(sql);

                    HttpContext.Current.Session[key] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();

                if (data != null)
                {
                    foreach (var value in data)
                    {
                        string textCombobox = string.Empty;
                        string valueCombobox = string.Empty;

                        foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var propertyName = prop.Name;
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                if (propertyName.ToLower().Equals(NameField.ToLower()))
                                {
                                    textCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                                if (propertyName.ToLower().Equals(IDField.ToLower()))
                                {
                                    valueCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(textCombobox))
                        {
                            items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                        }
                    }
                }

                if (withEmtyRow)
                {
                    items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                }

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetComboBox:" + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetComboBoxBySelected method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public List<SelectListItem> GetComboBoxBySelected(List<AnyType> data, string IDField, string NameField, string ValueSelected, bool withEmtyRow)
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        string textCombobox = string.Empty;
                        string valueCombobox = string.Empty;

                        foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var propertyName = prop.Name;
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                if (propertyName.ToLower().Equals(NameField.ToLower()))
                                {
                                    textCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                                if (propertyName.ToLower().Equals(IDField.ToLower()))
                                {
                                    valueCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(textCombobox))
                        {
                            if (valueCombobox.Equals(ValueSelected))
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox, Selected = true });
                            }
                            else
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                            }
                        }

                    }
                }

                if (withEmtyRow)
                {
                    items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                }

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetComboBoxBySelected:" + ex.ToString());
                return null;
            }
        }


        /// <summary>  
        /// Get GetComboBoxBySelected method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public List<SelectListItem> GetComboBoxByMultiselect(List<AnyType> data, string IDField, string NameField, string[] ValueSelected, bool withEmtyRow)
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                if (data != null)
                {
                    foreach (var value in data)
                    {
                        string textCombobox = string.Empty;
                        string valueCombobox = string.Empty;

                        foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var propertyName = prop.Name;
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                if (propertyName.ToLower().Equals(NameField.ToLower()))
                                {
                                    textCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                                if (propertyName.ToLower().Equals(IDField.ToLower()))
                                {
                                    valueCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(textCombobox))
                        {

                            if (ValueSelected.Contains(valueCombobox))
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox, Selected = true });
                            }
                            else
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                            }
                        }

                    }
                }

                if (withEmtyRow)
                {
                    items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                }

                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetComboBoxBySelected:" + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetComboBoxBySelected method.   
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public List<SelectListItem> GetComboBoxBySelected(string sql, string IDField, string NameField, string ValueSelected, bool withEmtyRow)
        {
            try
            {
                if (string.IsNullOrEmpty(ValueSelected))
                {
                    ValueSelected = "0";
                }
                string key = SaltedHash.EncodeMD5(sql);
                List<AnyType> data = null;
                if (HttpContext.Current.Session[key] != null)
                {
                    data = (List<AnyType>)HttpContext.Current.Session[key];
                }
                else
                {
                    SQLServerConnection<AnyType> sQLServer = new SQLServerConnection<AnyType>();
                    data = sQLServer.SelectQuery(sql);
                    HttpContext.Current.Session[key] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();

                if (withEmtyRow)
                {
                    items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                }

                if (data != null)
                {
                    foreach (var value in data)
                    {
                        string textCombobox = string.Empty;
                        string valueCombobox = string.Empty;

                        foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var propertyName = prop.Name;
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                if (propertyName.ToLower().Equals(NameField.ToLower()))
                                {
                                    textCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                                if (propertyName.ToLower().Equals(IDField.ToLower()))
                                {
                                    valueCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(textCombobox))
                        {
                            if (valueCombobox.Equals(ValueSelected))
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox, Selected = true });
                            }
                            else
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                            }
                        }
                    }
                }



                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetComboBox:" + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// Get GetComboBoxBySelected method.   
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public List<SelectListItem> GetComboBoxNoCacheBySelected(string sql, string IDField, string NameField, string ValueSelected, bool withEmtyRow)
        {
            try
            {
                if (string.IsNullOrEmpty(ValueSelected))
                {
                    ValueSelected = "0";
                }
                string key = SaltedHash.EncodeMD5(sql);
                List<AnyType> data = null;

                SQLServerConnection<AnyType> sQLServer = new SQLServerConnection<AnyType>();
                data = sQLServer.SelectQuery(sql);


                List<SelectListItem> items = new List<SelectListItem>();

                if (withEmtyRow)
                {
                    items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                }

                if (data != null)
                {
                    foreach (var value in data)
                    {
                        string textCombobox = string.Empty;
                        string valueCombobox = string.Empty;

                        foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var propertyName = prop.Name;
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                if (propertyName.ToLower().Equals(NameField.ToLower()))
                                {
                                    textCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                                if (propertyName.ToLower().Equals(IDField.ToLower()))
                                {
                                    valueCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(textCombobox))
                        {
                            if (valueCombobox.Equals(ValueSelected))
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox, Selected = true });
                            }
                            else
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                            }
                        }
                    }
                }



                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetComboBox:" + ex.ToString());
                return null;
            }
        }



        public List<SelectListItem> GetComboBoxBySelected(string sql, string IDField, string NameField, string[] ValueSelected, bool withEmtyRow)
        {
            try
            {
                //if (ValueSelected == null)
                //{ ViewBag.Categories = new MultiSelectList(categories, "CategoryID", "CategoryName", new[]{1,3,7});
                //    ValueSelected = string.Empty ;
                //}
                string key = SaltedHash.EncodeMD5(sql);

                List<AnyType> data = null;
                if (HttpContext.Current.Session[key] != null)
                {
                    data = (List<AnyType>)HttpContext.Current.Session[key];
                }
                else
                {
                    SQLServerConnection<AnyType> sQLServer = new SQLServerConnection<AnyType>();                   
                    data = sQLServer.SelectQuery(sql);
                    HttpContext.Current.Session[key] = data;
                }

                List<SelectListItem> items = new List<SelectListItem>();

                if (withEmtyRow)
                {
                    items.Add(new SelectListItem { Text = "Tất cả", Value = "0" });
                }

                if (data != null)
                {
                    // selectListItems = new MultiSelectList(data, IDField, NameField);
                    foreach (var value in data)
                    {
                        string textCombobox = string.Empty;
                        string valueCombobox = string.Empty;

                        foreach (var prop in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var propertyName = prop.Name;
                            if (!string.IsNullOrEmpty(propertyName))
                            {
                                if (propertyName.ToLower().Equals(NameField.ToLower()))
                                {
                                    textCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                                if (propertyName.ToLower().Equals(IDField.ToLower()))
                                {
                                    valueCombobox = value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(textCombobox))
                        {
                            if (ValueSelected != null)
                            {
                                if (ValueSelected.Contains(valueCombobox))
                                {
                                    items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox, Selected = true });
                                }
                                else
                                {
                                    items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                                }
                            }
                            else
                            {
                                items.Add(new SelectListItem { Text = textCombobox, Value = valueCombobox });
                            }
                        }
                    }
                }



                return items;
            }
            catch (Exception ex)
            {
                logError.Info("GetComboBox:" + ex.ToString());
                return null;
            }
        }


    }
}
