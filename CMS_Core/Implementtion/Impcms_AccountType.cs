using CMS_Core.Common;
using CMS_Core.Entity;
using CMS_Core.Interface;
using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Implementtion
{
    public class Impcms_AccountType : Icms_AccountType
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<cms_AccountType> Getcms_AccountTypeByID(int AccountTypeId)
        {
            try
            {
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                return sQLServer.SelectQueryCommand("SP_cms_AccountType_SelectByField", "AccountTypeId", AccountTypeId);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_AccountTypeByID: " + ex.ToString());
                return null;
            }
        }

        public List<cms_AccountType> Getcms_AccountTypeByName(string AccountTypeName)
        {
            try
            {
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                return sQLServer.SelectQueryCommand("SP_cms_AccountType_SelectByField", "AName", AccountTypeName);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_AccountTypeByName: " + ex.ToString());
                return null;
            }
        }

        public List<cms_AccountType> Getcms_AccountTypeByStatus(int status, int type, string keyword)
        {
            try
            {
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                return sQLServer.SelectQueryCommand("SP_cms_AccountType_SelectSTATUS",  status, type, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_AccountTypeByName: " + ex.ToString());
                return null;
            }
        }

        public cms_AccountType Get(int id)
        {
            try
            {
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                var data = sQLServer.SelectQueryCommand("SP_cms_AccountType_SelectByPrimaryKey", id);
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

        public List<cms_AccountType> GetAll()
        {
            try
            {
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                return sQLServer.SelectQueryCommand("SP_cms_AccountType_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Add(cms_AccountType entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                return sQLServer.ExecuteInsert("SP_cms_AccountType_Insert",   entity.AName, entity.ADesc, entity.Status, entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_AccountType entity)
        {
            try
            {
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                return sQLServer.ExecuteNonQuery("SP_cms_AccountType_DeleteByPrimaryKey", entity.AccountTypeId);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.AccountTypeId + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id)
        {
            try
            {
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                return sQLServer.ExecuteNonQuery("SP_cms_AccountType_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_AccountType entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                return sQLServer.ExecuteInsert("SP_cms_AccountType_Update", entity.AccountTypeId, entity.AName, entity.ADesc, entity.UpdateBy);
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
                SQLServerConnection<cms_AccountType> sQLServer = new SQLServerConnection<cms_AccountType>();
                return sQLServer.ExecuteNonQuery("SP_cms_AccountType_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }
    }
}
