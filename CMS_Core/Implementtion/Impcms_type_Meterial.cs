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
    public class Impcms_type_Meterial : Icms_type_Meterial
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_type_Meterial entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_type_Meterial> sQLServer = new SQLServerConnection<cms_type_Meterial>();
                return sQLServer.ExecuteInsert("SP_cms_type_Meterial_Insert", entity.TypeMeterialName, entity.TypeMeterialDesc,   entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_type_Meterial entity)
        {
            try
            {
                SQLServerConnection<cms_type_Meterial> sQLServer = new SQLServerConnection<cms_type_Meterial>();
                return sQLServer.ExecuteNonQuery("SP_cms_type_Meterial_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_type_Meterial> sQLServer = new SQLServerConnection<cms_type_Meterial>();
                return sQLServer.ExecuteNonQuery("SP_cms_type_Meterial_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_type_Meterial Get(int id)
        {
            try
            {
                SQLServerConnection<cms_type_Meterial> sQLServer = new SQLServerConnection<cms_type_Meterial>();
                var data = sQLServer.SelectQueryCommand("SP_cms_type_Meterial_SelectByPrimaryKey", id);
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

        public List<cms_type_Meterial> GetAll()
        {
            try
            {
                SQLServerConnection<cms_type_Meterial> sQLServer = new SQLServerConnection<cms_type_Meterial>();
                return sQLServer.SelectQueryCommand("SP_cms_type_Meterial_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public cms_type_Meterial Getcms_type_MeterialByName(string type_MeterialrName)
        {
            try
            {
                SQLServerConnection<cms_type_Meterial> sQLServer = new SQLServerConnection<cms_type_Meterial>();
                var data = sQLServer.SelectQueryCommand("SP_cms_type_Meterial_SelectByName", type_MeterialrName);
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

        public List<cms_type_Meterial> Getcms_type_MeterialByStatus(  int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_type_Meterial> sQLServer = new SQLServerConnection<cms_type_Meterial>();
                return sQLServer.SelectQueryCommand("SP_cms_type_Meterial_SelectSTATUS", status, typeKeyword, keyword);
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
                SQLServerConnection<cms_type_Meterial> sQLServer = new SQLServerConnection<cms_type_Meterial>();
                return sQLServer.ExecuteNonQuery("SP_cms_type_Meterial_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_type_Meterial entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_type_Meterial> sQLServer = new SQLServerConnection<cms_type_Meterial>();
                return sQLServer.ExecuteInsert("SP_cms_type_Meterial_Update", entity.id, entity.TypeMeterialName, entity.TypeMeterialDesc,   entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
