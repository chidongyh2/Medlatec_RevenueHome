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
    public class ImpCMS_SERVICE_TYPE : ICMS_SERVICE_TYPE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_SERVICE_TYPE entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_SERVICE_TYPE entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_SERVICE_TYPE entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_SERVICE_TYPE entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CMS_SERVICE_TYPE Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE_TYPE> sQLServer = new OracleServerConnection<CMS_SERVICE_TYPE>();
                var data = sQLServer.SelectQueryCommand("sp_cms_service_type_bypid", id, PARTNERID);
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

        public CMS_SERVICE_TYPE Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_SERVICE_TYPE> GetAll(int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public List<CMS_SERVICE_TYPE> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Publish(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_SERVICE_TYPE entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_SERVICE_TYPE entity)
        {
            throw new NotImplementedException();
        }
    }
}
