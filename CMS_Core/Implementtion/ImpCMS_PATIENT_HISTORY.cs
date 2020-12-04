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
    public class ImpCMS_PATIENT_HISTORY : ICMS_PATIENT_HISTORY
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string DeleteCMS_PATIENT_HISTORY(int id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_HISTORY> sQLServer = new OracleServerConnection<CMS_PATIENT_HISTORY>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_HISTORY_DELETE", id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_PATIENT_HISTORY: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_PATIENT_HISTORY> GetCMS_PATIENT_HISTORY(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_HISTORY> sQLServer = new OracleServerConnection<CMS_PATIENT_HISTORY>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_HISTORY_ALL", partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_HISTORY: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_HISTORY> GetCMS_PATIENT_HISTORYByID(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_HISTORY> sQLServer = new OracleServerConnection<CMS_PATIENT_HISTORY>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_HISTORY_BYID", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_HISTORYByID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_HISTORY> GetCMS_PATIENT_HISTORYByName(string Name, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_HISTORY> sQLServer = new OracleServerConnection<CMS_PATIENT_HISTORY>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_HISTORY_BYName", Name, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_HISTORYByName: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_HISTORY> GetCMS_PATIENT_HISTORYByPID(Int64 pid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_HISTORY> sQLServer = new OracleServerConnection<CMS_PATIENT_HISTORY>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_HISTORY_BYPID", pid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_HISTORYByPID: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_PATIENT_HISTORY(CMS_PATIENT_HISTORY _PATIENT_HISTORY)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_HISTORY> sQLServer = new OracleServerConnection<CMS_PATIENT_HISTORY>();
                return sQLServer.ExecuteInsert("SP_CMS_PATIENT_HISTORY_Insert", _PATIENT_HISTORY.SICKNAME, _PATIENT_HISTORY.SICKYEAR, _PATIENT_HISTORY.NOTE, _PATIENT_HISTORY.PARTNERID, _PATIENT_HISTORY.CREATEBY, _PATIENT_HISTORY.CREATEDATE, _PATIENT_HISTORY.UPDATEBY, _PATIENT_HISTORY.UPDATEDATE, _PATIENT_HISTORY.PID);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_Category: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string UpdateCMS_PATIENT_HISTORY(CMS_PATIENT_HISTORY _PATIENT_HISTORY)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_ALLERGY> sQLServer = new OracleServerConnection<CMS_PATIENT_ALLERGY>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_HISTORY_Update", _PATIENT_HISTORY.ID, _PATIENT_HISTORY.SICKNAME, _PATIENT_HISTORY.SICKYEAR, _PATIENT_HISTORY.NOTE, _PATIENT_HISTORY.PARTNERID, _PATIENT_HISTORY.CREATEBY, _PATIENT_HISTORY.CREATEDATE, _PATIENT_HISTORY.UPDATEBY, _PATIENT_HISTORY.UPDATEDATE, _PATIENT_HISTORY.PID);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_PATIENT_ALLERGY: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
