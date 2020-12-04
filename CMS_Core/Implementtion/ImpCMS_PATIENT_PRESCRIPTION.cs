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
    public class ImpCMS_PATIENT_PRESCRIPTION : ICMS_PATIENT_PRESCRIPTION
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_PATIENT_PRESCRIPTION entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.ExecuteInsert("SP_PATIENT_PRESCRIPTION_INSERT", entity.SID, entity.PID, entity.CPS_ID, entity.DOCTOR_NAME, entity.DOCTOR_ID, entity.MEDICINE_ID, entity.MEDICINE_CODE, entity.MEDICINE_NAME, PARTNERID, entity.CREATEBY, entity.CREATE_DATE, entity.UPDATEBY, entity.UPDATE_DATE, entity.MEDICINE_USAGE, entity.MEDICINE_UNIT, entity.COUNT);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(CMS_PATIENT_PRESCRIPTION entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_PRESCRIPTION> sQLServer = new OracleServerConnection<CMS_PATIENT_PRESCRIPTION>();
                return sQLServer.ExecuteNonQuery("SP_PATIENT_PRESCRIPTION_DELETE", entity.ID, PARTNERID);
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
                OracleServerConnection<CMS_PATIENT_PRESCRIPTION> sQLServer = new OracleServerConnection<CMS_PATIENT_PRESCRIPTION>();
                return sQLServer.ExecuteNonQuery("SP_PATIENT_PRESCRIPTION_DELETE", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int sid, int pid, int MEDICINE_ID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_PRESCRIPTION> sQLServer = new OracleServerConnection<CMS_PATIENT_PRESCRIPTION>();
                return sQLServer.ExecuteNonQuery("SP_PRESCRIPTION_DEL_SID", sid, pid, MEDICINE_ID,  PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + sid + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public CMS_PATIENT_PRESCRIPTION Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_PRESCRIPTION> sQLServer = new OracleServerConnection<CMS_PATIENT_PRESCRIPTION>();
                var data = sQLServer.SelectQueryCommand("SP_PATIENT_PRESCRIPTION_BYID", id, PARTNERID);
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

        public List<CMS_PATIENT_PRESCRIPTION> GetAll(int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_PRESCRIPTION> GetCMS_PATIENT_PRESCRIPTION_BYCPS_ID(long CPS_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_PRESCRIPTION> sQLServer = new OracleServerConnection<CMS_PATIENT_PRESCRIPTION>();
                return sQLServer.SelectQueryCommand("SP_PATIENT_PRESCRIPTION_CPS_ID", CPS_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_PRESCRIPTION> GetCMS_PATIENT_PRESCRIPTION_BYSID_ANDDORTOR(long sid, int DOCTOR_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_PRESCRIPTION> sQLServer = new OracleServerConnection<CMS_PATIENT_PRESCRIPTION>();
                return sQLServer.SelectQueryCommand("SP_PRESCRIPTION_SID_DOCTOR", sid, DOCTOR_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_PRESCRIPTION> GetCMS_PATIENT_PRESCRIPTION_BYSID(long sid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_PRESCRIPTION> sQLServer = new OracleServerConnection<CMS_PATIENT_PRESCRIPTION>();
                return sQLServer.SelectQueryCommand("SP_PATIENT_PRESCRIPTION_SID", sid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_PRESCRIPTION> GetPRESCRIPTION_REPORT(DateTime tungay, DateTime denngay, int DOCTOR_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_PRESCRIPTION> sQLServer = new OracleServerConnection<CMS_PATIENT_PRESCRIPTION>();
                return sQLServer.SelectQueryCommand("SP_PRESCRIPTION_REPORT", tungay, denngay, DOCTOR_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetPRESCRIPTION_REPORT: " + ex.ToString());
                return null;
            }
        }


        public string Publish(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_PATIENT_PRESCRIPTION entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.ExecuteNonQuery("SP_PATIENT_PRESCRIPTION_UPDATE", entity.ID, entity.SID, entity.PID, entity.CPS_ID, entity.DOCTOR_NAME, entity.DOCTOR_ID, entity.MEDICINE_ID, entity.MEDICINE_CODE, entity.MEDICINE_NAME, entity.PARTNERID, entity.CREATEBY, entity.CREATE_DATE, entity.UPDATEBY, entity.UPDATE_DATE, entity.MEDICINE_USAGE, entity.MEDICINE_UNIT, entity.COUNT);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public CMS_PATIENT_PRESCRIPTION Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_PRESCRIPTION> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_PATIENT_PRESCRIPTION entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_PATIENT_PRESCRIPTION entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_PATIENT_PRESCRIPTION entity)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
