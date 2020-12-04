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
    public class ImpCMS_MEDICINE_REFUND_DETAIL : ICMS_MEDICINE_REFUND_DETAIL
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_MEDICINE_REFUND_DETAIL entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL>();
                return sQLServer.ExecuteInsert("sp_refund_detail_insert", entity.CMS_MEDICINE_EXPORT_STORE_CODE, entity.CMS_MEDICINE_EXPORT_STORE_ID, entity.MEDICINE_ID, entity.MEDICINE_CODE, entity.MEDICINE_AMOUNT, entity.MEDICINE_PRICE, entity.MEDICINE_CREATE, entity.MEDICINE_EXPIRED, entity.NOTE, entity.STATUS, entity.PARTNERID, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.REFUND_STORE);
            }
            catch (Exception ex)
            {
                logError.Info("AddCMS_MEDICINE_REFUND_DETAIL: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Add(CMS_MEDICINE_REFUND_DETAIL entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_MEDICINE_REFUND_DETAIL entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_MEDICINE_REFUND_DETAIL entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CMS_MEDICINE_REFUND_DETAIL Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL>();
                var data = sQLServer.SelectQueryCommand("SP_MEDICINE_REFUND_DETAIL_BYID", id, PARTNERID);
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

        public CMS_MEDICINE_REFUND_DETAIL Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_MEDICINE_REFUND_DETAIL> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_MEDICINE_REFUND_DETAIL_ALL",  PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE_REFUND_DETAIL> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CMS_MEDICINE_REFUND_DETAIL> GetBYRefundStoreID(int RefundStoreID, int PARTNERID)
        {

            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL>();
                return sQLServer.SelectQueryCommand("SP_MEDICINE_REFUND_DETAIL_RSID", RefundStoreID, PARTNERID);
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

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_MEDICINE_REFUND_DETAIL entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL> sQLServer = new OracleServerConnection<CMS_MEDICINE_REFUND_DETAIL>();
                return sQLServer.ExecuteNonQuery("sp_refund_detail_update", entity.ID, entity.CMS_MEDICINE_EXPORT_STORE_CODE, entity.CMS_MEDICINE_EXPORT_STORE_ID, entity.MEDICINE_ID, entity.MEDICINE_CODE, entity.MEDICINE_AMOUNT, entity.MEDICINE_PRICE, entity.MEDICINE_CREATE, entity.MEDICINE_EXPIRED, entity.NOTE, entity.STATUS, entity.PARTNERID, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.REFUND_STORE);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Update(CMS_MEDICINE_REFUND_DETAIL entity)
        {
            throw new NotImplementedException();
        }
    }
}
