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
    public class Impcms_Producer : Icms_Producer
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string Add(cms_Producer entity)
        {
            string result = string.Empty;
            try
            {              
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                return sQLServer.ExecuteInsert("SP_cms_Producer_Insert", entity.TENNSX, entity.DIACHI, entity.SODT, entity.SOFAX, entity.EMAIL, entity.WEBSITE, entity.SANPHAM,  entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public List<cms_Producer> Getcms_ProducerByDebtProducer()
        {
            try
            {
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                return sQLServer.SelectQueryCommand("SP_cms_Producer_SelectDebt");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Delete(cms_Producer entity)
        {
            try
            {
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                return sQLServer.ExecuteNonQuery("SP_cms_Producer_DeleteByPrimaryKey", entity.ID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id)
        {
            try
            {
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                return sQLServer.ExecuteNonQuery("SP_cms_Producer_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_Producer Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Producer_SelectByPrimaryKey", id);
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

        public List<cms_Producer> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                return sQLServer.SelectQueryCommand("SP_cms_Producer_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public cms_Producer Getcms_ProducerByName(string ColorName)
        {
            try
            {
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Producer_SelectByName", ColorName);
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

        public List<cms_Producer> Getcms_ProducerByStatus(int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                return sQLServer.SelectQueryCommand("SP_cms_Producer_SelectSTATUS", status, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id)
        {
            try
            {
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                return sQLServer.ExecuteNonQuery("SP_cms_Producer_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_Producer entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Producer> sQLServer = new SQLServerConnection<cms_Producer>();
                return sQLServer.ExecuteInsert("SP_cms_Producer_Update", entity.ID, entity.TENNSX, entity.DIACHI, entity.SODT, entity.SOFAX, entity.EMAIL, entity.WEBSITE, entity.SANPHAM, entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
