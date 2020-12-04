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
    public class ImpCms_Color : ICms_Color
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(Cms_Color entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<Cms_Color> sQLServer = new SQLServerConnection<Cms_Color>();
                return sQLServer.ExecuteInsert("SP_Cms_Color_Insert", entity.ColorName, entity.ColorDesc, entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(Cms_Color entity)
        {
            try
            {
                SQLServerConnection<Cms_Color> sQLServer = new SQLServerConnection<Cms_Color>();
                return sQLServer.ExecuteNonQuery("SP_Cms_Color_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<Cms_Color> sQLServer = new SQLServerConnection<Cms_Color>();
                return sQLServer.ExecuteNonQuery("SP_Cms_Color_DeleteByPrimaryKey",  id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public Cms_Color Get(int id)
        {
            try
            {
                SQLServerConnection<Cms_Color> sQLServer = new SQLServerConnection<Cms_Color>();
                var data = sQLServer.SelectQueryCommand("SP_Cms_Color_SelectByPrimaryKey", id);
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

        public List<Cms_Color> GetAll()
        {
            try
            {
                SQLServerConnection<Cms_Color> sQLServer = new SQLServerConnection<Cms_Color>();
                return sQLServer.SelectQueryCommand("SP_Cms_Color_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public Cms_Color GetCms_ColorByName(string ColorName)
        {
            try
            {
                SQLServerConnection<Cms_Color> sQLServer = new SQLServerConnection<Cms_Color>();
                var data = sQLServer.SelectQueryCommand("SP_Cms_Color_SelectByName", ColorName);
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

        public List<Cms_Color> GetCms_ColorByStatus( int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<Cms_Color> sQLServer = new SQLServerConnection<Cms_Color>();
                return sQLServer.SelectQueryCommand("SP_Cms_Color_SelectSTATUS", status, typeKeyword, keyword);
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
                SQLServerConnection<Cms_Color> sQLServer = new SQLServerConnection<Cms_Color>();
                return sQLServer.ExecuteNonQuery("SP_Cms_Color_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(Cms_Color entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<Cms_Color> sQLServer = new SQLServerConnection<Cms_Color>();
                return sQLServer.ExecuteInsert("SP_Cms_Color_Update", entity.id, entity.ColorName, entity.ColorDesc, entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
