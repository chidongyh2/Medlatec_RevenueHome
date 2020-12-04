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
    public class ImpCMS_PATIENT : ICMS_PATIENT
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

     



        public List<CMS_PATIENT> GetAllCMS_PATIENT(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_BYALL", partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_PATIENT: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT> GetCMS_PATIENTByPID(string PID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_BYPID", PID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTByName: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT> GetCMS_PATIENTByPID_PRESCRIPTION(string PID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.SelectQueryCommand("SP_PATIENT_BYPID_PRESCRIPTION", PID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTByName: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_PATIENT> GetCMS_PATIENT_BYSID(string SID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_BYSID", SID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_BYSID: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_PATIENT(CMS_PATIENT _PATIENT)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.ExecuteInsert("SP_CMS_PATIENT_Insert", _PATIENT.SEQ, _PATIENT.DATEIN, _PATIENT.DOCTORID, _PATIENT.PID, _PATIENT.LOCATIONID, _PATIENT.OBJECTID, _PATIENT.DIAGNOSTIC, _PATIENT.PRINTOUT, _PATIENT.FULLRESULT, _PATIENT.RETURNRESULT, _PATIENT.PRINTTIME, _PATIENT.INVOICE, _PATIENT.INVOICETIME, _PATIENT.BED, _PATIENT.USERGETTEST, _PATIENT.GETTESTTIME, _PATIENT.SUMMONEY,   _PATIENT.RETURNTIME, _PATIENT.VALIDTIME, _PATIENT.PAIDBYCARD, _PATIENT.PAIDINCASH, _PATIENT.SENDRESULT, _PATIENT.RESULTRATE, _PATIENT.TAIKHAM, _PATIENT.TRANGTHAI, _PATIENT.TUVAN, _PATIENT.DEFINEMONEYDOCTOR, _PATIENT.POS, _PATIENT.USERCHECK, _PATIENT.USERVALID2, _PATIENT.RETURNTYPE, _PATIENT.PARTNERID, _PATIENT.GHICHU, _PATIENT.DISCOUNT, _PATIENT.MONEYGIVE, _PATIENT.TYPECUSTOMERID, _PATIENT.REASON, _PATIENT.SERVICE_GROUPID, _PATIENT.SERVICEID, _PATIENT.DEPARTMENTSID, _PATIENT.SUMMONEYPAY, _PATIENT.LOCATIONIDNEW, _PATIENT.VISIT_PATIENT_ID);
            }
            catch (Exception ex)
            {
                logError.Info("InsertCMS_PATIENT: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public List<CMS_PATIENT> GetCMS_PATIENT_ByALL(DateTime start, DateTime end, string keyword, int typeKeyword, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_BYKeyword", start, end, keyword, typeKeyword, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_ByALL: " + ex.ToString());
                return null; 
            }
        }

        public List<CMS_PATIENTINFO_TOTAL> GetWaitingForMedical_BYALL(DateTime start, DateTime end, string keyword, int typeKeyword,int SERVICETYPE, int locationid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_TOTAL> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_TOTAL>();
                return sQLServer.SelectQueryCommand("SP_WaitingForMedical_BYKeyword", start, end, keyword, typeKeyword, SERVICETYPE, locationid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_ByALL: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO_TOTAL> GetGroupService_BYALL(DateTime start, DateTime end, string keyword, int typeKeyword, int SERVICE_GROUPID,   int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_TOTAL> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_TOTAL>();
                return sQLServer.SelectQueryCommand("sp_GroupService_bykeyword", start, end, keyword, typeKeyword, SERVICE_GROUPID,  partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_ByALL: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO_TOTAL> GetWaitingForMedical_BYSID( int sid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_TOTAL> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_TOTAL>();
                return sQLServer.SelectQueryCommand("SP_WaitingForMedical_BYSID", sid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetWaitingForMedical_BYSID: " + ex.ToString());
                return null;
            }
        }



        public string UpdateCMS_PATIENT(CMS_PATIENT _PATIENT)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_Update", _PATIENT.SID, _PATIENT.SEQ, _PATIENT.DATEIN, _PATIENT.DOCTORID, _PATIENT.PID, _PATIENT.LOCATIONID, _PATIENT.OBJECTID, _PATIENT.DIAGNOSTIC, _PATIENT.PRINTOUT, _PATIENT.FULLRESULT, _PATIENT.RETURNRESULT, _PATIENT.PRINTTIME, _PATIENT.INVOICE, _PATIENT.INVOICETIME, _PATIENT.BED, _PATIENT.USERGETTEST, _PATIENT.GETTESTTIME, _PATIENT.SUMMONEY,   _PATIENT.RETURNTIME, _PATIENT.VALIDTIME, _PATIENT.PAIDBYCARD, _PATIENT.PAIDINCASH, _PATIENT.SENDRESULT, _PATIENT.RESULTRATE, _PATIENT.TAIKHAM, _PATIENT.TRANGTHAI, _PATIENT.TUVAN, _PATIENT.DEFINEMONEYDOCTOR, _PATIENT.POS, _PATIENT.USERCHECK, _PATIENT.USERVALID2, _PATIENT.RETURNTYPE, _PATIENT.PARTNERID, _PATIENT.GHICHU, _PATIENT.DISCOUNT, _PATIENT.MONEYGIVE, _PATIENT.TYPECUSTOMERID, _PATIENT.REASON, _PATIENT.SERVICE_GROUPID, _PATIENT.SERVICEID, _PATIENT.DEPARTMENTSID, _PATIENT.SUMMONEYPAY, _PATIENT.LOCATIONIDNEW, _PATIENT.VISIT_PATIENT_ID);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_PATIENT: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string UpdateRoomCMS_PATIENT(Int64 sid, int LOCATIONID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.ExecuteNonQuery("sp_cms_patient_update_Room", sid, LOCATIONID);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateRoomCMS_PATIENT: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string UpdateChanDoanCMS_PATIENT(Int64 sid, string chandoan , DateTime TAIKHAM, string GHICHU)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.ExecuteNonQuery("sp_cms_patient_update_ChanDoan", sid, chandoan, TAIKHAM, GHICHU);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateChanDoanCMS_PATIENT: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string UpdateListRoomCMS_PATIENT(Int64 sid, string LISTLOCATIONID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.ExecuteNonQuery("sp_patient_update_ListRoom", sid, LISTLOCATIONID);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateListRoomCMS_PATIENT: " + ex.ToString());
                return result = string.Empty;
            }
        }


    }
}
