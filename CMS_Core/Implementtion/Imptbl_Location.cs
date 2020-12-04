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
    public class Imptbl_Location : Itbl_Location
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(tbl_Location entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(tbl_Location entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public tbl_Location Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<tbl_Location> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<tbl_Location> Gettbl_LocationByGroupID(string GroupID)
        {
            try
            {
                SQLServerConnectionRevenue<tbl_Location> sQLServer = new SQLServerConnectionRevenue<tbl_Location>();
                return sQLServer.SelectQueryCommand("tbl_Location_ByLocation_L2", GroupID);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByGroupID: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(tbl_Location entity)
        {
            throw new NotImplementedException();
        }
    }
}
