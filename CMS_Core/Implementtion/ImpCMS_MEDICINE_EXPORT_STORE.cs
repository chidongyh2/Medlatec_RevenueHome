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
    public class ImpCMS_MEDICINE_EXPORT_STORE : ICMS_MEDICINE_EXPORT_STORE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string DeleteCMS_MEDICINE_EXPORT_STORE(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_STORE>();
                return sQLServer.ExecuteNonQuery("SP_EXPORT_STORE_DELETE", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_MEDICINE_EXPORT_STORE: " + Id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_MEDICINE_EXPORT_STORE(string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_STORE>();
                return sQLServer.ExecuteNonQuery("SP_EXPORT_STORE_DELETEByCODE", code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_MEDICINE_EXPORT_STORE: " + code + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public Int64 GET_CMS_MEDICINE_EXPORT_STORE_SEQ()
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                List<CMS_MEDICINE_RECEIPT_STORE> result = sQLServer.SelectQuery("SELECT CMS_MEDICINE_EXPORT_STORE_SEQ1.nextval as ID  FROM DUAL");
                if (result != null)
                {
                    if (result.Count > 0)
                    {
                        return result[0].ID;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                logError.Info("GET_CMS_MEDICINE_EXPORT_STORE_SEQ: " + ex.ToString());
                return 0;
            }
        }


        public List<CMS_MEDICINE_EXPORT_STORE> GetCMS_MEDICINE_EXPORT_STORE(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_STORE>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_STORE_SELECTALL", partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_STORE: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_MEDICINE_EXPORT_STORE> GetCMS_MEDICINE_EXPORT_STOREByDATE(DateTime start, DateTime end, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_STORE>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_STORE__ByDate", start, end, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_STORE: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_MEDICINE_EXPORT_STORE> GetCMS_MEDICINE_EXPORT_STOREByCODE(DateTime startdate, DateTime enddate, string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_STORE>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_STORE_BYCODE", startdate, enddate, code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_STOREByCODE: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_MEDICINE_EXPORT_STORE> GetCMS_MEDICINE_EXPORT_STOREByALL(DateTime startdate, DateTime enddate, string code, int status,  int partnerid, int partneridUser)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_STORE>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_STORE_BYALL", startdate, enddate, code, status, partnerid, partneridUser);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_STOREByALL: " + ex.ToString());
                return null;
            }
        }



        public List<CMS_MEDICINE_EXPORT_STORE> GetCMS_MEDICINE_EXPORT_STOREByCODE( string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_STORE>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_STORE_BYALLCODE",  code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_STOREByCODE: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_MEDICINE_EXPORT_STORE> GetCMS_MEDICINE_EXPORT_STOREByID(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_STORE>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_STORE_BYID",   Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_STOREByID: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_MEDICINE_EXPORT_STORE(CMS_MEDICINE_EXPORT_STORE _MEDICINE_EXPORT_STORE)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.ExecuteInsert("SP_EXPORT_STORE_INSERT",  _MEDICINE_EXPORT_STORE.CMS_MEDICINE_EXPORT_STORE_CODE, _MEDICINE_EXPORT_STORE.CMS_MEDICINE_EXPORT_STORE_NOTE, _MEDICINE_EXPORT_STORE.EMPLOYEECODE, _MEDICINE_EXPORT_STORE.TOTAL_PRICE, _MEDICINE_EXPORT_STORE.CUSTOMER_NAME, _MEDICINE_EXPORT_STORE.CUSTOMER_ADDRESS, _MEDICINE_EXPORT_STORE.CUSTOMER_MOBILE, _MEDICINE_EXPORT_STORE.CUSTOMER_EMAIL, _MEDICINE_EXPORT_STORE.CUSTOMER_GENDER, _MEDICINE_EXPORT_STORE.MONEY_CASH, _MEDICINE_EXPORT_STORE.MONEY_POS, _MEDICINE_EXPORT_STORE.STATUS, _MEDICINE_EXPORT_STORE.PARTNERID, _MEDICINE_EXPORT_STORE.CREATEBY, _MEDICINE_EXPORT_STORE.CREATEDATE, _MEDICINE_EXPORT_STORE.UPDATEBY, _MEDICINE_EXPORT_STORE.UPDATEDATE);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_Category: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string PUBLICCMS_MEDICINE_EXPORT_STORE(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_STORE>();
                return sQLServer.ExecuteNonQuery("SP_EXPORT_STORE_PULICH", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("PUBLICCMS_MEDICINE_EXPORT_STORE: " + Id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string UpdateCMS_MEDICINE_EXPORT_STORE(CMS_MEDICINE_EXPORT_STORE _MEDICINE_EXPORT_STORE)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.ExecuteNonQuery("SP_EXPORT_STORE_UPDATE", _MEDICINE_EXPORT_STORE.ID, _MEDICINE_EXPORT_STORE.CMS_MEDICINE_EXPORT_STORE_CODE, _MEDICINE_EXPORT_STORE.CMS_MEDICINE_EXPORT_STORE_NOTE, _MEDICINE_EXPORT_STORE.EMPLOYEECODE, _MEDICINE_EXPORT_STORE.TOTAL_PRICE, _MEDICINE_EXPORT_STORE.CUSTOMER_NAME, _MEDICINE_EXPORT_STORE.CUSTOMER_ADDRESS, _MEDICINE_EXPORT_STORE.CUSTOMER_MOBILE, _MEDICINE_EXPORT_STORE.CUSTOMER_EMAIL, _MEDICINE_EXPORT_STORE.CUSTOMER_GENDER, _MEDICINE_EXPORT_STORE.MONEY_CASH, _MEDICINE_EXPORT_STORE.MONEY_POS, _MEDICINE_EXPORT_STORE.STATUS, _MEDICINE_EXPORT_STORE.PARTNERID, _MEDICINE_EXPORT_STORE.CREATEBY, _MEDICINE_EXPORT_STORE.CREATEDATE, _MEDICINE_EXPORT_STORE.UPDATEBY, _MEDICINE_EXPORT_STORE.UPDATEDATE);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_MEDICINE_EXPORT_STORE: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
