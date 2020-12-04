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
    public class Impcms_TypeStatus : Icms_TypeStatus
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string Add(cms_TypeStatus entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_TypeStatus> sQLServer = new SQLServerConnection<cms_TypeStatus>();
                return sQLServer.ExecuteInsert("SP_cms_Unit_Insert", entity.TypeStatusName, entity.TypeStatusDesc, entity.TypeStatusId);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_TypeStatus entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public cms_TypeStatus Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<cms_TypeStatus> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<cms_TypeStatus> GetAllcms_TypeStatus()
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    using (var mul = con.QueryMultiple("SP_cms_TypeStatus_SelectAll", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_TypeStatus>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_TypeStatus: " + ex.ToString());

                return null;
            }
        }

        public cms_TypeStatus Getcms_TypeStatusByName(string ColorName)
        {
            throw new NotImplementedException();
        }

        public List<cms_TypeStatus> Getcms_TypeStatusByStatus(int ItemCateItemID, int status, int typeKeyword, string keyword)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(cms_TypeStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
