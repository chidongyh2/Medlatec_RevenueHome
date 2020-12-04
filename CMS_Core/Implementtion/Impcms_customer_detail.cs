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
    public class Impcms_customer_detail : Icms_customer_detail
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_customer_detail entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.ExecuteInsert("SP_cms_customer_detail_Insert", entity.CustomerID, entity.ItemID, entity.ItemName, entity.ItemUnit, entity.Amount, entity.Price, entity.TotalPrice, entity.CreateBy, entity.OrderID, entity.Note, entity.id);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_customer_detail entity)
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.ExecuteNonQuery("SP_cms_customer_detail_DeleteByPrimaryKey", entity.id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int customerid, int itemid)
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.ExecuteNonQuery("SP_cms_customer_detail_DeleteByPrimaryKey", customerid, itemid);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + customerid + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string Delete(int id)
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.ExecuteNonQuery("SP_cms_customer_detail_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_customer_detail Get(int id)
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                var data = sQLServer.SelectQueryCommand("SP_cms_customer_detail_SelectByPrimaryKey", id);
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

        public List<cms_customer_detail> GetAll()
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_detail_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_customer_detail> Getcms_customer_detailByCustomerID(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_detail_SelectByCustomerID", CustomerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }
        public List<cms_customer_detail> Getcms_customer_detailByCustomerIDExport(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_detail_SelectByCustomerID_Export", CustomerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        

        public List<cms_customer_detail> Getcms_customer_detailByOrderID(int OrderID)
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_detail_SelectByOrderID", OrderID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }


        public List<cms_customer_detail> Getcms_customer_detailByCustomerIDAll(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_detail_SelectByCustomerIDAll", CustomerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_customer_detail> Getcms_customer_detailByCustomerIDDelete(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_detail_SelectByCustomerIDDelete", CustomerID);
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
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.ExecuteNonQuery("SP_cms_customer_detail_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_customer_detail entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_customer_detail> sQLServer = new SQLServerConnection<cms_customer_detail>();
                return sQLServer.ExecuteInsert("SP_cms_customer_detail_Update", entity.id, entity.CustomerID, entity.ItemID, entity.ItemName, entity.ItemUnit, entity.Amount, entity.Price, entity.TotalPrice, entity.UpdateBy, entity.OrderID, entity.Note);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
