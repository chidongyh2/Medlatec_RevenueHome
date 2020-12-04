using Memcached.ClientLibrary;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace CMS_Core.Common
{
    public class Common
    {
        #region Properties
        public static string keyDecrypt = "MedCOm20190401";
        private static string ConnStrOracle = ConfigurationSettings.AppSettings["ConnStrOracle"];

        private static string ConnStr = CMS_Core.Common.AES.Decrypt(ConfigurationSettings.AppSettings["ConnStr"], keyDecrypt) ;
        private static string ConnStrRevenue = CMS_Core.Common.AES.Decrypt(ConfigurationSettings.AppSettings["ConnStrRevenue"], keyDecrypt);
        private static string CMSNEWLogError = ConfigurationSettings.AppSettings["CMSLISLogError"];
        private static string ImagePath = ConfigurationSettings.AppSettings["ImagePath"];
        public static MemcachedClient mc;
        private static Random rnd = new Random();
        #endregion Properties

        #region private

        /// <summary>
        /// get Connection
        /// </summary>        
        /// <returns></returns> 
        public static string getConnectionString()
        {
            return ConnStr;
        }

        public static string getConnectionStringRevenue()
        {
            return ConnStrRevenue;
        }
        /// <summary>
        /// get Memcached
        /// </summary>        
        /// <returns></returns> 
        public static MemcachedClient getMemcacheInstance()
        {
            if (mc == null)
            {
                mc = new MemcachedClient();
            }
            return mc;
        }

        /// <summary>
        /// get connect Oracle
        /// </summary>        
        /// <returns></returns> 
        public static string getConnStrOracle()
        {

            return ConnStrOracle;
        }

        /// <summary>
        /// get connect Log4net
        /// </summary>        
        /// <returns></returns> 
        public static string getCMSNEWLogError()
        {

            return CMSNEWLogError;
        }


        public static string getRandom()
        {
            return rnd.Next(999999999).ToString();
        }

        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>,~^";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }


        public static bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;

            return input.Any(c => c > MaxAnsiCode);
        }

        /// <summary>
        /// convert object  
        /// </summary>
        /// <param name="obj">input</param>
        /// <returns></returns>
        public static string FmtAmt(object obj)
        {
            try
            {
                double dobj = double.Parse(obj.ToString());
                CultureInfo cultureToUse = new CultureInfo("en-GB");

                string ss = dobj.ToString("N", cultureToUse);
                ss = ss.Replace(".00", "");
                return ss;
            }
            catch
            {
                return convertString(obj);
            }
        }

        /// <summary>
        /// convert object to string
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static string convertString(object obj)
        {
            try
            {
                return obj.ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        //public static Image Base64ToImage(string base64String)
        //{
        //    // Convert Base64 String to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);

        //    return image;
        //}

        #endregion


    }
}
