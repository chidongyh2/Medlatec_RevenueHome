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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Implementtion
{
    public class ImpAccount_Login : IAccount_Login
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<Account_Login> GetAccount_LoginByUserName(string Username)
        {
            try
            {
                SQLServerConnection<Account_Login> sQLServer = new SQLServerConnection<Account_Login>();
                return sQLServer.SelectQueryCommand("SP_account_login_ByUsername", Username);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllAccount_Login: " + ex.ToString());
                return null;
            }             
        }

        public List<Account_Login> GetAccount_LoginByUserID(int userid)
        {
            try
            {
                SQLServerConnection<Account_Login> sQLServer = new SQLServerConnection<Account_Login>();
                return sQLServer.SelectQueryCommand("SP_account_login_ByUserID", userid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllAccount_Login: " + ex.ToString());
                return null;
            }
        }

        public List<Account_Login> GetAccount_LoginNOKByUserID(int userid)
        {
            try
            {
                SQLServerConnection<Account_Login> sQLServer = new SQLServerConnection<Account_Login>();
                return sQLServer.SelectQueryCommand("SP_account_login_NOKByUserID", userid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAccount_LoginNOKByUserID: " + ex.ToString());
                return null;
            }
        }

        public List<Account_Login> GetAccount_LoginNOKByUsername(string Username)
        {
            try
            {
                SQLServerConnection<Account_Login> sQLServer = new SQLServerConnection<Account_Login>();
                return sQLServer.SelectQueryCommand("SP_account_login_NOKByUserName", Username);
            }
            catch (Exception ex)
            {
                logError.Info("GetAccount_LoginNOKByUsername: " + ex.ToString());
                return null;
            }
        }


        public List<Account_Login> GetAllAccount_Login()
        {
            try
            {
                SQLServerConnection<Account_Login> sQLServer = new SQLServerConnection<Account_Login>();
                return sQLServer.SelectQueryCommand("SP_account_login_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAllAccount_Login: " + ex.ToString());
                return null;
            }             
        }

        public string InsertAccount_Login(Account_Login account_Login)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<Account_Login> sQLServer = new SQLServerConnection<Account_Login>();
                return sQLServer.ExecuteInsert("SP_account_login_Insert", account_Login.Username,   account_Login.IP, account_Login.Status, account_Login.Userid);
            }
            catch (Exception ex)
            {
                logError.Info("InsertAccount_Login: " + ex.ToString());
                return result = string.Empty;
            }             
        }

        

        public Account_Login Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Account_Login> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Add(Account_Login entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(Account_Login entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(Account_Login entity)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
