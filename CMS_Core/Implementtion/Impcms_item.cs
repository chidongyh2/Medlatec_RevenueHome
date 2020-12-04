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
    public class Impcms_item : Icms_item
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_item entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                return sQLServer.ExecuteInsert("SP_cms_item_Insert", entity.ItemName, entity.ItemDesc, entity.ItemUnit, entity.ItemColor, entity.ItemSurvive, entity.ItemUsage, entity.ItemNote, entity.ItemCateItemID, entity.Createby);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_item entity)
        {
            try
            {
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                return sQLServer.ExecuteNonQuery("SP_cms_item_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                return sQLServer.ExecuteNonQuery("SP_cms_item_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_item Get(int id)
        {
            try
            {
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                var data = sQLServer.SelectQueryCommand("SP_cms_item_SelectByPrimaryKey", id);
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

        public List<cms_item> GetAll (int id)
        {
            try
            {
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                var data = sQLServer.SelectQueryCommand("SP_cms_item_SelectByID", id);
                
                        return data;
                     
            }
            catch (Exception ex)
            {
                logError.Info("Get: " + ex.ToString());
                return null;
            }
        }

        public List<cms_item> GetAll()
        {
            try
            {
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                return sQLServer.SelectQueryCommand("SP_cms_item_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public cms_item Getcms_itemByName(string ItemName)
        {
            try
            {
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                var data = sQLServer.SelectQueryCommand("SP_cms_item_SelectByName", ItemName);
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

        public List<cms_item> Getcms_itemByStatus(string  startdate , string enddate, int ItemCateItemID,int ItemUnit,  int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                return sQLServer.SelectQueryCommand("SP_cms_item_SelectSTATUS", startdate, enddate, ItemCateItemID, ItemUnit, status, typeKeyword, keyword);
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
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                return sQLServer.ExecuteNonQuery("SP_cms_item_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_item entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                return sQLServer.ExecuteInsert("SP_cms_item_Update", entity.id, entity.ItemName, entity.ItemDesc, entity.ItemUnit, entity.ItemColor, entity.ItemSurvive, entity.ItemUsage, entity.ItemNote, entity.ItemCateItemID, entity.Updateby);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
