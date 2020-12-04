using CMS_Core.Common;
using CMS_Core.Entity;
using CMS_Core.Interface;
using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Implementtion
{
    public class Impcms_ControlName : Icms_ControlName
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string Deletecms_ControlName(cms_ControlName _ControlName)
        {
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.ExecuteNonQuery("SP_CMS_CONTROLNAME_DELETE", _ControlName.ID);
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_ControlName: " + _ControlName.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Deletecms_ControlName(string ID)
        {
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.ExecuteNonQuery("SP_CMS_CONTROLNAME_DELETE", ID);
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_ControlName: " + ID + "  " + ex.ToString());
                return string.Empty;
            }
        }



        public List<cms_ControlName> GetAllcms_ControlName()
        {
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.SelectQueryCommand("SP_cms_ControlName_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_ControlName: " + ex.ToString());
                return null;
            }
        }

        public List<cms_ControlName> GetAllcms_ControlNameByStatus(int ControlStatus)
        {
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.SelectQueryCommand("SP_cms_ControlName_Status", ControlStatus);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_ControlNameByStatus: " + ex.ToString());
                return null;
            }
        }

        public List<cms_ControlName> GetAllcms_ControlNameByUrl(int ControlStatus, int menID)
        {
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.SelectQueryCommand("SP_cms_ControlName_ByMenID", ControlStatus, menID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_ControlNameByUrl: " + ex.ToString());
                return null;
            }             
        }

        public List<cms_ControlName> Getcms_ControlNameByID(int ControlID)
        {
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.SelectQueryCommand("SP_cms_ControlName_ByControlID", ControlID);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_ControlNameByID: " + ex.ToString());
                return null;
            }             
        }

        public List<cms_ControlName> Getcms_ControlNameByID(string ID)
        {
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.SelectQueryCommand("SP_CMS_CONTROLNAME_SELECT_BYID", ID);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_ControlNameByID: " + ex.ToString());
                return null;
            }
        }

        public string Insertcms_ControlName(cms_ControlName _ControlName)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.ExecuteInsert("SP_cms_controlname_INSERT", _ControlName.ControlID, _ControlName.ControlName, _ControlName.menID, _ControlName.ControlDes, _ControlName.ControlStatus, _ControlName.LangID);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_ControlName: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Insertcms_ControlNameByMenName(cms_ControlName _ControlName)
        {
            string result = string.Empty;
            try
            {

                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.ExecuteInsert("SP_cms_controlname_ByMenName", _ControlName.ControlID, _ControlName.ControlName, _ControlName.menName, _ControlName.ControlDes, _ControlName.ControlStatus, _ControlName.LangID);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_ControlNameByMenName: " + ex.ToString());
                return result = string.Empty;
            }
        }


        public string Publiccms_ControlName(int ID)
        {
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.ExecuteNonQuery("SP_CMS_CONTROLNAME_PUBLIC", ID);
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_ControlName: " + ID + "  " + ex.ToString());
                return string.Empty;
            }

        }

        public string Updatecms_ControlName(cms_ControlName _ControlName)
        {

            string result = string.Empty;
            try
            {
                OracleServerConnection<cms_ControlName> sQLServer = new OracleServerConnection<cms_ControlName>();
                return sQLServer.ExecuteNonQuery("SP_CMS_CONTROLNAME_update", _ControlName.ControlID, _ControlName.ControlName, _ControlName.menID, _ControlName.ControlDes, _ControlName.LangID, _ControlName.ControlStatus);
            }
            catch (Exception ex)
            {
                logError.Info("Updatecms_ControlName: " + ex.ToString());
                return result = string.Empty;
            }


        }
    }
}
