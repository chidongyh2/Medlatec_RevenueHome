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
    public class Impcms_Order : Icms_Order
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_Order entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.ExecuteInsert("SP_cms_Order_Insert", entity.CustomerID, entity.CustomerName, entity.CustomerAdress, entity.CustomerMobile, entity.CustomerSurrogate, entity.CustomerSurrogateMobile, entity.CustomerEmail, entity.StartDate, entity.Enddate, entity.CreateBy, entity.OrderNote);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_Order entity)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_Order Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Order_SelectByPrimaryKey", id);
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

        public cms_Order GetByOrderCode(string OrderCode)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Order_SelectByOrderCode", OrderCode);
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


        public cms_Order convertCustomerToOrder(cms_Customer _Customer)
        {
            try
            {
                cms_Order _Order = new cms_Order();
                if (_Customer != null)
                {
                    if (_Customer.id > 0)
                    {
                        _Order.CustomerName = _Customer.CustomerName;
                        _Order.CustomerMobile = _Customer.CustomerMobile;
                        _Order.CustomerSurrogate = _Customer.CustomerSurrogate;
                        _Order.CustomerEmail = _Customer.CustomerEmail;
                        _Order.CustomerSurrogateMobile = _Customer.CustomerSurrogateMobile;
                        _Order.CustomerID = _Customer.id;
                        _Order.CustomerType = 1;
                        _Order.CustomerAdress = _Customer.CustomerAdress;
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
                return _Order;
            }
            catch (Exception ex)
            {
                logError.Info("Get: " + ex.ToString());
                return null;
            }
        }


        public cms_Order GetByItem(int id)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Order_SelectByItem", id);
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

        public cms_Order GetByMaterial(int id)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Order_SelectByMaterial", id);
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


        public List<cms_Order> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order> GetAllCalendar()
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_SelectlCalendar");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }


        public List<cms_Order> GetDebtCustomerid( int customerid)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.SelectQueryCommand("SP_cms_Customer_SelectDebtCustomerid", customerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order> GetListOrderByCustomerID( int customerID)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_SelectByCustomerID", customerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order> GetListOrderByCustomerIDNoBill(int customerID, string BillCodeGroup)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_SelectByCustomerIDNoBill", customerID, BillCodeGroup);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order> GetListOrderByTotalCustomerIDNoBill(int customerID)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_SelectByTotalCustomerIDNoBill", customerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }



        public cms_Order Getcms_OrderByName(string CustomerName, string CustomerMobile, string CustomerEmail)
        {
            throw new NotImplementedException();
        }

        public List<cms_Order> Getcms_OrderByStatus(string startdate, string enddate, int CustomerType, int userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_SelectSTATUS", startdate, enddate, CustomerType, userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order> Getcms_OrderByStatusReport(string startdate, string enddate, int CustomerType, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_SelectReport", startdate, enddate, CustomerType, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }


        public string Publish(int id)
        {
            throw new NotImplementedException();
        }



        public string Active1(int id)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Active1ByPrimaryKey", id);
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
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Active2ByPrimaryKey", id);
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
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Active3ByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Active4(int id)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Active4ByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string SetColor(int id)
        {
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_SetColor", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }
        public string Update(cms_Order entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Order> sQLServer = new SQLServerConnection<cms_Order>();
                return sQLServer.ExecuteInsert("SP_cms_Order_Update", entity.id, entity.CustomerID,entity.CustomerName, entity.CustomerAdress, entity.CustomerMobile, entity.CustomerSurrogate, entity.CustomerSurrogateMobile, entity.CustomerEmail, entity.StartDate, entity.Enddate, entity.UpdateBy, entity.OrderNote);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
