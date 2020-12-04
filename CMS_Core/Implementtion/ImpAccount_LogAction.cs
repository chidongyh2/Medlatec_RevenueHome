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
    public class ImpAccount_LogAction : IAccount_LogAction
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public List<Account_LogAction> GetAccount_LogAction(string Username)
        {

            try
            {
                SQLServerConnection<Account_LogAction> sQLServer = new SQLServerConnection<Account_LogAction>();
                return sQLServer.SelectQueryCommand("SP_account_logaction_Username", Username);
            }
            catch (Exception ex)
            {
                logError.Info("GetAccount_LogAction: " + ex.ToString());
                return null;
            }
             
        }

        public List<Account_LogAction> GetAllAccount_LogAction()
        {
            try
            {
                SQLServerConnection<Account_LogAction> sQLServer = new SQLServerConnection<Account_LogAction>();
                return sQLServer.SelectQueryCommand("SP_account_logaction_All");
            }
            catch (Exception ex)
            {
                logError.Info("GetAllAccount_LogAction: " + ex.ToString());
                return null;
            }
        }

        public string InsertAccount_LogAction(Account_LogAction account_LogAction)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<Account_LogAction> sQLServer = new SQLServerConnection<Account_LogAction>();
                return sQLServer.ExecuteInsert("SP_ACCOUNT_LOGACTION_Insert", account_LogAction.Username, account_LogAction.IP, account_LogAction.menu, account_LogAction.actionType, account_LogAction.logActionID );
            }
            catch (Exception ex)
            {
                logError.Info("InsertAccount_LogAction: " + ex.ToString());
                return result = string.Empty;
            }             
        }
    }
}
