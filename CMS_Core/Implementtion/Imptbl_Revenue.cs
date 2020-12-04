using CMS_Core.Common;
using CMS_Core.Entity;
using CMS_Core.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Implementtion
{
    public class Imptbl_Revenue : Itbl_Revenue
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(tbl_Revenue entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnectionRevenue<tbl_Revenue> sQLServer = new SQLServerConnectionRevenue<tbl_Revenue>();
                return sQLServer.ExecuteInsert("tbl_Revenue_Insert1", entity.userid, entity.locationid, entity.sid, entity.testcode, entity.testname, entity.CommentAgree, entity.Typeagree, entity.useridAgree, entity.levelAgree, entity.price, entity.IDSouce, entity.NgayThu, entity.IDCLS, entity.RevenueImages);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string AddTable(DataTable entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnectionRevenue<tbl_Revenue> sQLServer = new SQLServerConnectionRevenue<tbl_Revenue>();
                return sQLServer.ExecuteInsert("usp_tbl_Revenue", entity);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(tbl_Revenue entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public tbl_Revenue Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<tbl_Revenue> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<tbl_Revenue> Gettbl_RevenueBySID(string SID)
        {
            throw new NotImplementedException();
        }

        public List<tbl_Revenue> Gettbl_RevenueByUserid(string Userid)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(tbl_Revenue entity)
        {
            throw new NotImplementedException();
        }
    }
}
