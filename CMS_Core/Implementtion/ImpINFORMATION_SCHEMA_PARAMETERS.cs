using CMS_Core.Common;
using CMS_Core.Entity;
using CMS_Core.Interface;
using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Implementtion
{
    public class ImpINFORMATION_SCHEMA_PARAMETERS : IINFORMATION_SCHEMA_PARAMETERS
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<INFORMATION_SCHEMA_PARAMETERS> GetINFORMATION_SCHEMA_PARAMETERSByProcedure(string ProcedureName)
        {
            try
            {
                if (string.IsNullOrEmpty(ProcedureName))
                {
                    ProcedureName = string.Empty;
                    return null;
                }

                SQLServerConnection<INFORMATION_SCHEMA_PARAMETERS> sQLServer = new SQLServerConnection<INFORMATION_SCHEMA_PARAMETERS>();
                return sQLServer.SelectQuery("SELECT *  FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = '" + ProcedureName + "' ORDER BY ORDINAL_POSITION");
            }
            catch (Exception ex)
            {
                logError.Info("GetINFORMATION_SCHEMA_PARAMETERSByProcedure: " + ex.ToString());
                return null;
            }


            
        }

        public List<INFORMATION_SCHEMA_PARAMETERS> GetINFORMATION_SCHEMA_PARAMETERSByProcedureRevenue(string ProcedureName)
        {
            try
            {
                if (string.IsNullOrEmpty(ProcedureName))
                {
                    ProcedureName = string.Empty;
                    return null;
                }

                SQLServerConnectionRevenue<INFORMATION_SCHEMA_PARAMETERS> sQLServer = new SQLServerConnectionRevenue<INFORMATION_SCHEMA_PARAMETERS>();
                return sQLServer.SelectQuery("SELECT *  FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = '" + ProcedureName + "' ORDER BY ORDINAL_POSITION");
            }
            catch (Exception ex)
            {
                logError.Info("GetINFORMATION_SCHEMA_PARAMETERSByProcedure: " + ex.ToString());
                return null;
            }



        }
    }
}
