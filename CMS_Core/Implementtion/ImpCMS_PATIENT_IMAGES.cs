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
    public class ImpCMS_PATIENT_IMAGES : ICMS_PATIENT_IMAGES
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_PATIENT_IMAGES entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_SERVICE_RESULT> sQLServer = new OracleServerConnection<CMS_PATIENT_SERVICE_RESULT>();
                return sQLServer.ExecuteInsert("SP_CMS_PATIENT_IMAGES_INSERT", entity.PATIENT_ID, entity.PID, entity.SERVICE_ID, entity.GROUP_SERVICE_ID, entity.PATHIMAGE, entity.CREATEBY, entity.CREATDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.PARTNERID, entity.STATUS);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Add(CMS_PATIENT_IMAGES entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_PATIENT_IMAGES entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_IMAGES> sQLServer = new OracleServerConnection<CMS_PATIENT_IMAGES>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_IMAGES_DELETE", entity.ID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_IMAGES> sQLServer = new OracleServerConnection<CMS_PATIENT_IMAGES>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_IMAGES_DELETE", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(CMS_PATIENT_IMAGES entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CMS_PATIENT_IMAGES Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_IMAGES> sQLServer = new OracleServerConnection<CMS_PATIENT_IMAGES>();
                var data = sQLServer.SelectQueryCommand("SP_CMS_PATIENT_IMAGES_BYID", id, PARTNERID);
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

        public CMS_PATIENT_IMAGES Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_IMAGES> GetAll(int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_IMAGES> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENT_IMAGES> GetCMS_PATIENT_IMAGESByPID(int PID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_IMAGES> sQLServer = new OracleServerConnection<CMS_PATIENT_IMAGES>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_IMAGES_BYPID", PID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENT_IMAGES> GetCMS_PATIENT_IMAGESBySID(int SID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENT_IMAGES> sQLServer = new OracleServerConnection<CMS_PATIENT_IMAGES>();
                return sQLServer.SelectQueryCommand("SP_CMS_PATIENT_IMAGES_BYSID", SID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_PATIENT_IMAGES entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENT_IMAGES> sQLServer = new OracleServerConnection<CMS_PATIENT_IMAGES>();
                return sQLServer.ExecuteNonQuery("SP_CMS_PATIENT_IMAGES_UPDATE", entity.ID, entity.PATIENT_ID, entity.PID, entity.SERVICE_ID, entity.GROUP_SERVICE_ID, entity.PATHIMAGE, entity.CREATEBY, entity.CREATDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.PARTNERID, entity.STATUS);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Update(CMS_PATIENT_IMAGES entity)
        {
            throw new NotImplementedException();
        }
    }
}
