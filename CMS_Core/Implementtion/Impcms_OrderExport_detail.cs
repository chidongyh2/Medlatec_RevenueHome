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
    public class Impcms_OrderExport_detail : Icms_OrderExport_detail
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_OrderExport_detail entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_OrderExport> sQLServer = new SQLServerConnection<cms_OrderExport>();
                return sQLServer.ExecuteInsert("SP_cms_OrderExport_detail_Insert", entity.OrderExportID, entity.CustomerID, entity.ItemID, entity.ItemName, entity.ItemUnit, entity.Amount, entity.Price, entity.TotalPrice, entity.UpdateBy, entity.OrderID, entity.OrderCode);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_OrderExport_detail entity)
        {
            try
            {
                SQLServerConnection<cms_OrderExport_detail> sQLServer = new SQLServerConnection<cms_OrderExport_detail>();
                return sQLServer.ExecuteNonQuery("SP_cms_OrderExport_detail_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_OrderExport_detail> sQLServer = new SQLServerConnection<cms_OrderExport_detail>();
                return sQLServer.ExecuteNonQuery("SP_cms_OrderExport_detail_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteByOrderExportID(int OrderExportID)
        {
            try
            {
                SQLServerConnection<cms_OrderExport_detail> sQLServer = new SQLServerConnection<cms_OrderExport_detail>();
                return sQLServer.ExecuteNonQuery("SP_cms_OrderExport_detail_DeleteByOrderExportID", OrderExportID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + OrderExportID + "  " + ex.ToString());
                return string.Empty;
            }
        }



        public cms_OrderExport_detail Get(int id)
        {
            try
            {
                SQLServerConnection<cms_OrderExport_detail> sQLServer = new SQLServerConnection<cms_OrderExport_detail>();
                var data = sQLServer.SelectQueryCommand("SP_cms_OrderExport_detail_SelectByPrimaryKey", id);
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

        public List<cms_OrderExport_detail> GetAll()
        {
            try
            {
                SQLServerConnection<cms_OrderExport_detail> sQLServer = new SQLServerConnection<cms_OrderExport_detail>();
                return sQLServer.SelectQueryCommand("SP_cms_OrderExport_detail_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_OrderExport_detail> Getcms_OrderExportByOrderExportID(int OrderExportID)
        {
            try
            {
                SQLServerConnection<cms_OrderExport_detail> sQLServer = new SQLServerConnection<cms_OrderExport_detail>();
                return sQLServer.SelectQueryCommand("SP_cms_OrderExport_detail_SelectByOrderExportID", OrderExportID);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_OrderExportByOrderExportID: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id)
        {
            try
            {
                SQLServerConnection<cms_OrderExport_detail> sQLServer = new SQLServerConnection<cms_OrderExport_detail>();
                return sQLServer.ExecuteNonQuery("SP_cms_OrderExport_detail_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_OrderExport_detail entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_OrderExport_detail> sQLServer = new SQLServerConnection<cms_OrderExport_detail>();
                return sQLServer.ExecuteInsert("SP_cms_OrderExport_detail_Update", entity.id, entity.OrderExportID, entity.CustomerID, entity.ItemID, entity.ItemName, entity.ItemUnit, entity.Amount, entity.Price, entity.TotalPrice, entity.UpdateBy,  entity.OrderID);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
