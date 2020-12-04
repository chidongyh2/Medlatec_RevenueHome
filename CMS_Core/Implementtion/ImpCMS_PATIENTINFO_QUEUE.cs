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
    public class ImpCMS_PATIENTINFO_QUEUE : ICMS_PATIENTINFO_QUEUE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_PATIENTINFO_QUEUE entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }


        public string Add(Int64 sid, Int64 pid, string LISTLOCATIONID , int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<Sys_GroupMenuPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteInsert("sp_patientinfo_queue_inslist", sid, pid, LISTLOCATIONID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Add(Int64 sid, Int64 pid, int LOCATIONID, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<Sys_GroupMenuPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuPermission>();
                return sQLServer.ExecuteInsert("sp_patientinfo_queue_Insert", sid, pid, LOCATIONID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }


        public string DeleteSID(Int64 sid, Int64 pid,  int PARTNERID)
        {
            try
            {
                OracleServerConnection<Sys_GroupMenuControlPermission> sQLServer = new OracleServerConnection<Sys_GroupMenuControlPermission>();
                return sQLServer.ExecuteNonQuery("SP_PATIENTINFO_QUEUE_Delete", sid,pid, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteSID: " + sid + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string Delete(CMS_PATIENTINFO_QUEUE entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public CMS_PATIENTINFO_QUEUE Get(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENTINFO_QUEUE> GetAll(int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENTINFO_QUEUE> GetAll(int LOCATIONID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_QUEUE> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_QUEUE>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENTINFO_QUEUE_ALL", LOCATIONID, PARTNERID);
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

        public string Update(CMS_PATIENTINFO_QUEUE entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public CMS_PATIENTINFO_QUEUE Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENTINFO_QUEUE> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_PATIENTINFO_QUEUE entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_PATIENTINFO_QUEUE entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_PATIENTINFO_QUEUE entity)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
