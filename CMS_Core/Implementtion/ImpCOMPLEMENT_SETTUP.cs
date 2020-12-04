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
    public class ImpCOMPLEMENT_SETTUP : ICOMPLEMENT_SETTUP
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string DeleteCOMPLEMENT_SETTUP(COMPLEMENT_SETTUP _SETTUP)
        {
            try
            {
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.ExecuteNonQuery("SP_COMPLEMENT_SETTUP_Delete", _SETTUP.ID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCOMPLEMENT_SETTUP: " + _SETTUP.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCOMPLEMENT_SETTUP(string id)
        {
            try
            {
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.ExecuteNonQuery("SP_COMPLEMENT_SETTUP_Delete", id);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCOMPLEMENT_SETTUP: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<COMPLEMENT_SETTUP> GetAllCOMPLEMENT_SETTUP()
        {
            try
            {
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.SelectQueryCommand("SP_COMPLEMENT_SETTUP_All");
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCOMPLEMENT_SETTUP: " + ex.ToString());
                return null;
            }
        }

        public List<COMPLEMENT_SETTUP> GetAllCOMPLEMENT_SETTUP_BYCATEID(int cateid)
        {
            try
            { 
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.SelectQueryCommand("SP_COMPLEMENT_SETTUP_BYCATE_ID", cateid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCOMPLEMENT_SETTUP_BYCATEID: " + ex.ToString());
                return null;
            }
        }

        public List<COMPLEMENT_SETTUP> GetAllCOMPLEMENT_SETTUP_BYCATEIDANDSTATUS(int cateid, int status)
        {
            try
            {
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.SelectQueryCommand("SP_COMPLEMENT_SETTUP_STATUS", cateid, status);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCOMPLEMENT_SETTUP_BYCATEID: " + ex.ToString());
                return null;
            }
        }


        public List<COMPLEMENT_SETTUP> GetAllCOMPLEMENT_SETTUP_ByFIELD_NAME(string FIELD_NAME, int CATEGORYS_ID)
        {
            try
            {
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.SelectQueryCommand("SP_COMPLEMENT_SETTUP_byName", FIELD_NAME, CATEGORYS_ID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCOMPLEMENT_SETTUP_ByFIELD_NAME: " + ex.ToString());
                return null;
            }
        }

        public List<COMPLEMENT_SETTUP> GetAllCOMPLEMENT_SETTUP_ByID(int ID)
        {
            try
            {
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.SelectQueryCommand("SP_COMPLEMENT_SETTUP_ByID", ID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCOMPLEMENT_SETTUP_ByID: " + ex.ToString());
                return null;
            }
        }

        public string InsertCOMPLEMENT_SETTUP(COMPLEMENT_SETTUP _SETTUP)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.ExecuteInsert("SP_complement_settup_Insert", _SETTUP.CLASS, _SETTUP.LABEL_NAME, _SETTUP.PLACEHOLDER, _SETTUP.REQUIRED, _SETTUP.FIELDTYPE, _SETTUP.FIELD_NAME, _SETTUP.CATEGORYS_ID, _SETTUP.DISPLAYORDER, _SETTUP.COMPLEMENT_STATUS, _SETTUP.SQL, _SETTUP.COLS_LENGTH, _SETTUP.ROWS_LENGTH, _SETTUP.TEXTBOX_TYPE , _SETTUP.TYPEDATAINPUT);
            }
            catch (Exception ex)
            {
                logError.Info("InsertCOMPLEMENT_SETTUP: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string PublicCOMPLEMENT_SETTUP(int id)
        {
            try
            {
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.ExecuteNonQuery("SP_COMPLEMENT_SETTUP_Public", id);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCOMPLEMENT_SETTUP: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string UpdateCOMPLEMENT_SETTUP(COMPLEMENT_SETTUP _SETTUP)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<COMPLEMENT_SETTUP> sQLServer = new OracleServerConnection<COMPLEMENT_SETTUP>();
                return sQLServer.ExecuteNonQuery("SP_complement_settup_Update", _SETTUP.ID, _SETTUP.CLASS, _SETTUP.LABEL_NAME, _SETTUP.PLACEHOLDER, _SETTUP.REQUIRED, _SETTUP.FIELDTYPE, _SETTUP.FIELD_NAME, _SETTUP.CATEGORYS_ID, _SETTUP.DISPLAYORDER, _SETTUP.COMPLEMENT_STATUS, _SETTUP.SQL, _SETTUP.COLS_LENGTH, _SETTUP.ROWS_LENGTH, _SETTUP.TEXTBOX_TYPE, _SETTUP.TYPEDATAINPUT);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCOMPLEMENT_SETTUP: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
