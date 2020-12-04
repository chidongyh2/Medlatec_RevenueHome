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
    public class Impcms_Type : Icms_Type
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_Type entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Type> sQLServer = new SQLServerConnection<cms_Type>();
                return sQLServer.ExecuteInsert("SP_cms_Type_Insert", entity.TypeName, entity.TypeDesc, entity.TypeOrder, entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_Type entity)
        {
            try
            {
                SQLServerConnection<cms_Type> sQLServer = new SQLServerConnection<cms_Type>();
                return sQLServer.ExecuteNonQuery("SP_cms_Type_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_Type> sQLServer = new SQLServerConnection<cms_Type>();
                return sQLServer.ExecuteNonQuery("SP_cms_Type_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_Type Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Type> sQLServer = new SQLServerConnection<cms_Type>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Type_SelectByPrimaryKey", id);
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

        public List<cms_Type> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Type> sQLServer = new SQLServerConnection<cms_Type>();
                return sQLServer.SelectQueryCommand("SP_cms_Type_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public cms_Type Getcms_TypeByName(string CateItem)
        {
            try
            {
                SQLServerConnection<cms_Type> sQLServer = new SQLServerConnection<cms_Type>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Type_SelectByName", CateItem);
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

        public List<cms_Type> Getcms_TypeItemByStatus(int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Type> sQLServer = new SQLServerConnection<cms_Type>();
                return sQLServer.SelectQueryCommand("SP_cms_Type_SelectSTATUS", status, typeKeyword, keyword);
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
                SQLServerConnection<cms_Type> sQLServer = new SQLServerConnection<cms_Type>();
                return sQLServer.ExecuteNonQuery("SP_cms_Type_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_Type entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Type> sQLServer = new SQLServerConnection<cms_Type>();
                return sQLServer.ExecuteInsert("SP_cms_Type_Update", entity.id, entity.TypeName, entity.TypeDesc, entity.TypeOrder, entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
