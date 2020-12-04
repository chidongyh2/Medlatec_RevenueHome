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
    public class Impcms_Order_Bill : Icms_Order_Bill
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_Order_Bill entity)
        {


            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.ExecuteInsert("SP_cms_Order_Bill_Insert", entity.OrderCode, entity.CustomerID, entity.CustomerName, entity.CustomerAdress, entity.CustomerMobile, entity.BillTotal, entity.BillCode, entity.BillImage, entity.OrderID, entity.CreateBy, entity.BillNote);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string AddNew(cms_Order_Bill entity)
        {


            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.ExecuteInsert("SP_cms_Order_Bill_Insert_BillCodeGroup", entity.id, entity.OrderCode, entity.CustomerID, entity.CustomerName, entity.CustomerAdress, entity.CustomerMobile, entity.BillTotal, entity.BillCode, entity.BillImage, entity.OrderID, entity.CreateBy, entity.BillNote, entity.BillCodeGroup, entity.BillTop);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }


        public string Delete(cms_Order_Bill entity)
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Bill_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Bill_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteBillCodeGroup(string BillCodeGroup)
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Bill_DeleteByBillCodeGroup", BillCodeGroup);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + BillCodeGroup + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_Order_Bill Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Order_Bill_SelectID", id);
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


        public cms_Order_Bill GetExit(int OrderID, string BillNote , float BillTotal)
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Order_Bill_SelectExit", OrderID, BillNote, BillTotal, DateTime.Now);
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


        public cms_Order_Bill GetTop()
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Order_Bill_TOP");
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
        public List<cms_Order_Bill> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_Bill_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order_Bill> Getcms_Order_BillByCustomerID(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_Bill_SelectByCustomerID", CustomerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order_Bill> Getcms_Order_BillByBillCodeGroup(string BillCodeGroup)
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_Bill_SelectByBillCodeGroup", BillCodeGroup);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }


        public List<cms_Order_Bill> Getcms_Order_BillByOrderCode(string OrderCode)
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_Bill_SelectByOrderCode", OrderCode);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }
         


        public List<cms_Order_Bill> Getcms_Order_BillByOrderID(int OrderID)
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_Bill_SelectByOrderID", OrderID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order_Bill> Getcms_Order_BillByStatus(string startdate, string enddate, int orderID, int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_Bill_SelectSTATUS", startdate, enddate, orderID, status, typeKeyword, keyword);
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
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Bill_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_Order_Bill entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Order_Bill> sQLServer = new SQLServerConnection<cms_Order_Bill>();
                return sQLServer.ExecuteInsert("SP_cms_Order_Bill_Update", entity.id, entity.OrderCode, entity.CustomerID, entity.CustomerName, entity.CustomerAdress, entity.CustomerMobile, entity.BillTotal, entity.BillCode, entity.BillImage, entity.OrderID, entity.UpdateBy, entity.BillNote);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
