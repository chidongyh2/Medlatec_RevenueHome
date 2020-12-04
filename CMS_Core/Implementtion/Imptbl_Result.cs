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
    public class Imptbl_Result : Itbl_Result
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(tbl_Result entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(tbl_Result entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public tbl_Result Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<tbl_Result> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<VP> Gettbl_ResultBySID(string userid, string sid, Int64 mabn, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<VP> sQLServer = new SQLServerConnectionRevenue<VP>();
                return sQLServer.SelectQueryCommand("tbl_ResultBySID", userid,sid, mabn, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_ResultBySID: " + ex.ToString());
                return null;
            }
        }

        public List<tbl_Result> Gettbl_ResultByUserid(string Userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tbl_Result> sQLServer = new SQLServerConnectionRevenue<tbl_Result>();
                return sQLServer.SelectQueryCommand("tbl_ResultByUserInvoice", Userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_ResultByUserid: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(tbl_Result entity)
        {
            throw new NotImplementedException();
        }
    }
}
