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
    public class ImpCms_Account : Icms_Account
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string Add(cms_Account entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteInsert("SP_cms_Account_Insert",   entity.Username, entity.Password, entity.Email, entity.IsFirstLogin, entity.LastLogin, entity.AccountTypeId, entity.Hoten, entity.Mobile, entity.Ghichu, entity.CreateBy, entity.Create_date, entity.Ngaysinh, entity.Sothich, entity.Fb, entity.instagram, entity.AccountLis);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public List<cms_Account> ChangePasswordCms_Account(int uid, string Password)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.SelectQueryCommand("SP_cms_Account_ChangePassword", uid, Password);
            }
            catch (Exception ex)
            {
                logError.Info("ChangePasswordCms_Account: " + ex.ToString());
                return null;
            }            
        }

       
        public string Delete(cms_Account entity)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteNonQuery("SP_cms_Account_DeleteByPrimaryKey",   entity.uid);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.uid + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteNonQuery("SP_cms_Account_DeleteByPrimaryKey",  id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int GroupIDUser, int CreateBy, int id)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteNonQuery("SP_cms_Account_DeleteByPrimaryKeyNew", GroupIDUser, CreateBy,  id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string Deletecms_Account(cms_Account _Account)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteNonQuery("SP_cms_Account_DeleteByPrimaryKey", _Account.uid);
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_Account: " + _Account.uid + "  " + ex.ToString());
                return string.Empty;
            }             
        }

        public cms_Account Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Account_SelectByPrimaryKey", id);
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        return data[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logError.Info("Get: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Account> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.SelectQueryCommand("SP_cms_Account_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Account> GetAllcms_AccountByStatus( int ACCOUNTTYPEID,int accounttypeid, int STATUS, int type, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.SelectQueryCommand("SP_cms_Account_SelectSTATUS", ACCOUNTTYPEID, accounttypeid, STATUS, type, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCATEGORYS: " + ex.ToString());
                return null;
            }
        }

        //public List<Sys_User> Getcms_Account(string Username, string Password)
        //{
        //    try
        //    {
        //        SQLServerConnection<Sys_User> sQLServer = new SQLServerConnection<Sys_User>();
        //        return sQLServer.SelectQueryCommand("SP_cms_Account_Login_New", Username, Password);
        //    }
        //    catch (Exception ex)
        //    {
        //        logError.Info("Getcms_Account: " + ex.ToString());
        //        return null;
        //    }             
        //}

        public List<cms_Account> Getcms_Account(string Username, string Password)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.SelectQueryCommand("SP_cms_Account_Login", Username, Password);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_Account: " + ex.ToString());
                return null;
            }
        }

        //public List<Sys_User> Getcms_Account(string Username, string Password)
        //{
        //    try
        //    {
        //        SQLServerConnection<Sys_User> sQLServer = new SQLServerConnection<Sys_User>();
        //        return sQLServer.SelectQueryCommand("SP_cms_Account_Login_New", Username, Password);
        //    }
        //    catch (Exception ex)
        //    {
        //        logError.Info("Getcms_Account: " + ex.ToString());
        //        return null;
        //    }
        //}

        public List<cms_Account> Getcms_AccountByUserName(string Username)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.SelectQueryCommand("SP_cms_Account_SelectByField", "Username",Username);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_AccountByUserName: " + ex.ToString());
                return null;
            }
             
        }

        public List<cms_Account> Getcms_AccountByUserUid(string uid)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.SelectQueryCommand("SP_cms_Account_SelectByField", "uid", uid);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_AccountByUserUid: " + ex.ToString());
                return null;
            }

        }

        //public List<Sys_User> Getcms_AccountByUserUid(string uid )
        //{
        //    try
        //    {
        //        SQLServerConnection<Sys_User> sQLServer = new SQLServerConnection<Sys_User>();
        //        return sQLServer.SelectQueryCommand("Sys_User_SelectByField", uid);
        //    }
        //    catch (Exception ex)
        //    {
        //        logError.Info("Getcms_AccountByUserUid: " + ex.ToString());
        //        return null;
        //    }
             
        //}
    
        public string Publish(int id)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteNonQuery("SP_cms_Account_UpdateByPrimaryKey",  id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Publish(int GroupIDUser, int CreateBy, int id)
        {
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteNonQuery("SP_cms_Account_PublicByPrimaryKey", GroupIDUser, CreateBy, id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string Update(cms_Account entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteInsert("SP_cms_Account_Update", entity.uid, entity.Username, entity.Password, entity.Email, entity.IsFirstLogin, entity.LastLogin, entity.AccountTypeId, entity.Hoten, entity.Mobile, entity.Ghichu, entity.UpdateBy, entity.Update_date, entity.Ngaysinh, entity.Sothich, entity.Fb, entity.instagram, entity.AccountLis);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }


        public string UpdateProfile(cms_Account entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Account> sQLServer = new SQLServerConnection<cms_Account>();
                return sQLServer.ExecuteInsert("SP_cms_Account_Update_Profile", entity.uid, entity.Username, entity.Password, entity.Email, entity.IsFirstLogin, entity.LastLogin, entity.AccountTypeId, entity.Hoten, entity.Mobile, entity.Ghichu, entity.UpdateBy, entity.Update_date, entity.Ngaysinh, entity.Sothich, entity.Fb, entity.instagram );
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

    }
}
