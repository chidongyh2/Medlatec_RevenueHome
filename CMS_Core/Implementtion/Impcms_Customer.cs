using CMS_Core.Common;
using CMS_Core.Entity;
using CMS_Core.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Implementtion
{
    public class Impcms_Customer : Icms_Customer
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string Add(cms_Customer entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.ExecuteInsert("SP_cms_Customer_Insert", entity.CustomerName, entity.CustomerDesc, entity.CustomerAdress,  entity.CustomerMobile,  entity.CustomerSurrogate, entity.CustomerSurrogateMobile, entity.CustomerEmail, entity.CustomerWebsite, entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_Customer entity)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.ExecuteNonQuery("SP_cms_Customer_DeleteByPrimaryKey", entity.id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.ExecuteNonQuery("SP_cms_Customer_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_Customer Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Customer_SelectByPrimaryKey", id);
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        return data[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logError.Info("Get: " + ex.ToString());
                return null;
            }
        }

        public cms_Customer GetByItem(int id)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Customer_SelectByItem", id);
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        return data[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logError.Info("Get: " + ex.ToString());
                return null;
            }
        }

        public cms_Customer GetByMaterial(int id)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Customer_SelectByMaterial", id);
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        return data[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logError.Info("Get: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Customer> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.SelectQueryCommand("SP__cms_Customer_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public cms_Customer Getcms_CustomerByName(string CustomerName, string CustomerMobile, string CustomerEmail)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Customer_SelectByName", CustomerName, CustomerMobile, CustomerEmail);
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        return data[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logError.Info("Get: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Customer> Getcms_CustomerByStatus(string startdate, string enddate,  int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.SelectQueryCommand("SP_cms_Customer_SelectSTATUS", startdate, enddate,  status, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Customer> Getcms_CustomerByDebtCustomer()
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.SelectQueryCommand("SP_cms_Customer_SelectDebt");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.ExecuteNonQuery("SP_cms_Customer_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Active1(int id)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.ExecuteNonQuery("SP_cms_Customer_Active1ByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Active2(int id)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.ExecuteNonQuery("SP_cms_Customer_Active2ByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Active3(int id)
        {
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.ExecuteNonQuery("SP_cms_Customer_Active3ByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_Customer convertOrderToCustomer(cms_Order _Order)
        {
            try
            {
                cms_Customer _Customer = new cms_Customer();
                if (_Order != null)
                {
                    if (_Order.CustomerName.Length > 0)
                    {
                        _Customer.CustomerName = _Order.CustomerName;
                        _Customer.CustomerMobile = _Order.CustomerMobile;
                        _Customer.CustomerSurrogate = _Order.CustomerSurrogate;
                        _Customer.CustomerEmail = _Order.CustomerEmail;
                        _Customer.CustomerSurrogateMobile = _Order.CustomerSurrogateMobile;
                        _Customer.CustomerAdress = _Order.CustomerAdress;
                        _Customer.CustomerWebsite = string.Empty;
                        _Customer.CreateBy = _Order.CreateBy;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
                return _Customer;
            }
            catch (Exception ex)
            {
                logError.Info("Get: " + ex.ToString());
                return null;
            }
        }


        public string Update(cms_Customer entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Customer> sQLServer = new SQLServerConnection<cms_Customer>();
                return sQLServer.ExecuteInsert("SP_cms_Customer_Update", entity.id, entity.CustomerName, entity.CustomerDesc, entity.CustomerAdress, entity.CustomerMobile, entity.CustomerSurrogate, entity.CustomerSurrogateMobile, entity.CustomerEmail, entity.CustomerWebsite,   entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
