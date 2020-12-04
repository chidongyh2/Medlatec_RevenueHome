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
    public class ImpCMS_SERVICE_GROUP : ICMS_SERVICE_GROUP
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string DeleteCMS_SERVICE_GROUP(CMS_SERVICE_GROUP _SERVICE_GROUP, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE_GROUP> sQLServer = new OracleServerConnection<CMS_SERVICE_GROUP>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SERVICE_GROUP_DELETE", _SERVICE_GROUP.ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_SERVICE_GROUP: " + _SERVICE_GROUP.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_SERVICE_GROUP(int ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE_GROUP> sQLServer = new OracleServerConnection<CMS_SERVICE_GROUP>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SERVICE_GROUP_DELETE", ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_SERVICE_GROUP: " + ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_SERVICE_GROUP> GetAllCMS_SERVICE_GROUP(int partnerid, int partnerUser)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE_GROUP> sQLServer = new OracleServerConnection<CMS_SERVICE_GROUP>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_GROUP_ALL", partnerid, partnerUser);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_SERVICE_GROUP: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SERVICE_GROUP> GetCMS_SERVICE_GROUPByID(int ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE_GROUP> sQLServer = new OracleServerConnection<CMS_SERVICE_GROUP>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_GROUP_BYID", ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_SERVICE_GROUPByID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SERVICE_GROUP> GetCMS_SERVICE_GROUPBySERVICE_GROUP_NAME(string SERVICE_GROUP_NAME, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE_GROUP> sQLServer = new OracleServerConnection<CMS_SERVICE_GROUP>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_GROUP_BYNAME", SERVICE_GROUP_NAME, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_SERVICE_GROUPBySERVICE_GROUP_NAME: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SERVICE_GROUP> GetCMS_SERVICE_GROUPBySERVICE_GROUP_CODE(string SERVICE_GROUP_CODE, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE_GROUP> sQLServer = new OracleServerConnection<CMS_SERVICE_GROUP>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_GROUP_BYCODE", SERVICE_GROUP_CODE, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_SERVICE_GROUPBySERVICE_GROUP_CODE: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_SERVICE_GROUP(CMS_SERVICE_GROUP _SERVICE_GROUP)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_SERVICE_GROUP> sQLServer = new OracleServerConnection<CMS_SERVICE_GROUP>();
                return sQLServer.ExecuteInsert("SP_CMS_SERVICE_GROUP_Insert", _SERVICE_GROUP.SERVICE_GROUP_NAME, _SERVICE_GROUP.SERVICE_GROUP_CODE, _SERVICE_GROUP.SERVICE_GROUP_DESC, _SERVICE_GROUP.SERVICE_GROUP_STATUS, _SERVICE_GROUP.SERVICE_GROUP_DATE, _SERVICE_GROUP.SERVICE_GROUP_CREATEBY, _SERVICE_GROUP.PARTNERID, _SERVICE_GROUP.SERVICE_GROUP_UPDATEBY, _SERVICE_GROUP.SERVICE_GROUP_UPDATEDATE, _SERVICE_GROUP.SERVICE_GROUP_PRICE);
            }
            catch (Exception ex)
            {
                logError.Info("InsertCMS_SERVICE: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string PublicCMS_SERVICE_GROUP(int ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE_GROUP> sQLServer = new OracleServerConnection<CMS_SERVICE_GROUP>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SERVICE_GROUP_PUBLIC", ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("PublicCMS_SERVICE_GROUP: " + ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string UpdateCMS_SERVICE_GROUP(CMS_SERVICE_GROUP _SERVICE_GROUP)
        {

            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_SERVICE_GROUP> sQLServer = new OracleServerConnection<CMS_SERVICE_GROUP>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SERVICE_GROUP_Update", _SERVICE_GROUP.ID, _SERVICE_GROUP.SERVICE_GROUP_NAME, _SERVICE_GROUP.SERVICE_GROUP_CODE, _SERVICE_GROUP.SERVICE_GROUP_DESC, _SERVICE_GROUP.SERVICE_GROUP_STATUS, _SERVICE_GROUP.SERVICE_GROUP_DATE, _SERVICE_GROUP.SERVICE_GROUP_CREATEBY, _SERVICE_GROUP.PARTNERID, _SERVICE_GROUP.SERVICE_GROUP_UPDATEBY, _SERVICE_GROUP.SERVICE_GROUP_UPDATEDATE, _SERVICE_GROUP.SERVICE_GROUP_PRICE);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_SERVICE_GROUP: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
