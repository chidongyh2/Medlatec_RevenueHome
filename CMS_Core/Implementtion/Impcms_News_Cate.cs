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
    public class Impcms_News_Cate : Icms_News_Cate
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<cms_News_Cate> Getcms_CategoryByID(int newsId)
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    parm.Add("@newsId", newsId);
                    using (var mul = con.QueryMultiple("SP_cms_News_CateByNewsId", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_News_Cate>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_CategoryByID: " + ex.ToString());
                return null;
            }
        }
    }
}
