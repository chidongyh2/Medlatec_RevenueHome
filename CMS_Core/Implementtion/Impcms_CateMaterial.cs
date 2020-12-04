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
    public class Impcms_CateMaterial : Icms_CateMaterial
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_CateMaterial entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_CateMaterial> sQLServer = new SQLServerConnection<cms_CateMaterial>();
                return sQLServer.ExecuteInsert("SP_cms_CateMaterial_Insert", entity.CateMaterial, entity.CateMaterialDesc, entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_CateMaterial entity)
        {
            try
            {
                SQLServerConnection<cms_CateMaterial> sQLServer = new SQLServerConnection<cms_CateMaterial>();
                return sQLServer.ExecuteNonQuery("SP_cms_CateMaterial_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_CateMaterial> sQLServer = new SQLServerConnection<cms_CateMaterial>();
                return sQLServer.ExecuteNonQuery("SP_cms_CateMaterial_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_CateMaterial Get(int id)
        {
            try
            {
                SQLServerConnection<cms_CateMaterial> sQLServer = new SQLServerConnection<cms_CateMaterial>();
                var data = sQLServer.SelectQueryCommand("SP_cms_CateMaterial_SelectByPrimaryKey", id);
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

        public List<cms_CateMaterial> GetAll()
        {
            try
            {
                SQLServerConnection<cms_CateMaterial> sQLServer = new SQLServerConnection<cms_CateMaterial>();
                return sQLServer.SelectQueryCommand("SP_cms_CateMaterial_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public cms_CateMaterial Getcms_CateMaterialByName(string CateItem)
        {
            try
            {
                SQLServerConnection<cms_CateMaterial> sQLServer = new SQLServerConnection<cms_CateMaterial>();
                var data = sQLServer.SelectQueryCommand("SP_cms_CateMaterial_SelectByName", CateItem);
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

        public List<cms_CateMaterial> Getcms_CateMaterialByStatus(int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_CateMaterial> sQLServer = new SQLServerConnection<cms_CateMaterial>();
                return sQLServer.SelectQueryCommand("SP_cms_CateMaterial_SelectSTATUS", status, typeKeyword, keyword);
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
                SQLServerConnection<cms_Unit> sQLServer = new SQLServerConnection<cms_Unit>();
                return sQLServer.ExecuteNonQuery("SP_cms_CateMaterial_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_CateMaterial entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_CateMaterial> sQLServer = new SQLServerConnection<cms_CateMaterial>();
                return sQLServer.ExecuteInsert("SP_cms_CateMaterial_Update", entity.id, entity.CateMaterial, entity.CateMaterialDesc, entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
