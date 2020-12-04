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
    public class ImpCMS_SERVICE_GROUP_CATE : ICMS_SERVICE_GROUP_CATE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string DeleteCMS_SERVICE_GROUP_CATE(CMS_SERVICE_GROUP_CATE _GROUP_CATE)
        {
            try
            {
                OracleServerConnection<Sys_GroupMenuPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteNonQuery("SP_GroupMenuPermission_Delete", _GROUP_CATE.GROUPID, _GROUP_CATE.SERVICEID, _GROUP_CATE.PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_SERVICE_GROUP_CATE: " + _GROUP_CATE.GROUPID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_SERVICE_GROUP_CATE(int GROUPID,  int PARTNERID)
        {
            try
            {
                OracleServerConnection<Sys_GroupMenuPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteNonQuery("SP_GROUP_CATE_DeleteBYGROUPID", GROUPID,  PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_SERVICE_GROUP_CATE: " + GROUPID + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string DeleteCMS_SERVICE_GROUP_CATE(int p_groupid, string p_ListServiceID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<Sys_GroupMenuPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteNonQuery("SP_GROUP_CATE_DelList", p_groupid, p_ListServiceID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_SERVICE_GROUP_CATE: " + p_ListServiceID + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string InsertListCMS_SERVICE_GROUP_CATE(int p_groupid, string p_ListServiceID, int VISIT_PATIENT , int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<Sys_GroupMenuPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteInsert("SP_GROUP_CATE_InsList", p_groupid, p_ListServiceID, VISIT_PATIENT,PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("InsertListCMS_SERVICE_GROUP_CATE: " + ex.ToString());
                return result = string.Empty;
            }
        }


        public string InsertCMS_SERVICE_GROUP_CATE(CMS_SERVICE_GROUP_CATE _GROUP_CATE)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<Sys_GroupMenuPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteInsert("SP_GROUP_CATE_Insert", _GROUP_CATE.GROUPID, _GROUP_CATE.SERVICEID, _GROUP_CATE.PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("InsertCMS_SERVICE_GROUP_CATE: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
