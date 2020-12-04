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
    public class ImpCMS_PATIENT_SERVICE_RESULT : ICMS_PATIENT_SERVICE_RESULT
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_PATIENT_SERVICE_RESULT entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.ExecuteInsert("SP_SERVICE_RESULT_INSERT", entity.PATIENT_ID, entity.PID, entity.SERVICE_ID, entity.SERVICE_PRICE, entity.SERVICE_NOTE, entity.SERVICE_RESULT, entity.CREATEBY, entity.CREATE_DATE, PARTNERID, entity.UPDATEBY, entity.UPDATE_DATE, entity.SERVICE_NAME, entity.EXAMINATION_CONTENT, entity.SERVICE_ADVICE, entity.MAINSICK, entity.SECONDARY_SICK, entity.HISTORY_SICK, entity.CPS_ID, entity.DOCTOR_ID, entity.DOCTOR_NAME, entity.SERVICETYPE, entity.WEIRDO, entity.APPOINTMENT);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Add(CMS_PATIENT_SERVICE_RESULT entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_PATIENT_SERVICE_RESULT entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.ExecuteNonQuery("SP_PATIENT_SERVICE_RESULT_DEL", entity.ID, PARTNERID);
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
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.ExecuteNonQuery("SP_PATIENT_SERVICE_RESULT_DEL", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(CMS_PATIENT_SERVICE_RESULT entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CMS_PATIENT_SERVICE_RESULT Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                var data = sQLServer.SelectQueryCommand("SP_PATIENT_SERVICE_RESULT_BYID", id, PARTNERID);
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

        public CMS_PATIENT_SERVICE_RESULT Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_SERVICE_RESULT> GetAll(int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_SERVICE_RESULT> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_SERVICE_RESULT> GetCMS_PATIENT_SERVICE_BYCPS_ID(long CPS_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.SelectQueryCommand("SP_SERVICE_RESULT_BYCPS_ID", CPS_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_SERVICE_RESULT> GetCMS_PATIENT_SERVICE_BYSID(long sid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.SelectQueryCommand("SP_PATIENT_SERVICE_RESULT_SID", sid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_PATIENT_SERVICE_RESULT entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.ExecuteNonQuery("SP_SERVICE_RESULT_UPDATE", entity.ID, entity.PATIENT_ID, entity.PID, entity.SERVICE_ID, entity.SERVICE_PRICE, entity.SERVICE_NOTE, entity.SERVICE_RESULT, entity.CREATEBY, entity.CREATE_DATE, entity.PARTNERID, entity.UPDATEBY, entity.UPDATE_DATE, entity.SERVICE_NAME, entity.EXAMINATION_CONTENT, entity.SERVICE_ADVICE, entity.MAINSICK, entity.SECONDARY_SICK, entity.HISTORY_SICK, entity.CPS_ID, entity.SERVICETYPE, entity.WEIRDO, entity.APPOINTMENT);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Update(CMS_PATIENT_SERVICE_RESULT entity)
        {
            throw new NotImplementedException();
        }
    }
}
