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
    public class Impcms_NewsSource : Icms_NewsSource
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Deletecms_NewsSource(cms_NewsSource _NewsSource)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsSource_DeleteByPrimaryKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SourceId", _NewsSource.SourceId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = _NewsSource.SourceId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_NewsSource: " + _NewsSource.SourceId + "  " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public string Deletecms_NewsSource(int SourceId)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsSource_DeleteByPrimaryKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SourceId", SourceId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = SourceId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_NewsSource: " + SourceId + "  " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public string Publiccms_NewsSource(int SourceId)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsSource_PulichByPrimaryKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SourceId", SourceId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = SourceId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Publiccms_NewsSource: " + SourceId + "  " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public List<cms_NewsSource> GetAllcms_NewsSource()
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    using (var mul = con.QueryMultiple("SP_cms_NewsSource_SelectAll", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_NewsSource>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_NewsSource: " + ex.ToString());

                return null;
            }
        }

        public List<cms_NewsSource> GetAllcms_NewsSourceByStatus( int SourceStatus)
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    parm.Add("@SourceStatus", SourceStatus);
                    using (var mul = con.QueryMultiple("SP_cms_NewsSource_SelectByStatus", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_NewsSource>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_NewsSourceByStatus: " + ex.ToString());

                return null;
            }
        }


        public List<cms_NewsSource> Getcms_NewsSourceByID(int SourceId)
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    parm.Add("@SourceId", SourceId);
                    using (var mul = con.QueryMultiple("SP_cms_NewsSource_SelectByPrimaryKey", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_NewsSource>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_NewsSourceByID: " + ex.ToString());
                return null;
            }
        }

        public string Insertcms_NewsSource(cms_NewsSource _NewsSource)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsSource_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SourceName", _NewsSource.SourceName);
                cmd.Parameters.AddWithValue("@SourceLink", _NewsSource.SourceLink);                
                SqlParameter outparam = cmd.Parameters.Add("@SourceId", SqlDbType.Int);
                outparam.Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                result = cmd.Parameters["@SourceId"].Value.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_NewsSource: " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public string Updatecms_NewsSource(cms_NewsSource _NewsSource)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsSource_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SourceName", _NewsSource.SourceName);
                cmd.Parameters.AddWithValue("@SourceLink", _NewsSource.SourceLink);
                cmd.Parameters.AddWithValue("@SourceId", _NewsSource.SourceId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = _NewsSource.SourceId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Updatecms_NewsSource: " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }
    }
}
