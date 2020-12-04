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
    public class ImpCMS_SICK : ICMS_SICK
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_SICK entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_SICK> sQLServer = new OracleServerConnection<CMS_SICK>();
                return sQLServer.ExecuteInsert("SP_CMS_SICK_INSERT", entity.SICK_NAME, entity.SICK_DESC, entity.SICK_SYMPTOM, entity.SICK_HEALING, entity.SICK_NOTE, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.SICK_STATUS, entity.PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Add(CMS_SICK entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_SICK entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_SICK> sQLServer = new OracleServerConnection<CMS_SICK>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SICK_Delete", entity.ID, PARTNERID);
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
                OracleServerConnection<CMS_SICK> sQLServer = new OracleServerConnection<CMS_SICK>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SICK_Delete", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(CMS_SICK entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CMS_SICK Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_SICK> sQLServer = new OracleServerConnection<CMS_SICK>();
                var data = sQLServer.SelectQueryCommand("SP_CMS_SICK_BYPID", id, PARTNERID);
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

        public CMS_SICK Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_SICK> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_SICK> sQLServer = new OracleServerConnection<CMS_SICK>();
                return sQLServer.SelectQueryCommand("SP_CMS_SICK_SELECTALL", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SICK> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CMS_SICK> GetAll_CMS_SICK_BYNAME(string Name, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_SICK> sQLServer = new OracleServerConnection<CMS_SICK>();
                return sQLServer.SelectQueryCommand("SP_CMS_SICK_SELECT_BYNAME", Name, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll_CMS_SICK_BYNAME: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SICK> GetAll_CMS_SICK_BYSTATUS(int STATUS, int typekeyword, string keyword, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_SICK> sQLServer = new OracleServerConnection<CMS_SICK>();
                return sQLServer.SelectQueryCommand("SP_CMS_SICK_SELECT_BYSTATUS", STATUS, typekeyword, keyword,  PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll_CMS_SICK_BYSTATUS: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_SICK> sQLServer = new OracleServerConnection<CMS_SICK>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SICK_Publich", id, PARTNERID);
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

        public string Update(CMS_SICK entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_SICK> sQLServer = new OracleServerConnection<CMS_SICK>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SICK_UPDATE", entity.ID, entity.SICK_NAME, entity.SICK_DESC, entity.SICK_SYMPTOM, entity.SICK_HEALING, entity.SICK_NOTE, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.SICK_STATUS, entity.PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Update(CMS_SICK entity)
        {
            throw new NotImplementedException();
        }
    }
}
