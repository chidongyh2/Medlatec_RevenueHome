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
    public class ImpCMS_TEMPLATEPRINT : ICMS_TEMPLATEPRINT
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public List<CMS_TEMPLATEPRINT> GetAllCMS_TEMPLATEPRINT(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATEPRINT> sQLServer = new OracleServerConnection<CMS_TEMPLATEPRINT>();
                return sQLServer.SelectQueryCommand("SP_CMS_TEMPLATEPRINT_SelectAll", partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_TEMPLATEPRINT: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_TEMPLATEPRINT> GetCMS_TEMPLATEPRINTByName(string NAME, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATEPRINT> sQLServer = new OracleServerConnection<CMS_TEMPLATEPRINT>();
                return sQLServer.SelectQueryCommand("SP_CMS_TEMPLATEPRINT_BYNAME", NAME, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_TEMPLATEPRINTByName: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_TEMPLATEPRINT> GetCMS_TEMPLATEPRINT_BYID(string ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATEPRINT> sQLServer = new OracleServerConnection<CMS_TEMPLATEPRINT>();
                return sQLServer.SelectQueryCommand("SP_CMS_TEMPLATEPRINT_BYID", ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_TEMPLATEPRINT_BYID: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_TEMPLATEPRINT> GetCMS_TEMPLATEPRINT_BYTYPE(int type, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATEPRINT> sQLServer = new OracleServerConnection<CMS_TEMPLATEPRINT>();
                return sQLServer.SelectQueryCommand("SP_CMS_TEMPLATEPRINT_ByType", type, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("SP_CMS_TEMPLATEPRINT_ByType: " + ex.ToString());
                return null;
            }
        }


        public string InsertCMS_TEMPLATEPRINT(CMS_TEMPLATEPRINT _TEMPLATEPRINT)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.ExecuteInsert("SP_CMS_TEMPLATEPRINT_INSERT", _TEMPLATEPRINT.NAME, _TEMPLATEPRINT.TEMPLATE, _TEMPLATEPRINT.PARTNERID, _TEMPLATEPRINT.TYPE, _TEMPLATEPRINT.STATUS, _TEMPLATEPRINT.CREATEBY, _TEMPLATEPRINT.CREATEDATE);
            }
            catch (Exception ex)
            {
                logError.Info("InsertCMS_TEMPLATEPRINT: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string UpdateCMS_TEMPLATEPRINT(CMS_TEMPLATEPRINT _TEMPLATEPRINT)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT> sQLServer = new OracleServerConnection<CMS_PATIENT>();
                return sQLServer.ExecuteNonQuery("SP_CMS_TEMPLATEPRINT_UPDATE", _TEMPLATEPRINT.ID, _TEMPLATEPRINT.NAME, _TEMPLATEPRINT.TEMPLATE, _TEMPLATEPRINT.PARTNERID, _TEMPLATEPRINT.TYPE, _TEMPLATEPRINT.STATUS, _TEMPLATEPRINT.CREATEBY, _TEMPLATEPRINT.CREATEDATE);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_TEMPLATEPRINT: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
