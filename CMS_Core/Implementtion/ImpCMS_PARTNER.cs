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
    public class ImpCMS_PARTNER : ICMS_PARTNER
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string DeleteCMS_PARTNER(CMS_PARTNER _PARTNER)
        {
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.ExecuteNonQuery("SP_cms_partner_DELETE", _PARTNER.ID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCATEGORYS: " + _PARTNER.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_PARTNER(int ID)
        {
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.ExecuteNonQuery("SP_cms_partner_DELETE", ID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCATEGORYS: " + ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

       

        public List<CMS_PARTNER> GetAllMS_PARTNER()
        {
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.SelectQueryCommand("SP_cms_partner_SELECT_ALL");
            }
            catch (Exception ex)
            {
                logError.Info("GetAllMS_PARTNER: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PARTNER> GetAllMS_PARTNER_BYSTATUS(int STATUS)
        {
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.SelectQueryCommand("SP_cms_partner_SELECT_Status", STATUS);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllMS_PARTNER_BYSTATUS: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PARTNER> GetCMS_PARTNERByName(string PARTNER_NAME)
        {
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.SelectQueryCommand("SP_cms_partner_SELECT_NAME", PARTNER_NAME);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PARTNERByName: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PARTNER> GetCMS_PARTNERByCode(string PARTNER_CODE)
        {
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.SelectQueryCommand("SP_cms_partner_SELECT_code", PARTNER_CODE);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PARTNERByCode: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_PARTNER> GetCMS_PARTNER_BYID(string ID)
        {
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.SelectQueryCommand("SP_cms_partner_SELECT_ID", ID);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PARTNER_BYID: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_PARTNER(CMS_PARTNER _PARTNER)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.ExecuteInsert("SP_cms_partner_INSERT", _PARTNER.PARTNER_NAME, _PARTNER.PARTNER_ADDRESS, _PARTNER.PARTNER_MOBILE, _PARTNER.PARTNER_EMAIL, _PARTNER.PARTNER_WEBSITE, _PARTNER.PARTNER_SURROGATE, _PARTNER.PARTNER_SURROGATE_MOBILE, _PARTNER.PARTNER_SURROGATE_POSITION, _PARTNER.PARTNER_MANAGER, _PARTNER.PARTNER_MANAGER_MOBILE, _PARTNER.PARTNER_MANAGER_EMAIL, _PARTNER.PARTNER_STATUS, _PARTNER.PARTNER_CREATE, _PARTNER.PARTNER_CREATE_DATE, _PARTNER.PARTNER_CODE);
            }
            catch (Exception ex)
            {
                logError.Info("InsertCMS_PARTNER: " + ex.ToString());
                return result = string.Empty;
            }

        }

        public string PUBLILC_CMS_PARTNER(int ID)
        {
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.ExecuteNonQuery("SP_cms_partner_public", ID);
            }
            catch (Exception ex)
            {
                logError.Info("PUBLILC_CMS_PARTNER: " + ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string UpdateCMS_PARTNER(CMS_PARTNER _PARTNER)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PARTNER> sQLServer = new OracleServerConnection<CMS_PARTNER>();
                return sQLServer.ExecuteNonQuery("SP_cms_partner_update", _PARTNER.ID, _PARTNER.PARTNER_NAME, _PARTNER.PARTNER_ADDRESS, _PARTNER.PARTNER_MOBILE, _PARTNER.PARTNER_EMAIL, _PARTNER.PARTNER_WEBSITE, _PARTNER.PARTNER_SURROGATE, _PARTNER.PARTNER_SURROGATE_MOBILE, _PARTNER.PARTNER_SURROGATE_POSITION, _PARTNER.PARTNER_MANAGER, _PARTNER.PARTNER_MANAGER_MOBILE, _PARTNER.PARTNER_MANAGER_EMAIL, _PARTNER.PARTNER_STATUS, _PARTNER.PARTNER_CREATE, _PARTNER.PARTNER_CREATE_DATE);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_PARTNER: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
