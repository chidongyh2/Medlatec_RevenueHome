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
    public class ImpCMS_MEDICINE_INVENTORY : ICMS_MEDICINE_INVENTORY
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_MEDICINE_INVENTORY entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_MEDICINE_INVENTORY entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_MEDICINE_INVENTORY entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_MEDICINE_INVENTORY entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CMS_MEDICINE_INVENTORY Get(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public CMS_MEDICINE_INVENTORY Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_MEDICINE_INVENTORY> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE_INVENTORY> sQLServer = new OracleServerConnection<CMS_MEDICINE_INVENTORY>();
                return sQLServer.SelectQueryCommand("SP_MEDICINE_INVENTORY_ALL", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE_INVENTORY> GetAll()
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

        public string Update(CMS_MEDICINE_INVENTORY entity, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_MEDICINE_INVENTORY entity)
        {
            throw new NotImplementedException();
        }
    }
}
