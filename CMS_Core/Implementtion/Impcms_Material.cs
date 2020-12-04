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
    public class Impcms_Material : Icms_Material
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(cms_Material entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_Material> sQLServer = new SQLServerConnection<cms_Material>();
                return sQLServer.ExecuteInsert("SP_cms_Material_Insert", entity.MaterialName, entity.MaterialDesc, entity.MaterialHeight, entity.MaterialWidht, entity.MaterialUnit, entity.MaterialCateID, entity.ProducerID, entity.MaterialColor, entity.MaterialType, entity.MaterialPrice,  entity.CreateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(cms_Material entity)
        {
            try
            {
                SQLServerConnection<cms_Material> sQLServer = new SQLServerConnection<cms_Material>();
                return sQLServer.ExecuteNonQuery("SP_cms_Material_DeleteByPrimaryKey", entity.id);
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
                SQLServerConnection<cms_Material> sQLServer = new SQLServerConnection<cms_Material>();
                return sQLServer.ExecuteNonQuery("SP_cms_Material_DeleteByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public cms_Material Get(int id)
        {
            try
            {
                SQLServerConnection<cms_Material> sQLServer = new SQLServerConnection<cms_Material>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Material_SelectByPrimaryKey", id);
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

        public List<cms_Material> GetAll(int MaterialID)
        {
            try
            {
                SQLServerConnection<cms_Material> sQLServer = new SQLServerConnection<cms_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_Material_SelectByID", MaterialID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }


        public List<cms_Material> GetAll()
        {
            try
            {
                SQLServerConnection<cms_Material> sQLServer = new SQLServerConnection<cms_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_Material_SelectAll");
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public cms_Material Getcms_MaterialByName(string MaterialName, int ProducerID)
        {
            try
            {
                SQLServerConnection<cms_Material> sQLServer = new SQLServerConnection<cms_Material>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Material_SelectByName", MaterialName, ProducerID);
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

        public cms_Material Getcms_MaterialByName(string MaterialName )
        {
            try
            {
                SQLServerConnection<cms_Material> sQLServer = new SQLServerConnection<cms_Material>();
                var data = sQLServer.SelectQueryCommand("SP_cms_Material_SelectByName1", MaterialName );
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


        public List<cms_Material> Getcms_MaterialByStatus(string startdate, string enddate, int MaterialCateID, int MaterialUnit, int ProducerID, int status, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnection<cms_Material> sQLServer = new SQLServerConnection<cms_Material>();
                return sQLServer.SelectQueryCommand("SP_cms_Material_SelectSTATUS", startdate, enddate, MaterialCateID, MaterialUnit, ProducerID, status, typeKeyword, keyword);
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
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                return sQLServer.ExecuteNonQuery("SP_cms_Material_PublicByPrimaryKey", id);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(cms_Material entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnection<cms_item> sQLServer = new SQLServerConnection<cms_item>();
                return sQLServer.ExecuteInsert("SP_cms_Material_Update", entity.id, entity.MaterialName, entity.MaterialDesc, entity.MaterialHeight, entity.MaterialWidht, entity.MaterialUnit, entity.MaterialCateID, entity.ProducerID, entity.MaterialColor, entity.MaterialType, entity.MaterialPrice, entity.UpdateBy);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
