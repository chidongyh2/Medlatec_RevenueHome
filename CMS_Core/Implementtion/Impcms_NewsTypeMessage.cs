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
    public class Impcms_NewsTypeMessage : Icms_NewsTypeMessage
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Deletecms_NewsTypeMessage(cms_NewsTypeMessage _NewsTypeMessage)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsTypeMessage_DeleteByPrimaryKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TypeMessageId", _NewsTypeMessage.TypeMessageId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = _NewsTypeMessage.TypeMessageId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_NewsTypeMessage: " + _NewsTypeMessage.TypeMessageId + "  " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public string Deletecms_NewsTypeMessage(int TypeMessageId)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsTypeMessage_DeleteByPrimaryKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TypeMessageId", TypeMessageId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = TypeMessageId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_NewsTypeMessage: " + TypeMessageId + "  " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public List<cms_NewsTypeMessage> GetAllcms_NewsTypeMessage()
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    using (var mul = con.QueryMultiple("SP_cms_NewsTypeMessage_SelectAll", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_NewsTypeMessage>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_NewsTypeMessage: " + ex.ToString());

                return null;
            }
        }

        public List<cms_NewsTypeMessage> GetAllcms_NewsTypeMessageByStatus(int TypeMessageStatus)
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    parm.Add("@TypeMessageStatus", TypeMessageStatus);
                    using (var mul = con.QueryMultiple("SP_cms_NewsTypeMessageByStatus", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_NewsTypeMessage>().ToList();
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


        public List<cms_NewsTypeMessage> GetAllcms_NewsTypeMessage(int TypeMessageStatus)
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    parm.Add("@TypeMessageStatus", TypeMessageStatus);
                    using (var mul = con.QueryMultiple("SP_cms_NewsTypeMessage_SelectByStatus", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_NewsTypeMessage>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_NewsTypeMessage: " + ex.ToString());

                return null;
            }
        }

        public List<cms_NewsTypeMessage> Getcms_NewsTypeMessageByID(int TypeMessageId)
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    parm.Add("@TypeMessageId", TypeMessageId);
                    using (var mul = con.QueryMultiple("SP_cms_NewsTypeMessage_SelectByPrimaryKey", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_NewsTypeMessage>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_NewsTypeMessageByID: " + ex.ToString());
                return null;
            }
        }

        public string Insertcms_NewsTypeMessage(cms_NewsTypeMessage _NewsTypeMessage)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsTypeMessage_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TypeMessageName", _NewsTypeMessage.TypeMessageName);
                SqlParameter outparam = cmd.Parameters.Add("@TypeMessageId", SqlDbType.Int);
                outparam.Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                result = cmd.Parameters["@TypeMessageId"].Value.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_NewsTypeMessage: " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public string Publiccms_NewsTypeMessage(int TypeMessageId)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsTypeMessage_PublicByPrimaryKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TypeMessageId", TypeMessageId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = TypeMessageId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Publiccms_NewsTypeMessage: " + TypeMessageId + "  " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public string Updatecms_NewsTypeMessage(cms_NewsTypeMessage _NewsTypeMessage)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_NewsTypeMessage_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TypeMessageName", _NewsTypeMessage.TypeMessageName);                
                cmd.Parameters.AddWithValue("@TypeMessageId", _NewsTypeMessage.TypeMessageId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = _NewsTypeMessage.TypeMessageId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Updatecms_NewsTypeMessage: " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }
    }
}
