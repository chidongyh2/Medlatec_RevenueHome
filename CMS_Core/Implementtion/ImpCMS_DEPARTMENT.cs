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
    public class ImpCMS_DEPARTMENT : ICMS_DEPARTMENT
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_DEPARTMENT entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_DEPARTMENT> sQLServer = new OracleServerConnection<CMS_DEPARTMENT>();
                return sQLServer.ExecuteInsert("sp_CMS_DEPARTMENT_Insert", entity.DEPARTMENT_NAME, entity.DEPARTMENT_DESC, entity.DEPARTMENT_STATUS, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Add(CMS_DEPARTMENT entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_DEPARTMENT entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_DEPARTMENT> sQLServer = new OracleServerConnection<CMS_DEPARTMENT>();
                return sQLServer.ExecuteNonQuery("SP_CMS_DEPARTMENT_DELETE", entity.ID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_DEPARTMENT> sQLServer = new OracleServerConnection<CMS_DEPARTMENT>();
                return sQLServer.ExecuteNonQuery("SP_CMS_DEPARTMENT_DELETE", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(CMS_DEPARTMENT entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CMS_DEPARTMENT Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_DEPARTMENT> sQLServer = new OracleServerConnection<CMS_DEPARTMENT>();
                var data = sQLServer.SelectQueryCommand("SP_CMS_DEPARTMENT_BYID", id, PARTNERID);
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
                logError.Info("CMS_DEPARTMENT: " + ex.ToString());
                return null;
            }
        }

        public CMS_DEPARTMENT Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_DEPARTMENT> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_DEPARTMENT> sQLServer = new OracleServerConnection<CMS_DEPARTMENT>();
                return sQLServer.SelectQueryCommand("SP_CMS_DEPARTMENT_BYALL", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_DEPARTMENT> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CMS_DEPARTMENT> GetCMS_DEPARTMENT_BYSTATUS(int STATUS, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_DEPARTMENT> sQLServer = new OracleServerConnection<CMS_DEPARTMENT>();
                return sQLServer.SelectQueryCommand("SP_CMS_DEPARTMENT_BYSTATUS", STATUS, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_DEPARTMENT_BYSTATUS: " + ex.ToString());
                return null;
            }
        }

        public CMS_DEPARTMENT GetName(string DepartmentName, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_DEPARTMENT> sQLServer = new OracleServerConnection<CMS_DEPARTMENT>();
                var data = sQLServer.SelectQueryCommand("SP_CMS_DEPARTMENT_BYNAME", DepartmentName, PARTNERID);
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
                logError.Info("GetName: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_DEPARTMENT> sQLServer = new OracleServerConnection<CMS_DEPARTMENT>();
                return sQLServer.ExecuteNonQuery("SP_CMS_DEPARTMENT_PUBLICH", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_DEPARTMENT entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_DEPARTMENT> sQLServer = new OracleServerConnection<CMS_DEPARTMENT>();
                return sQLServer.ExecuteNonQuery("sp_cms_department_update", entity.ID, entity.DEPARTMENT_NAME, entity.DEPARTMENT_DESC, entity.DEPARTMENT_STATUS, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Update(CMS_DEPARTMENT entity)
        {
            throw new NotImplementedException();
        }
    }
}
