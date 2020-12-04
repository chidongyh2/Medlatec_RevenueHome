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
    public class ImpCMS_PATIENT_ALLERGY : ICMS_PATIENT_ALLERGY
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string DeleteCMS_PATIENT_ALLERGY(int id, int partnerid)
        {
            try
            {
                OracleServerConnection<cms_Category> sQLServer = new OracleServerConnection<cms_Category>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_ALLERGY_DELETE", id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_PATIENT_ALLERGY: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_PATIENT_ALLERGY> GetCMS_PATIENT_ALLERGY(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_ALLERGY> sQLServer = new OracleServerConnection<CMS_PATIENT_ALLERGY>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_ALLERGY_ALL", partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_ALLERGY: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_ALLERGY> GetCMS_PATIENT_ALLERGYByID(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_ALLERGY> sQLServer = new OracleServerConnection<CMS_PATIENT_ALLERGY>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_ALLERGY_BYID", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_ALLERGYByID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_ALLERGY> GetCMS_PATIENT_ALLERGYByName(string Name, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_ALLERGY> sQLServer = new OracleServerConnection<CMS_PATIENT_ALLERGY>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_ALLERGY_BYNAME", Name, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_ALLERGYByName: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_ALLERGY> GetCMS_PATIENT_ALLERGYByPID(Int64 pid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_ALLERGY> sQLServer = new OracleServerConnection<CMS_PATIENT_ALLERGY>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_ALLERGY_BYPID", pid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_ALLERGYByPID: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_PATIENT_ALLERGY(CMS_PATIENT_ALLERGY _PATIENT_ALLERGY)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_ALLERGY> sQLServer = new OracleServerConnection<CMS_PATIENT_ALLERGY>();
                return sQLServer.ExecuteInsert("SP_CMS_PATIENT_ALLERGY_Insert", _PATIENT_ALLERGY.ALLERGY_NAME, _PATIENT_ALLERGY.ALLERGY_TYPE, _PATIENT_ALLERGY.CREATEDATE, _PATIENT_ALLERGY.UPDATEBY, _PATIENT_ALLERGY.UPDATEDATE, _PATIENT_ALLERGY.PARTNERID, _PATIENT_ALLERGY.CREATEBY, _PATIENT_ALLERGY.ALLERGY_NOTE, _PATIENT_ALLERGY.PID);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_Category: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string UpdateCMS_PATIENT_ALLERGY(CMS_PATIENT_ALLERGY _PATIENT_ALLERGY)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_ALLERGY> sQLServer = new OracleServerConnection<CMS_PATIENT_ALLERGY>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_ALLERGY_Update", _PATIENT_ALLERGY.ID,  _PATIENT_ALLERGY.ALLERGY_NAME, _PATIENT_ALLERGY.ALLERGY_TYPE, _PATIENT_ALLERGY.CREATEDATE, _PATIENT_ALLERGY.UPDATEBY, _PATIENT_ALLERGY.UPDATEDATE, _PATIENT_ALLERGY.PARTNERID, _PATIENT_ALLERGY.CREATEBY, _PATIENT_ALLERGY.ALLERGY_NOTE, _PATIENT_ALLERGY.PID);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_PATIENT_ALLERGY: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
