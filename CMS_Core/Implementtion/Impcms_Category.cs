using CMS_Core.Common;
using CMS_Core.Entity;
using CMS_Core.Interface;
using Dapper;
using log4net;
using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Implementtion
{
    public class Impcms_Category : Icms_Category
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        
        public cms_Category Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Category_SelectByPrimaryKey", id);
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


        public List<cms_Category> GetAllcms_Category(  int cateParrent, int status, int type, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.SelectQueryCommand("SP_cms_Category_SelectByStatus", cateParrent, status, type, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_Category: " + ex.ToString());
                return null;
            }
        }


        public List<cms_Category> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.SelectQueryCommand("SP_cms_Category_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Add(cms_Category entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.ExecuteInsert("SP_cms_Category_Insert", entity.cateName, entity.cateKeyword, entity.cateDescription, entity.cateImages, entity.cateParrent, entity.cateOrd, entity.CateAlias, entity.CreateBy );
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_Category entity)
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.ExecuteNonQuery("SP_cms_Category_DeleteByPrimaryKey", entity.cateId);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.cateId + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id)
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.ExecuteNonQuery("SP_cms_Category_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_Category entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteInsert("SP_cms_Category_Update", entity.cateId, entity.cateName, entity.cateKeyword, entity.cateDescription, entity.cateImages, entity.cateParrent, entity.cateOrd, entity.CateAlias, entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Publish(int id)
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.ExecuteNonQuery("SP_cms_Category_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<cms_Category> Getcms_CategoryParent()
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.SelectQueryCommand("SP_cms_Category_SelectParrent");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Category> Getcms_CategoryChild()
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.SelectQueryCommand("SP_cms_Category_SelectParrent");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Category> Getcms_CategoryChild(int parentid)
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.SelectQueryCommand("SP_cms_Category_SelectParrent", parentid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Category> Getcms_CategoryByCateName(string cateName)
        {
            try
            {
                SQLServerConnection<cms_Category> sQLServer = new SQLServerConnection<cms_Category>();
                return sQLServer.SelectQueryCommand("SP_cms_Category_SelectByName");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }
    }
}
