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
    public class Impcms_Unit : Icms_Unit
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string Add(cms_Unit entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Unit> sQLServer = new SQLServerConnection<cms_Unit>();
                return sQLServer.ExecuteInsert("SP_cms_Unit_Insert", entity.UnitName, entity.UnitDesc, entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_Unit entity)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteNonQuery("SP_cms_Unit_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteNonQuery("SP_cms_Unit_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_Unit Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Unit> sQLServer = new SQLServerConnection<cms_Unit>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Unit_SelectByPrimaryKey", id);
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

        public List<cms_Unit> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Unit> sQLServer = new SQLServerConnection<cms_Unit>();
                return sQLServer.SelectQueryCommand("SP_cms_Unit_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public cms_Unit GetByName(string UnitName)
        {
            try
            {
                SQLServerConnection<cms_Unit> sQLServer = new SQLServerConnection<cms_Unit>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Unit_SelectByName", UnitName);
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

        public List<cms_Unit> GetByStatus(int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Unit> sQLServer = new SQLServerConnection<cms_Unit>();
                return sQLServer.SelectQueryCommand("SP_cms_Unit_SelectSTATUS", status, typeKeyword, keyword);
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
                return sQLServer.ExecuteNonQuery("SP_cms_Unit_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_Unit entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Unit> sQLServer = new SQLServerConnection<cms_Unit>();
                return sQLServer.ExecuteInsert("SP_cms_Account_Update", entity.id, entity.UnitName, entity.UnitDesc, entity.UpdateBy );
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
