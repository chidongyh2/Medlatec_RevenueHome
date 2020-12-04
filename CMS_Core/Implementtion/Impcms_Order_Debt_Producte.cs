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
    public class Impcms_Order_Debt_Producte : Icms_Order_Debt_Producte
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_Order_Debt_Producte entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                return sQLServer.ExecuteInsert("SP_cms_Order_Debt_Producte_Insert", entity.BillTotal, entity.ProducerID, entity.TENNSX, entity.BillNote,entity.BillDate, entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_Order_Debt_Producte entity)
        {
            try
            {
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Debt_Producte_DeleteByPrimaryKey", entity.ID);
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
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Debt_Producte_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_Order_Debt_Producte Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Order_Debt_Producte_SelectID", id);
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

        public cms_Order_Debt_Producte GetExit(float BillTotal, int ProducerID, string BillNote)
        {
            try
            {
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Order_Debt_Producte_Exit", BillTotal, ProducerID, BillNote, DateTime.Now);
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

        public List<cms_Order_Debt_Producte> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_Debt_Producte_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order_Debt_Producte> Getcms_Order_Debt_ProducteByProducerID(int ProducerID)
        {
            try
            {
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_Debt_Producte_SelectByProducerID", ProducerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_Order_Debt_Producte> Getcms_Order_Debt_ProducteByStatus(string startdate, string enddate, int ProducerID, int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                return sQLServer.SelectQueryCommand("SP_cms_Order_Debt_Producte_SelectSTATUS", startdate, enddate, ProducerID, status, typeKeyword, keyword);
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
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                return sQLServer.ExecuteNonQuery("SP_cms_Order_Debt_Producte_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_Order_Debt_Producte entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Order_Debt_Producte> sQLServer = new SQLServerConnection<cms_Order_Debt_Producte>();
                return sQLServer.ExecuteInsert("SP_cms_Order_Debt_Producte_Update", entity.ID, entity.BillTotal, entity.ProducerID, entity.TENNSX, entity.BillNote, entity.BillDate, entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
