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
    public class ImpCMS_PATIENT_SERVICE_REFUND : ICMS_PATIENT_SERVICE_REFUND
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_PATIENT_SERVICE_REFUND entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.ExecuteInsert("sp_service_refund_insert", entity.SID, entity.PID, entity.SERVICE_ID, entity.SERVICE_PRICE, entity.SERVICE_NOTE, entity.CREATEBY, entity.CREATE_DATE, entity.PARTNERID, entity.UPDATEBY, entity.UPDATE_DATE, entity.SERVICE_NAME, entity.SERVICETYPE, entity.COUNT, entity.STATUS);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_Category: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(CMS_PATIENT_SERVICE_REFUND entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.ExecuteNonQuery("sp_SERVICE_REFUND_delete", entity.ID, PARTNERID);
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
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.ExecuteNonQuery("sp_SERVICE_REFUND_delete", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public CMS_PATIENT_SERVICE_REFUND Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_REFUND> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_REFUND>();
                var data = sQLServer.SelectQueryCommand("SP_SERVICE_REFUND_BYID", id, PARTNERID);
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

        public List<CMS_PATIENT_SERVICE_REFUND> GetCMS_PATIENT_SERVICE_REFUNDByCODE(DateTime startdate, DateTime enddate, string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_REFUND> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_REFUND>();
                return sQLServer.SelectQueryCommand("SP_SERVICE_REFUND_BYSID", startdate, enddate, code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENT_SERVICE_REFUNDByCODE: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_SERVICE_REFUND> GetBYRefundBySID(int sid, int PARTNERID)
        {

            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_REFUND> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_REFUND>();
                return sQLServer.SelectQueryCommand("SP_SERVICE_REFUND_BYSID_ALL", sid, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetBYRefundBySID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_SERVICE_REFUND> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_REFUND> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_REFUND>();
                return sQLServer.SelectQueryCommand("SP_SERVICE_REFUND_BYALL", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.ExecuteNonQuery("SP_SERVICE_REFUND_PUBLIC", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(CMS_PATIENT_SERVICE_REFUND entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.ExecuteNonQuery("sp_service_refund_update", entity.ID, entity.SID, entity.PID, entity.SERVICE_ID, entity.SERVICE_PRICE, entity.SERVICE_NOTE, entity.CREATEBY, entity.CREATE_DATE, entity.PARTNERID, entity.UPDATEBY, entity.UPDATE_DATE, entity.SERVICE_NAME, entity.SERVICETYPE, entity.COUNT, entity.STATUS);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public CMS_PATIENT_SERVICE_REFUND Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_SERVICE_REFUND> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_PATIENT_SERVICE_REFUND entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_PATIENT_SERVICE_REFUND entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_PATIENT_SERVICE_REFUND entity)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
