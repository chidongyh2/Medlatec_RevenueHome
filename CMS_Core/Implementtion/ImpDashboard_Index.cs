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
    public class ImpDashboard_Index : IDashboard_Index
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public ListDashboard_Index GetDashboard_Index(int PARTNERID)
        {
            try
            {
                OracleServerConnection<Dashboard_Index> sQLServer = new OracleServerConnection<Dashboard_Index>();
                return sQLServer.SelectDashboard_IndexQueryCommand("SP_get_DashboardIndex", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetDashboard_Index: " + ex.ToString());
                return null;
            }
        }

       

        public List<Dashboard_Index> GetReportCashFlow()
        {
            try
            {
                SQLServerConnection<Dashboard_Index> sQLServer = new SQLServerConnection<Dashboard_Index>();
                return sQLServer.SelectQueryCommand("SP_GetReportCashFlow" );
            }
            catch (Exception ex)
            {
                logError.Info("GetDashboard_Index: " + ex.ToString());
                return null;
            }
        }


        public List<Dashboard_Index> GetDashboard_ByDate(string start, string end )
        {
            try
            {
                SQLServerConnection<Dashboard_Index> sQLServer = new SQLServerConnection<Dashboard_Index>();
                return sQLServer.SelectQueryCommand("SP_DashboardIndex_ByDate", start, end );
            }
            catch (Exception ex)
            {
                logError.Info("GetDashboard_Index: " + ex.ToString());
                return null;
            }
        }

        public List<Dashboard_Index> GetDashboard_ByProducerID(string start, string end, int ProducerID)
        {
            try
            {
                SQLServerConnection<Dashboard_Index> sQLServer = new SQLServerConnection<Dashboard_Index>();
                return sQLServer.SelectQueryCommand("SP_DashboardIndex_ByProducer", start, end, ProducerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetDashboard_ByProducerID: " + ex.ToString());
                return null;
            }
        }

    }
}
