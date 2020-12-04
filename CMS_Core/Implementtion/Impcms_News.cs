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
    public class Impcms_News : Icms_News
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Deletecms_News(cms_News _News)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_News_DeleteByPrimaryKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@newsId", _News.newsId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = _News.newsId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_News: " + _News.newsId + "  " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public string Deletecms_News(int newsId)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_News_DeleteByPrimaryKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@newsId", newsId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = newsId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_News: " + newsId + "  " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public List<cms_News> GetAllcms_News()
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    using (var mul = con.QueryMultiple("SP_cms_News_SelectAll", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_News>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_News: " + ex.ToString());

                return null;
            }
        }

        public List<cms_News> GetAllcms_News(DateTime Tungay, DateTime Denngay, int SourceId, int ParrenId, int cateId, int newsTypeMessage, int userId, int status, int type, string keyword)
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    parm.Add("@Tungay", Tungay);
                    parm.Add("@Denngay", Denngay);
                    parm.Add("@SourceId", SourceId);
                    parm.Add("@ParrenId", ParrenId);
                    parm.Add("@cateId", cateId);
                    parm.Add("@newsTypeMessage", newsTypeMessage);
                    parm.Add("@userId", userId);
                    parm.Add("@status", status);
                    parm.Add("@type", type);
                    parm.Add("@keyword", keyword);

                    using (var mul = con.QueryMultiple("SP_cms_News_SelectPara", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_News>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_News: " + ex.ToString());

                return null;
            }

        }

        public List<cms_News> Getcms_NewsByID(int newsId)
        {
            try
            {
                var connection = new SqlConnection(Common.Common.getConnectionString());
                using (var con = connection)
                {
                    var parm = new DynamicParameters();
                    parm.Add("@newsId", newsId);                    
                    using (var mul = con.QueryMultiple("SP_cms_News_SelectByPrimaryKey", parm, commandType: CommandType.StoredProcedure))
                    {
                        var data = mul.Read<cms_News>().ToList();
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_News: " + ex.ToString());

                return null;
            }

        }

        public string Insertcms_News(cms_News _News)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {                 
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_News_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cateId ", _News.cateId);
               // cmd.Parameters.AddWithValue("@cateIdList", _News.cateIdList);
                cmd.Parameters.AddWithValue("@SourceId", _News.SourceId);
                cmd.Parameters.AddWithValue("@userId", _News.userId);
                cmd.Parameters.AddWithValue("@newsName ", _News.newsName);
                cmd.Parameters.AddWithValue("@newsKeyword", _News.newsKeyword);
                cmd.Parameters.AddWithValue("@newsDescription", _News.newsDescription);
                cmd.Parameters.AddWithValue("@newsContent", _News.newsContent);
                cmd.Parameters.AddWithValue("@newsImages", _News.newsImages);
                cmd.Parameters.AddWithValue("@newsTitleImages", _News.newsTitleImages);
                cmd.Parameters.AddWithValue("@newsAuthor", _News.newsAuthor);
                cmd.Parameters.AddWithValue("@dateCreate", DateTime.Now);
                cmd.Parameters.AddWithValue("@newsFile", _News.newsFile);
                cmd.Parameters.AddWithValue("@copyRight", _News.copyRight);
                cmd.Parameters.AddWithValue("@allowComment", _News.allowComment);
                cmd.Parameters.AddWithValue("@AccountTypeId", _News.AccountTypeId);
                cmd.Parameters.AddWithValue("@Status", 1);
                cmd.Parameters.AddWithValue("@UrlSource", _News.UrlSource);
                cmd.Parameters.AddWithValue("@newsTypeMessage", _News.newsTypeMessage);
               
                SqlParameter outparam = cmd.Parameters.Add("@newsId", SqlDbType.Int);
                outparam.Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                result = cmd.Parameters["@newsId"].Value.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_News: " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public string Publiccms_News(int newsId)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_News_PublicByPrimaryKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@newsId", newsId);
                con.Open();
                cmd.ExecuteNonQuery();
                result = newsId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Publiccms_News: " + newsId + "  " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }

        public string Updatecms_News(cms_News _News)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_News_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cateIdList", _News.cateIdList);
                cmd.Parameters.AddWithValue("@SourceId", _News.SourceId);
                cmd.Parameters.AddWithValue("@userId", _News.userId);
                cmd.Parameters.AddWithValue("@newsName ", _News.newsName);
                cmd.Parameters.AddWithValue("@newsKeyword", _News.newsKeyword);
                cmd.Parameters.AddWithValue("@newsDescription", _News.newsDescription);
                cmd.Parameters.AddWithValue("@newsContent", _News.newsContent);
                cmd.Parameters.AddWithValue("@newsImages", _News.newsImages);
                cmd.Parameters.AddWithValue("@newsTitleImages", _News.newsTitleImages);
                cmd.Parameters.AddWithValue("@newsAuthor", _News.newsAuthor);
                cmd.Parameters.AddWithValue("@dateCreate", DateTime.Now);
                cmd.Parameters.AddWithValue("@newsFile", _News.newsFile);
                cmd.Parameters.AddWithValue("@copyRight", _News.copyRight);
                cmd.Parameters.AddWithValue("@allowComment", _News.allowComment);
             
                cmd.Parameters.AddWithValue("@AccountTypeId", _News.AccountTypeId);
              
                cmd.Parameters.AddWithValue("@UrlSource", _News.UrlSource);
             
                cmd.Parameters.AddWithValue("@newsTypeMessage", _News.newsTypeMessage);
                cmd.Parameters.AddWithValue("@newsId", _News.newsId);
                 
                con.Open();
                cmd.ExecuteNonQuery();
                result = _News.newsId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Updatecms_News: " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }
    }
}
