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
    public class Impcms_customer_Material : Icms_customer_Material
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_customer_Material entity)
        {

            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.ExecuteInsert("SP_cms_customer_Material_Insert", entity.CustomerID, entity.MaterialID, entity.MaterialName, entity.MaterialUnit, entity.Amount, entity.Price, entity.TotalPrice, entity.CreateBy, entity.ProducerID, entity.OrderID, entity.customer_MaterialID, entity.note);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_customer_Material entity)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.ExecuteNonQuery("SP_cms_customer_Material_DeleteByPrimaryKey", entity.id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.ExecuteNonQuery("SP_cms_customer_Material_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_customer_Material Get(int id)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                var data = sQLServer.SelectQueryCommand("SP_cms_customer_Material_SelectByPrimaryKey", id);
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

        public cms_customer_Material GetExit(int MaterialID, int OrderID, float Amount)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                var data = sQLServer.SelectQueryCommand("SP_cms_customer_Material_SelectByExit", MaterialID, OrderID, Amount,DateTime.Now);
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


        public List<cms_customer_Material> GetAll()
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_Material_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_customer_Material> Getcms_customer_MaterialByCustomerID(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_Material_SelectByCustomerID", CustomerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_customer_Material> Getcms_customer_MaterialByProducerID(int ProducerID)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_Material_SelectByProducerID", ProducerID);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_customer_MaterialByProducerID: " + ex.ToString());
                return null;
            }
        }

        public List<cms_customer_Material> Getcms_customer_MaterialByProducerIDNoDebt(int ProducerID)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_Material_SelectByProducerIDNoDebt", ProducerID);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_customer_MaterialByProducerID: " + ex.ToString());
                return null;
            }
        }

        public List<Dashboard_Index> Getcms_customer_MaterialByTotalProducerIDNoDebt(int ProducerID)
        {
            try
            {
                SQLServerConnection<Dashboard_Index> sQLServer = new SQLServerConnection<Dashboard_Index>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_Material_TotalByProducerIDNoDebt", ProducerID);
            }
            catch (Exception ex)
            {
                logError.Info("Getcms_customer_MaterialByTotalProducerIDNoDebt: " + ex.ToString());
                return null;
            }
        }

        public string UpdateDebt(int ProducerID, int id, int isDebt, float TotalDebt,DateTime DateDebt, int DebtBill)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.ExecuteInsert("SP_cms_customer_Material_UpdateDebt", ProducerID, id, isDebt, TotalDebt, DateDebt, DebtBill);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string DeeteDebtByDebtBill(  int DebtBill)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.ExecuteInsert("SP_cms_customer_Material_DeeteDebtByDebtBill",  DebtBill);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public List<cms_customer_Material> Getcms_customer_MaterialByOrderID(int OrderID)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_Material_SelectByOrderID", OrderID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }
        public List<cms_customer_Material> Getcms_customer_MaterialByCustomerIDAll(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_Material_SelectByCustomerIDAll", CustomerID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<cms_customer_Material> Getcms_customer_MaterialByCustomerIDDelete(int CustomerID)
        {
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_customer_Material_SelectByCustomerIDDelete", CustomerID);
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
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.ExecuteNonQuery("SP_cms_customer_Material_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_customer_Material entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_customer_Material> sQLServer = new SQLServerConnection<cms_customer_Material>();
                return sQLServer.ExecuteInsert("SP_cms_customer_Material_Update", entity.id, entity.CustomerID, entity.MaterialID, entity.MaterialName, entity.MaterialUnit, entity.Amount, entity.Price, entity.TotalPrice, entity.UpdateBy, entity.ProducerID, entity.OrderID, entity.note);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
