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
    public class ImptblReportRevenue : ItblReportRevenue
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(tblReportRevenue entity)
        {
            string result = string.Empty;
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.ExecuteInsert("tbl_RevenueResult_Insert", entity.MaBN, entity.S_ID, entity.HoTen, entity.UserTC, entity.NgayThu, entity.TongCP, entity.PhiDiLai, entity.TienMat, entity.ThePOS, entity.TraTruoc, entity.ChKhoan, entity.TraSau, entity.TienGG, entity.ThucThu, entity.BHTT, entity.BHBLTT, entity.TienDiemPID, entity.TraKhach, entity.CDHA, entity.TDCN, entity.XN, entity.TenGG, entity.SumAgree,   entity.useridAgree, entity.levelAgree,   entity.IDSouce, entity.LocationID, entity.Typeagree, entity.IDCLS);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        //public bool ConvertToReportRevenue(tblReportRevenue entity, )
        //{
        //    throw new NotImplementedException();
        //}


        public string Delete(tblReportRevenue entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public tblReportRevenue Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<tblReportRevenue> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string tblReportRevenueDelete(Int64 MaBN, string S_ID, string useridAgree)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.ExecuteNonQuery("tbl_RevenueResult_Delete", MaBN, S_ID, useridAgree);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + MaBN.ToString() + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string tblReportRevenueSendNoti(  string S_ID )
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.ExecuteNonQuery("tbl_Patient_AutoSendAlertBySID",   S_ID);
            }
            catch (Exception ex)
            {
                logError.Info("tblReportRevenueSendNoti: " + S_ID.ToString() + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string tblReportRevenueSendNotiNotAgree(string S_ID)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.ExecuteNonQuery("tbl_Patient_AutoSendAlertNotAgreeBySID", S_ID);
            }
            catch (Exception ex)
            {
                logError.Info("tbl_Patient_AutoSendAlertNotAgreeBySID: " + S_ID.ToString() + "  " + ex.ToString());
                return string.Empty;
            }
        }
        public string tblReportRevenueAccuracy( string useridAgree)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.ExecuteNonQuery("tbl_Patient_updateByAccuracy",  useridAgree);
            }
            catch (Exception ex)
            {
                logError.Info("tblReportRevenueAccuracy: " + useridAgree.ToString() + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string tblReportRevenueAccuracyDate(string useridAgree, string ngaythu)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.ExecuteNonQuery("tbl_Patient_updateByAccuracyByDate", useridAgree, ngaythu);
            }
            catch (Exception ex)
            {
                logError.Info("tblReportRevenueAccuracy: " + useridAgree.ToString() + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string Update(tblReportRevenue entity)
        {
            throw new NotImplementedException();
        }
    }
}
