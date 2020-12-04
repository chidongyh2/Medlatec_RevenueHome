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
    public class ImpCMS_REPORT_SERVICE : ICMS_REPORT_SERVICE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<CMS_REPORT_SERVICE> GetREPORT_SERVICE(DateTime start, DateTime end, int SERVICETYPE, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_REPORT_SERVICE> sQLServer = new OracleServerConnection<CMS_REPORT_SERVICE>();
                return sQLServer.SelectQueryCommand("sp_Report_serviceAll", start, end, SERVICETYPE, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetREPORT_SERVICE: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_REPORT_SERVICE> GetREPORT_GROUP_SERVICE(DateTime start, DateTime end, int SERVICETYPE, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_REPORT_SERVICE> sQLServer = new OracleServerConnection<CMS_REPORT_SERVICE>();
                return sQLServer.SelectQueryCommand("sp_Report_serviceAll", start, end, SERVICETYPE, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetREPORT_SERVICE: " + ex.ToString());
                return null;
            }
        }

    }
}
