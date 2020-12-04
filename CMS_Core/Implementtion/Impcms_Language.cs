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
    public class Impcms_Language : Icms_Language
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<cms_Language> Getcms_LanguageAll(int LanguageStatus)
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    parm.Add("@LanguageStatus", LanguageStatus);
                    using (var mul = con.QueryMultiple("SP_cms_Language_SelectByStatus", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_Language>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_LanguageAll: " + ex.ToString());
                return null;
            }
        }
    }
}
