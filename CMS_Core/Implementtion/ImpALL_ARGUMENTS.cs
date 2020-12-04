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
    public class ImpALL_ARGUMENTS : IALL_ARGUMENTS
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<ALL_ARGUMENTS> GetALL_ARGUMENTSByProcedure(string ProcedureName)
        {
            try
            {
                if (string.IsNullOrEmpty(ProcedureName))
                {
                    ProcedureName = string.Empty;
                    return null;
                }

                OracleServerConnection<ALL_ARGUMENTS> sQLServer = new OracleServerConnection<ALL_ARGUMENTS>();
                return sQLServer.SelectQuery("SELECT object_name, argument_name, data_type, position,in_out FROM SYS.ALL_ARGUMENTS where object_name = '" + ProcedureName.ToUpper() + "' ORDER BY position asc");
            }
            catch (Exception ex)
            {
                logError.Info("GetALL_ARGUMENTSByProcedure: " + ex.ToString());
                return null;
            }
        }
    }
}
