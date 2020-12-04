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
    public class ImpCMS_PATIENTINFO : ICMS_PATIENTINFO
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string DeleteCMS_PATIENTINFO(int pid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO> sQLServer = new OracleServerConnection<CMS_PATIENTINFO>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENTINFO_DELETE", pid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_PATIENTINFO: " + pid + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_PATIENTINFO_Weirdo(int pid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO> sQLServer = new OracleServerConnection<CMS_PATIENTINFO>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENTINFO_DELWeirdo", pid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_PATIENTINFO: " + pid + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_PATIENTINFO> GetAllCMS_PATIENTINFO(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO> sQLServer = new OracleServerConnection<CMS_PATIENTINFO>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENTINFO_SELECTALL", partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_PATIENTINFO: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO> GetCMS_PARTNERByName(string PATIENTNAME, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO> sQLServer = new OracleServerConnection<CMS_PATIENTINFO>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENTINFO_BYNAME", PATIENTNAME, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_PATIENTINFO: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO> GetCMS_PATIENTINFO_ByALL(DateTime start, DateTime end, string keyword, int typeKeyword, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO> sQLServer = new OracleServerConnection<CMS_PATIENTINFO>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENTINFO_BYKeyword", start, end, keyword, typeKeyword, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_ByALL: " + ex.ToString());
                return null;
            }
        }

        public CMS_Core.Models.MedicalExaminationViewModel GetCMS_PATIENTINFO_ALLBYSID(Int64 sid,  int queueid, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_Core.Models.MedicalExaminationViewModel> sQLServer = new OracleServerConnection<CMS_Core.Models.MedicalExaminationViewModel>();
                return sQLServer.SelectPatientInfoAllQueryCommand("sp_cms_patient_all_bysid", sid, queueid, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_ALLBYSID: " + ex.ToString());
                return null;
            }
        }

        public CMS_Core.Models.PatientAddViewModel GetCMS_PATIENTINFO_CreateOrderBYPID(Int64 pid, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_Core.Models.PatientAddViewModel> sQLServer = new OracleServerConnection<CMS_Core.Models.PatientAddViewModel>();
                return sQLServer.SelectCreateOrderByIDQueryCommand("sp_cms_createOder_bypid", pid, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_CreateOrderBYSID: " + ex.ToString());
                return null;
            }
        }

        public CMS_Core.Models.PatientAddViewModel GetCMS_PATIENTINFO_CreateOrderBYSID(Int64 sid, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_Core.Models.PatientAddViewModel> sQLServer = new OracleServerConnection<CMS_Core.Models.PatientAddViewModel>();
                return sQLServer.SelectCreateOrderBySIDQueryCommand("sp_cms_createorder_bysid", sid, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_CreateOrderBYSID: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_PATIENTINFO> GetCMS_PATIENTINFO_BYID(string PID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO> sQLServer = new OracleServerConnection<CMS_PATIENTINFO>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENTINFO_BYPID", PID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_PATIENTINFO: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_PATIENTINFO(CMS_PATIENTINFO _PATIENTINFO)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENTINFO> sQLServer = new OracleServerConnection<CMS_PATIENTINFO>();
                return sQLServer.ExecuteInsert("SP_CMS_PATIENTINFO_INSERT", _PATIENTINFO.PATIENTNAME, _PATIENTINFO.SEX, _PATIENTINFO.AGE, _PATIENTINFO.ADDRESS, _PATIENTINFO.PHONE, _PATIENTINFO.PHONE1, _PATIENTINFO.SONHA, _PATIENTINFO.HEM, _PATIENTINFO.NGACH, _PATIENTINFO.NGO, _PATIENTINFO.STREET, _PATIENTINFO.PRECINCT, _PATIENTINFO.DISTRICT, _PATIENTINFO.CITY, _PATIENTINFO.EMAILADDRESS, _PATIENTINFO.EMAILRESULT, _PATIENTINFO.GHICHU, _PATIENTINFO.STATUS, _PATIENTINFO.CREATEDATE, _PATIENTINFO.CREATEBY, _PATIENTINFO.UPATEDATE, _PATIENTINFO.UPDATEBY, _PATIENTINFO.PARTNERID,   _PATIENTINFO.BIRTHDAY, _PATIENTINFO.RELATIONSHIP, _PATIENTINFO.IDENTIFICATION, _PATIENTINFO.IDENTIFICATION_DATE, _PATIENTINFO.IDENTIFICATION_ISSUED, _PATIENTINFO.PASSPORT, _PATIENTINFO.PASSPORT_DATE, _PATIENTINFO.PASSPORT_ISSUED, _PATIENTINFO.PARENTS_INFO, _PATIENTINFO.INSURANCE_CARD, _PATIENTINFO.INSURANCE_CARD_PLACE, _PATIENTINFO.INSURANCE_CARD_START, _PATIENTINFO.INSURANCE_CARD_END, _PATIENTINFO.partnerid_Code, _PATIENTINFO.REASON, _PATIENTINFO.PATIENTIMAGE, _PATIENTINFO.weight);
            }
            catch (Exception ex)
            {
                logError.Info("InsertCMS_PATIENTINFO: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string UpdateCMS_PATIENTINFO(CMS_PATIENTINFO _PATIENTINFO)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENTINFO> sQLServer = new OracleServerConnection<CMS_PATIENTINFO>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENTINFO_update", _PATIENTINFO.PID, _PATIENTINFO.PATIENTNAME, _PATIENTINFO.SEX, _PATIENTINFO.AGE, _PATIENTINFO.ADDRESS, _PATIENTINFO.PHONE, _PATIENTINFO.PHONE1, _PATIENTINFO.SONHA, _PATIENTINFO.HEM, _PATIENTINFO.NGACH, _PATIENTINFO.NGO, _PATIENTINFO.STREET, _PATIENTINFO.PRECINCT, _PATIENTINFO.DISTRICT, _PATIENTINFO.CITY, _PATIENTINFO.EMAILADDRESS, _PATIENTINFO.EMAILRESULT, _PATIENTINFO.GHICHU, _PATIENTINFO.STATUS, _PATIENTINFO.CREATEDATE, _PATIENTINFO.CREATEBY, _PATIENTINFO.UPATEDATE, _PATIENTINFO.UPDATEBY, _PATIENTINFO.PARTNERID,   _PATIENTINFO.BIRTHDAY, _PATIENTINFO.RELATIONSHIP, _PATIENTINFO.IDENTIFICATION, _PATIENTINFO.IDENTIFICATION_DATE, _PATIENTINFO.IDENTIFICATION_ISSUED, _PATIENTINFO.PASSPORT, _PATIENTINFO.PASSPORT_DATE, _PATIENTINFO.PASSPORT_ISSUED, _PATIENTINFO.PARENTS_INFO, _PATIENTINFO.INSURANCE_CARD, _PATIENTINFO.INSURANCE_CARD_PLACE, _PATIENTINFO.INSURANCE_CARD_START, _PATIENTINFO.INSURANCE_CARD_END, _PATIENTINFO.partnerid_Code, _PATIENTINFO.REASON, _PATIENTINFO.PATIENTIMAGE, _PATIENTINFO.weight);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_PATIENTINFO: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
