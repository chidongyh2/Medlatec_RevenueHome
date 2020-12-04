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
    public class Impcms_debt_Produce : Icms_debt_Produce
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_debt_Produce entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_debt_Produce> sQLServer = new SQLServerConnection<cms_debt_Produce>();
                return sQLServer.ExecuteInsert("SP_cms_debt_Produce_Insert", entity.ProducerID, entity.Year, entity.Total, entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }
        public string Delete(cms_debt_Produce entity)
        {
            try
            {
                SQLServerConnection<cms_debt_Customer> sQLServer = new SQLServerConnection<cms_debt_Customer>();
                return sQLServer.ExecuteNonQuery("SP_cms_debt_Produce_DeleteByPrimaryKey", entity.ID);
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
                SQLServerConnection<cms_debt_Customer> sQLServer = new SQLServerConnection<cms_debt_Customer>();
                return sQLServer.ExecuteNonQuery("SP_cms_debt_Produce_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_debt_Produce Get(int id)
        {
            try
            {
                SQLServerConnection<cms_debt_Produce> sQLServer = new SQLServerConnection<cms_debt_Produce>();
                var data = sQLServer.SelectQueryCommand("SP_cms_debt_Produce_SelectID", id);
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

        public List<cms_debt_Produce> GetAll()
        {
            try
            {
                SQLServerConnection<cms_debt_Produce> sQLServer = new SQLServerConnection<cms_debt_Produce>();
                return sQLServer.SelectQueryCommand("SP_cms_debt_Produce_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_debt_Produce> Getcms_debt_ProduceByProducerID(int ProducerID)
        {
            try
            {
                SQLServerConnection<cms_debt_Produce> sQLServer = new SQLServerConnection<cms_debt_Produce>();
                return sQLServer.SelectQueryCommand("SP_cms_debt_Produce_SelectByProducerID", ProducerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_debt_Produce> Getcms_debt_ProduceByStatus(string startdate, string enddate, int ProducerID, int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_debt_Produce> sQLServer = new SQLServerConnection<cms_debt_Produce>();
                return sQLServer.SelectQueryCommand("SP_cms_debt_Produce_SelectSTATUS", startdate, enddate, ProducerID, status, typeKeyword, keyword);
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
                SQLServerConnection<cms_debt_Produce> sQLServer = new SQLServerConnection<cms_debt_Produce>();
                return sQLServer.ExecuteNonQuery("SP_cms_debt_Produce_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_debt_Produce entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_debt_Produce> sQLServer = new SQLServerConnection<cms_debt_Produce>();
                return sQLServer.ExecuteInsert("SP_cms_debt_Produce_Update", entity.ID, entity.ProducerID , entity.Year, entity.Total, entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
