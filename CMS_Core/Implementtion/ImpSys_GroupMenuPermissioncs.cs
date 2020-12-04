using CMS_Core.Common;
using CMS_Core.Entity;
using CMS_Core.Interface;
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
    public class ImpSys_GroupMenuPermissioncs : ISys_GroupMenuPermission
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string DeleteSys_GroupMenuPermission(Sys_GroupMenuPermission _GroupMenuPermission)
        {
            try
            {
                SQLServerConnection<Sys_GroupMenuPermission> sQLServer = new SQLServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteNonQuery("SP_GroupMenuPermission_Delete", _GroupMenuPermission.GroupID, _GroupMenuPermission.MenID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteSys_GroupMenuPermission: " + _GroupMenuPermission.GroupID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteListSys_GroupMenuPermission(int p_groupid, string p_Listmenid)
        {
            try
            {
                SQLServerConnection<Sys_GroupMenuPermission> sQLServer = new SQLServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteNonQuery("SP_GroupMenuPermission_DelList", p_groupid, p_Listmenid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteListSys_GroupMenuPermission: " + p_Listmenid + "  " + ex.ToString());
                return string.Empty;
            }
        }



        public string InsertSys_GroupMenuPermission(Sys_GroupMenuPermission _GroupMenuPermission)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<Sys_GroupMenuPermission> sQLServer = new SQLServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteInsert("SP_groupmenupermission_Insert", _GroupMenuPermission.GroupID, _GroupMenuPermission.MenID, _GroupMenuPermission.Permision);
            }
            catch (Exception ex)
            {
                logError.Info("InsertSys_GroupMenuPermission: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string InsertListSys_GroupMenuPermission(int p_groupid, string p_Listmenid, int permision)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<Sys_GroupMenuPermission> sQLServer = new SQLServerConnection<Sys_GroupMenuPermission>();                
                return sQLServer.ExecuteInsert("SP_groupmenupermission_InsList", p_groupid, p_Listmenid, permision);
            }
            catch (Exception ex)
            {
                logError.Info("InsertListSys_GroupMenuPermission: " + ex.ToString());
                return result = string.Empty;
            }
        }

    }
}
