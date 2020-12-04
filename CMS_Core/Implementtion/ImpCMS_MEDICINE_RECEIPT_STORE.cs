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
    public class ImpCMS_MEDICINE_RECEIPT_STORE : ICMS_MEDICINE_RECEIPT_STORE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string DeleteCMS_MEDICINE_RECEIPT_STORE(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.ExecuteNonQuery("SP_RECEIPT_STORE_DELETE", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_GROUP_MEDICINE: " + Id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_MEDICINE_RECEIPT_STORE(string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.ExecuteNonQuery("SP_RECEIPT_STORE_DELETE_BYCODE", code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_GROUP_MEDICINE: " + code + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_MEDICINE_RECEIPT_STORE> GetCMS_MEDICINE_RECEIPT_STORE(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_STORE_ALL", partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_STORE: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE_RECEIPT_STORE> GetReportCMS_MEDICINE_RECEIPT_STOREByDate(DateTime start, DateTime end, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_STORE_ByDate", start, end, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_STORE: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE_RECEIPT_STORE> GetCMS_MEDICINE_RECEIPT_STOREByCODE(DateTime startdate, DateTime enddate, string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_STORE_BYCODE", startdate, enddate, code,  partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_STORE: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_MEDICINE_RECEIPT_STORE> GetCMS_MEDICINE_RECEIPT_STOREBYALL(DateTime startdate, DateTime enddate, string code, int status, int partnerid, int partnerid_User)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_STORE_BYALL", startdate, enddate, code, status, partnerid, partnerid_User);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_STORE: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_MEDICINE_RECEIPT_STORE> GetCMS_MEDICINE_RECEIPT_STOREByCODE(  string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.SelectQueryCommand("MEDICINE_RECEIPT_STORE_BYCODE",   code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_STORE: " + ex.ToString());
                return null;
            }
        }



        public Int64 GET_MEDICINE_RECEIPT_STORE_SEQ()
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                List<CMS_MEDICINE_RECEIPT_STORE> result = sQLServer.SelectQuery("  SELECT MEDICINE_RECEIPT_STORE_SEQ.nextval as ID  FROM DUAL");
                if(result != null)
                {
                    if(result.Count > 0)
                    {
                     return   result[0].ID;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_STORE: " + ex.ToString());
                return 0;
            }
        }


        public List<CMS_MEDICINE_RECEIPT_STORE> GetCMS_MEDICINE_RECEIPT_STOREByID(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_STORE_BYID", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_STOREByID: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_MEDICINE_RECEIPT_STORE(CMS_MEDICINE_RECEIPT_STORE _MEDICINE_RECEIPT_STORE)
        {
            string result = string.Empty;
            try
            {
                

                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.ExecuteInsert("SP_receipt_store_INSERT", _MEDICINE_RECEIPT_STORE.MEDICINE_RECEIPT_STORE_CODE, _MEDICINE_RECEIPT_STORE.MEDICINE_RECEIPT_STORE_NOTE, _MEDICINE_RECEIPT_STORE.CONTRACT, _MEDICINE_RECEIPT_STORE.TOTAL_PRICE, _MEDICINE_RECEIPT_STORE.VAT, _MEDICINE_RECEIPT_STORE.TOTAL_PAYMENTS, _MEDICINE_RECEIPT_STORE.STATUS, _MEDICINE_RECEIPT_STORE.CREATEBY, _MEDICINE_RECEIPT_STORE.CREATEDATE, _MEDICINE_RECEIPT_STORE.UPDATEBY, _MEDICINE_RECEIPT_STORE.UPDATEDATE, _MEDICINE_RECEIPT_STORE.PARTNERID, _MEDICINE_RECEIPT_STORE.CONTRACT_DATE, _MEDICINE_RECEIPT_STORE.MEDICINE_SUPPLIER_ID);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_Category: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string PUBLICCMS_MEDICINE_RECEIPT_STORE(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.ExecuteNonQuery("SP_receipt_store_PUBLIC", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("PUBLICCMS_GROUP_MEDICINE: " + Id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string UpdateCMS_MEDICINE_RECEIPT_STORE(CMS_MEDICINE_RECEIPT_STORE _MEDICINE_RECEIPT_STORE)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.ExecuteNonQuery("SP_receipt_store_Update", _MEDICINE_RECEIPT_STORE.ID, _MEDICINE_RECEIPT_STORE.MEDICINE_RECEIPT_STORE_CODE, _MEDICINE_RECEIPT_STORE.MEDICINE_RECEIPT_STORE_NOTE, _MEDICINE_RECEIPT_STORE.CONTRACT, _MEDICINE_RECEIPT_STORE.TOTAL_PRICE, _MEDICINE_RECEIPT_STORE.VAT, _MEDICINE_RECEIPT_STORE.TOTAL_PAYMENTS, _MEDICINE_RECEIPT_STORE.STATUS, _MEDICINE_RECEIPT_STORE.CREATEBY, _MEDICINE_RECEIPT_STORE.CREATEDATE, _MEDICINE_RECEIPT_STORE.UPDATEBY, _MEDICINE_RECEIPT_STORE.UPDATEDATE, _MEDICINE_RECEIPT_STORE.PARTNERID, _MEDICINE_RECEIPT_STORE.CONTRACT_DATE, _MEDICINE_RECEIPT_STORE.MEDICINE_SUPPLIER_ID);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_MEDICINE_RECEIPT_STORE: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
