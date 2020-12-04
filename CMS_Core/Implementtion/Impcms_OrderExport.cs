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
    public class Impcms_OrderExport : Icms_OrderExport
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_OrderExport entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.ExecuteInsert("SP_cms_OrderExport_Insert", entity.OrderCode, entity.CustomerID, entity.CustomerName, entity.CustomerAdress, entity.CustomerMobile, entity.CustomerEmail, entity.OrderExportTotal, entity.OrderExportDate, entity.CreateBy, entity.OrderExportNote, entity.OrderID);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_OrderExport entity)
        {
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.ExecuteNonQuery("SP_cms_OrderExport_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.ExecuteNonQuery("SP_cms_OrderExport_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_OrderExport Get(int id)
        {
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                var data = sQLServer.SelectQueryCommand("SP_cms_OrderExport_SelectByPrimaryKey", id);
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

        public List<cms_OrderExport> GetAll()
        {
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.SelectQueryCommand("SP_cms_OrderExport_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_OrderExport> Getcms_OrderExportByCustomerID(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.SelectQueryCommand("SP_cms_OrderExport_SelectByCustomerID");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_OrderExport> Getcms_OrderExportByCustomerIDActive(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.SelectQueryCommand("SP_cms_OrderExport_SelectByCustomerIDAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_OrderExport> Getcms_OrderExportByCustomerIDDeActive(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.SelectQueryCommand("SP_cms_OrderExport_SelectByCustomerIDDelete");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_OrderExport> Getcms_OrderExportByOrderID(int OrderID)
        {
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.SelectQueryCommand("SP_cms_OrderExport_SelectByOrderID");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_OrderExport> Getcms_OrderExportByStatus(string startdate, string enddate, int CustomerID, int OrderID , int status,   int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.SelectQueryCommand("SP_cms_OrderExport_SelectSTATUS", startdate, enddate,   CustomerID, OrderID,   status, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_OrderExportByStatus: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id)
        {
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.ExecuteNonQuery("SP_cms_OrderExport_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_OrderExport entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.ExecuteInsert("SP_cms_OrderExport_Update", entity.id, entity.OrderCode, entity.CustomerID, entity.CustomerName, entity.CustomerAdress, entity.CustomerMobile, entity.CustomerEmail, entity.OrderExportTotal, entity.OrderExportDate, entity.UpdateBy, entity.OrderExportNote, entity.OrderID);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
