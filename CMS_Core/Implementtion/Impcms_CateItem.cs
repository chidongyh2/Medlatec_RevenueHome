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
    public class Impcms_CateItem : Icms_CateItem
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string Add(cms_CateItem entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_CateItem> sQLServer = new SQLServerConnection<cms_CateItem>();
                return sQLServer.ExecuteInsert("SP_cms_CateItem_Insert", entity.CateItem, entity.CateItemDesc, entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_CateItem entity)
        {
            try
            {
                SQLServerConnection<cms_CateItem> sQLServer = new SQLServerConnection<cms_CateItem>();
                return sQLServer.ExecuteNonQuery("SP_cms_CateItem_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_CateItem> sQLServer = new SQLServerConnection<cms_CateItem>();
                return sQLServer.ExecuteNonQuery("SP_cms_CateItem_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_CateItem Get(int id)
        {
            try
            {
                SQLServerConnection<cms_CateItem> sQLServer = new SQLServerConnection<cms_CateItem>();
                var data = sQLServer.SelectQueryCommand("SP_cms_CateItem_SelectByPrimaryKey", id);
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

        public List<cms_CateItem> GetAll()
        {
            try
            {
                SQLServerConnection<cms_CateItem> sQLServer = new SQLServerConnection<cms_CateItem>();
                return sQLServer.SelectQueryCommand("SP_cms_CateItem_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public cms_CateItem Getcms_CateItemByName(string CateItem)
        {
            try
            {
                SQLServerConnection<cms_CateItem> sQLServer = new SQLServerConnection<cms_CateItem>();
                var data = sQLServer.SelectQueryCommand("SP_cms_CateItem_SelectByName", CateItem);
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

        public List<cms_CateItem> Getcms_CateItemByStatus(int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_CateItem> sQLServer = new SQLServerConnection<cms_CateItem>();
                return sQLServer.SelectQueryCommand("SP_cms_CateItem_SelectSTATUS", status, typeKeyword, keyword);
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
                SQLServerConnection<cms_CateItem> sQLServer = new SQLServerConnection<cms_CateItem>();
                return sQLServer.ExecuteNonQuery("SP_cms_CateItem_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_CateItem entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_CateItem> sQLServer = new SQLServerConnection<cms_CateItem>();
                return sQLServer.ExecuteInsert("SP_cms_CateItem_Update", entity.id, entity.CateItem, entity.CateItemDesc, entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
