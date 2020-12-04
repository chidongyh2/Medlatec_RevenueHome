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
    public class ImpCMS_MEDICINE_REFUND_STORE : ICMS_MEDICINE_REFUND_STORE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_MEDICINE_REFUND_STORE entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.ExecuteInsert("sp_REFUND_STORE_insert", entity.CMS_MEDICINE_EXPORT_STORE_ID, entity.TOTAL_PRICE_REFUND, entity.CUSTOMER_NAME, entity.CUSTOMER_MOBILE, entity.CUSTOMER_EMAIL, entity.CUSTOMER_GENDER, entity.STATUS, entity.PARTNERID, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.CMS_MEDICINE_EXPORT_STORE_CODE, entity.NOTE);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_Category: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(CMS_MEDICINE_REFUND_STORE entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.ExecuteNonQuery("SP_REFUND_STORE_DELETE", entity.ID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_MEDICINE_REFUND_STORE> GetCMS_MEDICINE_REFUND_STOREByCODE(DateTime startdate, DateTime enddate, string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.SelectQueryCommand("SP_REFUND_STORE_BYCODE", startdate, enddate, code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_REFUND_STOREByCODE: " + ex.ToString());
                return null;
            }
        }



        public string Delete(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.ExecuteNonQuery("SP_REFUND_STORE_DELETE", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public CMS_MEDICINE_REFUND_STORE Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                var data = sQLServer.SelectQueryCommand("SP_refund_detail_BYID", id, PARTNERID);
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

        public CMS_MEDICINE_REFUND_STORE GetBYEXPORT_STORE_ID(int EXPORT_STORE_ID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                var data = sQLServer.SelectQueryCommand("SP_refund_detail_EXPORTSTOREID", EXPORT_STORE_ID, PARTNERID);
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


        public CMS_MEDICINE_REFUND_STORE GetBYEXPORT_STORE_CODE(string EXPORT_STORE_CODE, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                var data = sQLServer.SelectQueryCommand("SP_refunddetail_STORECODE", EXPORT_STORE_CODE, PARTNERID);
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



        public List<CMS_MEDICINE_REFUND_STORE> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.SelectQueryCommand("SP_MEDICINE_REFUND_STORE_ALL", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE_REFUND_STORE> GetCMS_MEDICINE_REFUND_STOREByALL(DateTime startdate, DateTime enddate, string code, int status, int partnerid, int partneridUser)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.SelectQueryCommand("SP_REFUND_STORE_BYALL", startdate, enddate, code, status, partnerid, partneridUser);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_STOREByALL: " + ex.ToString());
                return null;
            }
        }


        public string Publish(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_STORE>();
                return sQLServer.ExecuteNonQuery("sp_refund_store_public", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(CMS_MEDICINE_REFUND_STORE entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.ExecuteNonQuery("sp_refund_store_update", entity.ID, entity.CMS_MEDICINE_EXPORT_STORE_ID, entity.TOTAL_PRICE_REFUND, entity.CUSTOMER_NAME, entity.CUSTOMER_MOBILE, entity.CUSTOMER_EMAIL, entity.CUSTOMER_GENDER, entity.STATUS, entity.PARTNERID, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.CMS_MEDICINE_EXPORT_STORE_CODE);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public CMS_MEDICINE_REFUND_STORE Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_MEDICINE_REFUND_STORE> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_MEDICINE_REFUND_STORE entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_MEDICINE_REFUND_STORE entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_MEDICINE_REFUND_STORE entity)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
