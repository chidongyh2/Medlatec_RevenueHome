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
    public class ImpCMS_PATIENT_SERVICE : ICMS_PATIENT_SERVICE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_PATIENT_SERVICE entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.ExecuteInsert("SP_cms_patient_service_INSERT", entity.PATIENT_ID, entity.PID, entity.SERVICE_ID, entity.SERVICE_PRICE, entity.SERVICE_NOTE, entity.SERVICE_RESULT, entity.IS_PRINT, entity.PRINT_DATE, entity.CREATEBY, entity.CREATE_DATE, PARTNERID, entity.UPDATEBY, entity.UPDATE_DATE, entity.SERVICE_NAME, entity.EXAMINATION_CONTENT, entity.IS_PRINT_RESULT, entity.PRINT_RESULT_DATE, entity.COUNT, entity.DOCTOR_ID, entity.DOCTOR_NAME, entity.IS_PAY, entity.SERVICETYPE, entity.VISIT_PATIENT_ID, entity.SERVICE_GROUP_ID);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        /// <summary>
        /// Chèn thêm dịch vụ
        /// </summary>      

        /// <returns></returns>        
        /// 
        public string AddService(CMS_PATIENT_SERVICE entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.ExecuteInsert("SP_cms_patient_service_add", entity.PATIENT_ID, entity.PID, entity.SERVICE_ID, entity.SERVICE_PRICE, entity.SERVICE_NOTE, entity.SERVICE_RESULT, entity.IS_PRINT, entity.PRINT_DATE, entity.CREATEBY, entity.CREATE_DATE, PARTNERID, entity.UPDATEBY, entity.UPDATE_DATE, entity.SERVICE_NAME, entity.EXAMINATION_CONTENT, entity.IS_PRINT_RESULT, entity.PRINT_RESULT_DATE, entity.COUNT, entity.DOCTOR_ID, entity.DOCTOR_NAME, entity.IS_PAY, entity.SERVICE_GROUP_ID);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(CMS_PATIENT_SERVICE entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_SERVICE_DELETE", entity.ID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteNotInList(Int64 sid, Int64 pid, string listServiceID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.ExecuteNonQuery("sp_cms_patient_service_delList", sid, pid, listServiceID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + sid + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string Delete(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_SERVICE_DELETE", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteBySID(Int64 sid, Int64 pid, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.ExecuteNonQuery("sp_patient_service_DelBySID", sid, pid,PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteBySID: " + sid + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string DeleteBySIDAndServiceID(Int64 sid, Int64 pid,int service_id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.ExecuteNonQuery("sp_patientservice_DelServiceID", sid, pid, service_id,PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteBySID: " + sid + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public CMS_PATIENT_SERVICE Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                var data = sQLServer.SelectQueryCommand("SP_CMS_PATIENT_SERVICE_BYPID", id, PARTNERID);
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

        public List<CMS_PATIENT_SERVICE> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_SERVICE_ALL", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_SERVICE> GetCMS_PATIENT_SERVICE_BYSID(Int64 sid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_SERVICE_BYSID", sid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_SERVICE> GetCMS_PATIENT_SERVICE_BYSIDALL(Int64 sid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_PATIENT_SERVICE_BYSID_ALL", sid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_PATIENT_SERVICE> GetSP_PATIENT_SERVICE_REPORT(DateTime tungay, DateTime denngay, int DOCTOR_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_PATIENT_SERVICE_REPORT", tungay, denngay, DOCTOR_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_SERVICE> GetCMS_PATIENT_SERVICE_BYSID_REFUND(Int64 sid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_SERVICE_BYSID_Refund", sid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_SERVICE> GetCMS_PATIENT_SERVICE_BYSID_NOPAY(Int64 sid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_PATIENT_SERVICE_BYSID_NOPAY", sid, partnerid);
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

        public string Update(CMS_PATIENT_SERVICE entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.ExecuteNonQuery("SP_cms_patient_service_UPDATE", entity.ID, entity.PATIENT_ID, entity.PID, entity.SERVICE_ID, entity.SERVICE_PRICE, entity.SERVICE_NOTE, entity.SERVICE_RESULT, entity.IS_PRINT, entity.PRINT_DATE, entity.CREATEBY, entity.CREATE_DATE, entity.PARTNERID, entity.UPDATEBY, entity.UPDATE_DATE, entity.SERVICE_NAME, entity.EXAMINATION_CONTENT, entity.IS_PRINT_RESULT, entity.PRINT_RESULT_DATE, entity.COUNT, entity.DOCTOR_ID, entity.DOCTOR_NAME, entity.IS_PAY, entity.SERVICETYPE, entity.SERVICE_GROUP_ID);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public CMS_PATIENT_SERVICE Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_SERVICE> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_PATIENT_SERVICE entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_PATIENT_SERVICE entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_PATIENT_SERVICE entity)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
