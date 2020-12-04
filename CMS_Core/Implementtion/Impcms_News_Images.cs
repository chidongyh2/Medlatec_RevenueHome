using CMS_Core.Entity;
using CMS_Core.Interface;
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
    
    public class Impcms_News_Images : Icms_News_Images
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Insertcms_News_Images(cms_News_Images _News_Images)
        {
            SqlConnection con = null;
            string result = string.Empty;
            try
            {
                con = new SqlConnection(Common.Common.getConnectionString());
                SqlCommand cmd = new SqlCommand("SP_cms_News_Images_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Image", _News_Images.Image);
                cmd.Parameters.AddWithValue("@newsId", _News_Images.newsId);
                cmd.Parameters.AddWithValue("@Type", _News_Images.Type);

                con.Open();
                cmd.ExecuteNonQuery();
                result = _News_Images.newsId.ToString();
                return result;
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_News_Images: " + ex.ToString());
                return result = string.Empty;

            }
            finally
            {
                con.Close();
            }
        }
    }
}
