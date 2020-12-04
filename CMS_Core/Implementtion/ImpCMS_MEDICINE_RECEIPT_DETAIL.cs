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
    public class ImpCMS_MEDICINE_RECEIPT_DETAIL : ICMS_MEDICINE_RECEIPT_DETAIL
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string DeleteCMS_MEDICINE_RECEIPT_DETAIL(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL>();
                return sQLServer.ExecuteNonQuery("SP_RECEIPT_DETAIL_DELETE", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_GROUP_MEDICINE: " + Id + "  " + ex.ToString());
                return string.Empty;
            }

        }

        public string DeleteCMS_MEDICINE_RECEIPT_DETAIL(string code, int RECEIPT_STORE_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL>();
                return sQLServer.ExecuteNonQuery("SP_RECEIPT_DETAIL_DELETE_CODE", code, RECEIPT_STORE_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_GROUP_MEDICINE: " + code + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_MEDICINE_RECEIPT_DETAIL> GetCMS_MEDICINE_RECEIPT_DETAILByCODE(DateTime startdate, DateTime enddate, string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_DETAIL_BYCODE", startdate, enddate, code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_DETAILByCODE: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE_RECEIPT_DETAIL> GetCMS_MEDICINE_RECEIPT_DETAILByMEDICINE_CODE( string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_RECEIPTDETAIL_MEDICINE_CODE",  code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_DETAILByMEDICINE_CODE: " + ex.ToString());
                return null;
            }
        }



        public List<CMS_MEDICINE_RECEIPT_DETAIL> GetCMS_MEDICINE_RECEIPT_DETAILBySTORE_ID(int STORE_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_DETAIL_STORE_ID", STORE_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_DETAILBySTORE_ID: " + ex.ToString());
                return null;
            }
        }





        public List<CMS_MEDICINE_RECEIPT_DETAIL> GetCMS_MEDICINE_RECEIPT_DETAILBySTOREID(int RECEIPT_STORE_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_DETAIL_BYSTOREID", RECEIPT_STORE_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_DETAILBySTOREID: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_MEDICINE_RECEIPT_DETAIL> GetCMS_MEDICINE_RECEIPT_DETAILByID(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_DETAIL_BYID", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_DETAILByID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE_RECEIPT_DETAIL> GetCMS_MEDICINE_RECEIPT_STORECMS_MEDICINE_RECEIPT_DETAIL(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_RECEIPT_DETAIL_BYALL",  partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_RECEIPT_DETAILByID: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_MEDICINE_RECEIPT_DETAIL(CMS_MEDICINE_RECEIPT_DETAIL _MEDICINE_RECEIPT_DETAIL)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.ExecuteInsert("SP_RECEIPT_DETAIL_INSERT", _MEDICINE_RECEIPT_DETAIL.MEDICINE_CODE, _MEDICINE_RECEIPT_DETAIL.NOTE, _MEDICINE_RECEIPT_DETAIL.AMOUNT, _MEDICINE_RECEIPT_DETAIL.IMPORTPRICE, _MEDICINE_RECEIPT_DETAIL.VAT, _MEDICINE_RECEIPT_DETAIL.EXPORTPRICE, _MEDICINE_RECEIPT_DETAIL.LOTMUMBER, _MEDICINE_RECEIPT_DETAIL.DATEOFMANUFACTURE, _MEDICINE_RECEIPT_DETAIL.EXPIRYDATE, _MEDICINE_RECEIPT_DETAIL.MANUFACTUREID, _MEDICINE_RECEIPT_DETAIL.KYGUI, _MEDICINE_RECEIPT_DETAIL.CREATEBY, _MEDICINE_RECEIPT_DETAIL.CREATEDATE, _MEDICINE_RECEIPT_DETAIL.UPDATEBY, _MEDICINE_RECEIPT_DETAIL.UPDATEDATE, _MEDICINE_RECEIPT_DETAIL.PARTNERID, _MEDICINE_RECEIPT_DETAIL.PROVIDEDID, _MEDICINE_RECEIPT_DETAIL.MEDICINE_ID, _MEDICINE_RECEIPT_DETAIL.RECEIPT_STORE_ID, _MEDICINE_RECEIPT_DETAIL.REGISTRATIONNUMBER, _MEDICINE_RECEIPT_DETAIL.MEDICINE_UNIT);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_Category: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string PUBLICCMS_MEDICINE_RECEIPT_DETAIL(int Id, int partnerid)
        {
            throw new NotImplementedException();
        }

        public string UpdateCMS_MEDICINE_RECEIPT_DETAIL(CMS_MEDICINE_RECEIPT_DETAIL _MEDICINE_RECEIPT_DETAIL)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.ExecuteNonQuery("SP_RECEIPT_DETAIL_UPDATE", _MEDICINE_RECEIPT_DETAIL.ID, _MEDICINE_RECEIPT_DETAIL.MEDICINE_CODE, _MEDICINE_RECEIPT_DETAIL.NOTE, _MEDICINE_RECEIPT_DETAIL.AMOUNT, _MEDICINE_RECEIPT_DETAIL.IMPORTPRICE, _MEDICINE_RECEIPT_DETAIL.VAT, _MEDICINE_RECEIPT_DETAIL.EXPORTPRICE, _MEDICINE_RECEIPT_DETAIL.LOTMUMBER, _MEDICINE_RECEIPT_DETAIL.DATEOFMANUFACTURE, _MEDICINE_RECEIPT_DETAIL.EXPIRYDATE, _MEDICINE_RECEIPT_DETAIL.MANUFACTUREID, _MEDICINE_RECEIPT_DETAIL.KYGUI, _MEDICINE_RECEIPT_DETAIL.CREATEBY, _MEDICINE_RECEIPT_DETAIL.CREATEDATE, _MEDICINE_RECEIPT_DETAIL.UPDATEBY, _MEDICINE_RECEIPT_DETAIL.UPDATEDATE, _MEDICINE_RECEIPT_DETAIL.PARTNERID, _MEDICINE_RECEIPT_DETAIL.PROVIDEDID, _MEDICINE_RECEIPT_DETAIL.MEDICINE_ID, _MEDICINE_RECEIPT_DETAIL.MEDICINE_UNIT);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_MEDICINE_RECEIPT_STORE: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
