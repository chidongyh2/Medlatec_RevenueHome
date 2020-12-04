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
    public class ImpCMS_MEDICINE_EXPORT_DETAIL : ICMS_MEDICINE_EXPORT_DETAIL
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string DeleteCMS_MEDICINE_EXPORT_DETAIL(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL>();
                return sQLServer.ExecuteNonQuery("SP_EXPORT_DETAIL_DELETE", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_MEDICINE_RECEIPT_DETAIL: " + Id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_MEDICINE_EXPORT_DETAILBYCODE(string code, int CMS_MEDICINE_EXPORT_STORE_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL>();
                return sQLServer.ExecuteNonQuery("SP_EXPORT_DETAIL_DELETE_BYCODE", code, CMS_MEDICINE_EXPORT_STORE_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_MEDICINE_RECEIPT_DETAIL: " + code + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_MEDICINE_EXPORT_DETAILBYEXPORT_STORE_CODE(string EXPORT_STORE_CODE, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL>();
                return sQLServer.ExecuteNonQuery("SP_EXPORT_DETAIL_DEL_STORECODE", EXPORT_STORE_CODE, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_MEDICINE_EXPORT_DETAILBYEXPORT_STORE_CODE: " + EXPORT_STORE_CODE + "  " + ex.ToString());
                return string.Empty;
            }
        }



        public List<CMS_MEDICINE_EXPORT_DETAIL> GetCMS_MEDICINE_EXPORT_DETAIL(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_DETAIL_BYALL",  partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_DETAIL: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_MEDICINE_EXPORT_DETAIL> GetCMS_MEDICINE_EXPORT_DETAILBySTORE_ID(int STORE_ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_DETAIL_STORE_ID", STORE_ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_DETAILBySTORE_ID: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_MEDICINE_EXPORT_DETAIL> GetCMS_MEDICINE_EXPORT(DateTime startdate,DateTime enddate, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_MEDICINE_Export_ALL", startdate, enddate, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT: " + ex.ToString());
                return null;
            }
        }




        public List<CMS_MEDICINE_EXPORT_DETAIL> GetCMS_MEDICINE_EXPORT_DETAILBySTORE_CODE( string code, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_DETAIL_STORE_CODE", code, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_DETAILBySTORE_CODE: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE_EXPORT_DETAIL> GetCMS_MEDICINE_EXPORT_DETAILByID(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_DETAIL_BYID", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_DETAILByID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE_EXPORT_DETAIL> GetCMS_MEDICINE_EXPORT_DETAILByMEDICINECODE(string STORE_CODE, string MEDICINE_CODE, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_EXPORT_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_EXPORT_DETAIL_MEDICINE_CODE", STORE_CODE, MEDICINE_CODE, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE_EXPORT_DETAILByID: " + ex.ToString());
                return null;
            }
        }


        public string InsertCMS_MEDICINE_EXPORT_DETAIL(CMS_MEDICINE_EXPORT_DETAIL _MEDICINE_EXPORT_DETAIL)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE> sQLServer = new OracleServerConnection<CMS_MEDICINE_RECEIPT_STORE>();
                return sQLServer.ExecuteInsert("SP_EXPORT_DETAIL_INSERT", _MEDICINE_EXPORT_DETAIL.CMS_MEDICINE_EXPORT_STORE_CODE, _MEDICINE_EXPORT_DETAIL.CMS_MEDICINE_EXPORT_STORE_ID, _MEDICINE_EXPORT_DETAIL.MEDICINE_ID, _MEDICINE_EXPORT_DETAIL.MEDICINE_CODE, _MEDICINE_EXPORT_DETAIL.MEDICINE_AMOUNT, _MEDICINE_EXPORT_DETAIL.MEDICINE_PRICE, _MEDICINE_EXPORT_DETAIL.VAT, _MEDICINE_EXPORT_DETAIL.MEDICINE_CREATE, _MEDICINE_EXPORT_DETAIL.MEDICINE_EXPIRED, _MEDICINE_EXPORT_DETAIL.NOTE, _MEDICINE_EXPORT_DETAIL.STATUS, _MEDICINE_EXPORT_DETAIL.PARTNERID, _MEDICINE_EXPORT_DETAIL.CREATEBY, _MEDICINE_EXPORT_DETAIL.CREATEDATE, _MEDICINE_EXPORT_DETAIL.UPDATEBY, _MEDICINE_EXPORT_DETAIL.UPDATEDATE, _MEDICINE_EXPORT_DETAIL.MEDICINE_UNIT);
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

        public string UpdateCMS_MEDICINE_RECEIPT_DETAIL(CMS_MEDICINE_EXPORT_DETAIL _MEDICINE_EXPORT_DETAIL)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.ExecuteNonQuery("SP_EXPORT_DETAIL_UPDATE", _MEDICINE_EXPORT_DETAIL.ID, _MEDICINE_EXPORT_DETAIL.CMS_MEDICINE_EXPORT_STORE_CODE, _MEDICINE_EXPORT_DETAIL.CMS_MEDICINE_EXPORT_STORE_ID, _MEDICINE_EXPORT_DETAIL.MEDICINE_ID, _MEDICINE_EXPORT_DETAIL.MEDICINE_CODE, _MEDICINE_EXPORT_DETAIL.MEDICINE_AMOUNT, _MEDICINE_EXPORT_DETAIL.MEDICINE_PRICE, _MEDICINE_EXPORT_DETAIL.VAT, _MEDICINE_EXPORT_DETAIL.MEDICINE_CREATE, _MEDICINE_EXPORT_DETAIL.MEDICINE_EXPIRED, _MEDICINE_EXPORT_DETAIL.NOTE, _MEDICINE_EXPORT_DETAIL.STATUS, _MEDICINE_EXPORT_DETAIL.PARTNERID, _MEDICINE_EXPORT_DETAIL.CREATEBY, _MEDICINE_EXPORT_DETAIL.CREATEDATE, _MEDICINE_EXPORT_DETAIL.UPDATEBY, _MEDICINE_EXPORT_DETAIL.UPDATEDATE, _MEDICINE_EXPORT_DETAIL.MEDICINE_UNIT);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_MEDICINE_RECEIPT_DETAIL: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
