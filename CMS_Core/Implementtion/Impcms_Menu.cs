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
    public class Impcms_Menu : Icms_Menu
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public List<cms_Menu> GetAllcms_MenuParent()
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_SelectParrent");
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuParent: " + ex.ToString());
                return null;
            }
        }



        public List<cms_Menu> GetAllcms_MenuChild(int ParentID)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_SelectChild", ParentID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuChild: " + ex.ToString());
                return null;
            }
        }




        public List<cms_Menu> GetAllcms_MenuChild(int ParentID, int status)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_ChildAndStatus", ParentID, status);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuChild: " + ex.ToString());
                return null;
            }

        }

        public List<cms_Menu> GetAllcms_MenuChildByUserid(int ParentID, int status, int userid)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_ChildStatusAndUser", ParentID, status, userid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuChild: " + ex.ToString());
                return null;
            }

        }

        public List<cms_Menu> GetAllcms_MenuChildByGroupID(int ParentID, int GroupID)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("cms_Medicon_get_cms_MenuChildByGroupID",  GroupID, ParentID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuChildByGroupID: " + ex.ToString());
                return null;
            }

        }

        public List<cms_Menu> Getcms_MenuByID(int menId)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_SelectByPrimaryKey", menId);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_MenuByID: " + ex.ToString());
                return null;
            }

        }
         

        public List<cms_Menu> GetAllcms_MenuParentByUserid(int UserID)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_ParentAndUserID", UserID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuParentByUserid: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Menu> GetAllcms_MenuParentByGroupID(int GroupID)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("cms_Medicon_get_cms_MenuParentByGroupID", GroupID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuParentByGroupID: " + ex.ToString());
                return null;
            }
        }


        public List<cms_Menu> GetAllcms_MenuBySortCut(int UserID)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_SortCutByUserID", UserID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuBySortCut: " + ex.ToString());
                return null;
            }
        }



        public List<cms_Menu> GetAllcms_MenuChildByUserid(int ParentID, int UserID)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_ChildAndUserID", ParentID, UserID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuChildByUserid: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Menu> GetAllcms_MenuByUserid(int GroupID)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_SelectUserID", GroupID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuByUserid: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Menu> GetAllcms_MenuByGroupID(int GroupID, int status )
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_SelectGroupID", GroupID, status);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuByGroupID: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Menu> GetAllcms_MenuByGroupID(int GroupIDUser, int GroupID, int status, int type, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_SelectGroupID", GroupIDUser, GroupID, status, type, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuByGroupID: " + ex.ToString());
                return null;
            }
        }


        public List<cms_Menu> GetAllcms_MenuParentByGroupID(int GroupID, int GroupIDUser)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_ParrentByGroupID", GroupID, GroupIDUser);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuParentByGroupID: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Menu> GetAllcms_MenuChildAndGroupID(int ParentID, int GroupID, int GroupIDUser)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_ChildAndGroupID", ParentID, GroupID, GroupIDUser);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_MenuChildAndGroupID: " + ex.ToString());
                return null;
            }
        }

        public cms_Menu Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Menu_SelectByPrimaryKey", id);
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

        public List<cms_Menu> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.SelectQueryCommand("SP_cms_Menu_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Add(cms_Menu entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.ExecuteInsert("SP_cms_Menu_Insert",  entity.menName, entity.menTitle, entity.menKeyword, entity.menDes, entity.menLinks, entity.cateId, entity.menOrd, entity.menImg, entity.MENDISPLAY, entity.MENStatus, entity.Style, entity.CreateBy, entity.Create_date, entity.UpdateBy, entity.Update_date);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_Menu: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_Menu entity)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.ExecuteNonQuery("SP_cms_Menu_DeleteByPrimaryKey", entity.menId);
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_Menu: " + entity.menId + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int GroupIDUser, int id)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.ExecuteNonQuery("SP_cms_Menu_DeleteByPrimaryKeyByGroupIDUser", GroupIDUser, id);
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_Menu: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.ExecuteNonQuery("SP_cms_Menu_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Deletecms_Menu: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_Menu entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.ExecuteNonQuery("SP_cms_Menu_UPDATE", entity.menId, entity.menName, entity.menTitle, entity.menKeyword, entity.menDes, entity.menLinks, entity.cateId, entity.menOrd, entity.menImg, entity.MENDISPLAY, entity.MENStatus, entity.Style, entity.CreateBy, entity.Create_date, entity.UpdateBy, entity.Update_date);
            }
            catch (Exception ex)
            {
                logError.Info("Updatecms_Menu: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Publish(int id)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.ExecuteNonQuery("SP_cms_Menu_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publiccms_Menu: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Publish(int GroupIDUser, int id)
        {
            try
            {
                SQLServerConnection<cms_Menu> sQLServer = new SQLServerConnection<cms_Menu>();
                return sQLServer.ExecuteNonQuery("SP_cms_Menu_PupblicByPrimaryKeyByGroupIDUser", GroupIDUser, id);
            }
            catch (Exception ex)
            {
                logError.Info("Publiccms_Menu: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

    }
}
