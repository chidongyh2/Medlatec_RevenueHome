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
    public class ImpSys_GroupMenuControlPermission : ISys_GroupMenuControlPermission
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string DeleteSys_GroupMenuControlPermission(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<Sys_GroupMenuControlPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuControlPermission>();
                return sQLServer.ExecuteNonQuery("SP_groupmenucontrol_Delete", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteSys_GroupMenuControlPermission: " + id + "  " + ex.ToString());
                return string.Empty;
            }             
        }

        public List<Sys_GroupMenuControlPermission> GetSys_GroupMenuControlPermissionAll()
        {
            try
            {
                OracleServerConnection<Sys_GroupMenuControlPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuControlPermission>();
                return sQLServer.SelectQueryCommand("SP_GroupMenuControl_ByALL");
            }
            catch (Exception ex)
            {
                logError.Info("GetSys_GroupMenuControlPermissionAll: " + ex.ToString());
                return null;
            }
             
        }

        public List<Sys_GroupMenuControlPermission> GetSys_GroupMenuControlPermissionByGroupID(int GroupID, string MenLink)
        {
            try
            {
                OracleServerConnection<Sys_GroupMenuControlPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuControlPermission>();
                return sQLServer.SelectQueryCommand("SP_GroupMenuControl_ByGroupID", GroupID, MenLink);
            }
            catch (Exception ex)
            {
                logError.Info("GetSys_GroupMenuControlPermissionByGroupID: " + ex.ToString());
                return null;
            }             
        }

        public List<Sys_GroupMenuControlPermission> GetSys_GroupMenuControlPermissionByGroupID(int GroupID)
        {
            try
            {
                OracleServerConnection<Sys_GroupMenuControlPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuControlPermission>();
                return sQLServer.SelectQueryCommand("SP_GroupMenuControl_SELECT", GroupID);
            }
            catch (Exception ex)
            {
                logError.Info("GetSys_GroupMenuControlPermissionByGroupID: " + ex.ToString());
                return null;
            }             
        }


        public List<Sys_GroupMenuControlPermission> GetSys_GroupMenuControlPermissionByGroupID(int GroupID, int MenID, int GroupID_Account)
        {
            try
            {
                OracleServerConnection<Sys_GroupMenuControlPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuControlPermission>();
                return sQLServer.SelectQueryCommand("SP_groupmenucontrol_ALL", GroupID, MenID, GroupID_Account);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuChildByUserid: " + ex.ToString());
                return null;
            }             
        }
        public string InsertSys_GroupMenuControlPermission(Sys_GroupMenuControlPermission _GroupMenuControlPermission)
        {

            string result = string.Empty;
            try
            {
                OracleServerConnection<Sys_GroupMenuControlPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuControlPermission>();
                return sQLServer.ExecuteInsert("SP_groupmenucontrol_INSERT", _GroupMenuControlPermission.GroupID, _GroupMenuControlPermission.MenID, _GroupMenuControlPermission.ControlID, _GroupMenuControlPermission.Permision, _GroupMenuControlPermission.MenLink, _GroupMenuControlPermission.PARTNERID, _GroupMenuControlPermission.ID);
            }
            catch (Exception ex)
            {
                logError.Info("InsertSys_GroupMenuControlPermission: " + ex.ToString());
                return result = string.Empty;
            }
             
        }
    }
}
