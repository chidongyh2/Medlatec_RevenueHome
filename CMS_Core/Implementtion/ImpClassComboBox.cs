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
    public class ImpClassComboBox : IClassComboBox
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<ClassComboBox> Getcms_CategoryByParent(string SQL, int Parrent, string key)
        {
            try
            {
                string keySQL = SQL;
                keySQL = keySQL.Replace(" ", "+");
                keySQL= Common.AES.Decrypt(keySQL, Common.Constant.Token + key);
                string SQLExecute = String.Format(keySQL, Parrent.ToString());
                SQLExecute = SQLExecute.Replace("\u0010", "");
               

                OracleServerConnection<ClassComboBox> sQLServer = new OracleServerConnection<ClassComboBox>();
                return sQLServer.SelectQuery(SQLExecute);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_CategoryByParent: " + ex.ToString());
                return null;
            }
        }

        public List<ClassComboBox> GetDataBySQL(string SQL)
        {
            try
            {               
                OracleServerConnection<ClassComboBox> sQLServer = new OracleServerConnection<ClassComboBox>();
                return sQLServer.SelectQuery(SQL);
            }
            catch (Exception ex)
            {
                logError.Info("GetDataBySQL: " + ex.ToString());
                return null;
            }
        }

    }
}
