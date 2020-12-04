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
    public class Imptbl_Patient : Itbl_Patient
    {
        readonly ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(tbl_Patient entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(tbl_Patient entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public tbl_Patient Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<tbl_Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<tblReportRevenue> Gettbl_PatientByAll(string Groupid, string Locationid, string userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_BYuserid", Groupid, Locationid, userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByAll: " + ex.ToString());
                return null;
            }
        }


        public List<tblReportRevenue> Gettbl_PatientByUserAgree( string userid, string datetime)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_ByUserAgree", userid, datetime);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUserAgree: " + ex.ToString());
                return null;
            }
        }

        public List<tblReportRevenue> tbl_Revenue_SignInsert(string userid, string NgayThu, string pathpdf, string LocationName, string GroupName)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Revenue_Sign$Insert", userid, NgayThu, pathpdf, LocationName, GroupName);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUserAgree: " + ex.ToString());
                return null;
            }
        }

        public List<tblReportRevenue> tbl_Revenue_SignUpdate(string userid, string NgayThu, string pathpdf )
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Revenue_Sign$Update", userid, NgayThu, pathpdf );
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUserAgree: " + ex.ToString());
                return null;
            }
        }


        public List<tblReportRevenue> Gettbl_Patient_TotalInvoiceByUsser(string userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_TotalInvoiceByUsser", userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("tbl_Patient_TotalInvoiceByUsser: " + ex.ToString());
                return null;
            }
        }


        public List<tblReportRevenue> Gettbl_Patient_TotalInvoiceByUserAgree(string userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_TotalInvoiceByUsserAgree", userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("tbl_Patient_TotalInvoiceByUsser: " + ex.ToString());
                return null;
            }
        }


        public List<tblReportRevenue> Gettbl_Patient_TotalInvoiceByUserDate(string userid,string ngaythu, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_TotalInvoiceByUserDate", userid, ngaythu, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("tbl_Patient_TotalInvoiceByUsser: " + ex.ToString());
                return null;
            }
        }

        public List<tblReportRevenue> Gettbl_Patient_TotalInvoiceByUserDateAgree(string userid, string ngaythu, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_TotalInvoiceByUserDateAgree", userid, ngaythu, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("tbl_Patient_TotalInvoiceByUsser: " + ex.ToString());
                return null;
            }
        }
        public List<tblReportRevenue> Gettbl_PatientByUserAgree(string userid)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_ByUserAgree_new", userid);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUserAgree: " + ex.ToString());
                return null;
            }
        }



        public List<tblReportRevenue> Gettbl_PatientTotalByAll(string Groupid, string Locationid, string userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_TotalInvoice", Groupid,Locationid, userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientTotalByAll: " + ex.ToString());
                return null;
            }
        }

        public List<tblReportRevenue> Gettbl_PatientTotalByAgree(string tungay, string denngay, string Groupid, string Locationid, string userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_TotalInvoiceAgree", tungay, denngay, Groupid, Locationid, userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("tbl_Patient_TotalInvoiceAgree: " + ex.ToString());
                return null;
            }
        }

        public List<tblReportRevenue> Gettbl_PatientByAgreeAll(string tungay, string denngay, string Groupid, string Locationid, string userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_TotalAgree_new", tungay, denngay, Groupid, Locationid, userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("tbl_Patient_TotalInvoiceAgree: " + ex.ToString());
                return null;
            }
        }


        public List<tblReportRevenue> Gettbl_PatientTotalByAllDay(string tungay, string denngay, string Groupid, string Locationid, string userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_TotalInvoiceByDate", tungay, denngay, Groupid, Locationid, userid, typeKeyword, keyword);                 
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientTotalByAllDay: " + ex.ToString());
                return null;
            }
        }

        public List<tblReportRevenue> Gettbl_PatientByAllDay(string tungay, string denngay, string Groupid, string Locationid, string userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_AllUser", tungay, denngay, Groupid, Locationid, userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByAllDay: " + ex.ToString());
                return null;
            }
        }



        public List<tblReportRevenue> Gettbl_PatientByAllPay(string startdate, string enddate, int Payment, string userid, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_BYAll", startdate, enddate, Payment, userid, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByAllPay: " + ex.ToString());
                return null;
            }
        }

        public List<tblReportRevenue> Gettbl_PatientByUserid(string UserID, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_PatientByUserid", UserID, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByAll: " + ex.ToString());
                return null;
            }
        }
        public List<tblReportRevenue> Gettbl_PatientByUseridAndDay(string UserID, int typeKeyword, string keyword, string datetime)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_PatientByUseridandDay", UserID, typeKeyword, keyword, datetime);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUseridAndDay: " + ex.ToString());
                return null;
            }
        }
        public List<tblReportRevenue> Gettbl_PatientByUseridDate(string UserID,string date )
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_ByUserDate", UserID, date);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUseridDate: " + ex.ToString());
                return null;
            }
        }


        public List<tblReportRevenue> Gettbl_PatientByUseridNoAgree(string tungay, string denngay, string UserID, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_PatientByUseridNoAgree", tungay, denngay, UserID, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUseridNoAgree: " + ex.ToString());
                return null;
            }
        }


        public List<tblReportRevenue> Gettbl_PatientByUseridAllNoAgree(string tungay, string denngay, string Groupid, string Locationid, string UserID, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_PatientByUseridAllNoAgree", tungay, denngay, Groupid, Locationid, UserID, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUseridAllNoAgree: " + ex.ToString());
                return null;
            }
        }

        public List<tblReportRevenue> Gettbl_PatientByUseridAllNoAgree1(string tungay, string denngay, string Groupid, string Locationid, string UserID, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_PatientByUseridAllNoAgree1", tungay, denngay, Groupid, Locationid, UserID, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUseridAllNoAgree: " + ex.ToString());
                return null;
            }
        }

        public List<tblReportRevenue> Gettbl_PatientByUseridAllNoAgree2(string tungay, string denngay, string Groupid, string Locationid, string UserID, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_PatientByUseridAllNoAgree2", tungay, denngay, Groupid, Locationid, UserID, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByUseridAllNoAgree: " + ex.ToString());
                return null;
            }
        }


        public List<tblReportRevenue> Gettbl_PatientByUseridPay(string startdate, string enddate, int Payment, string UserID, int typeKeyword, string keyword)
        {
            try
            {
                SQLServerConnectionRevenue<tblReportRevenue> sQLServer = new SQLServerConnectionRevenue<tblReportRevenue>();
                return sQLServer.SelectQueryCommand("tbl_Patient_BYDateUserID", startdate, enddate, Payment, UserID, typeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("Gettbl_PatientByAllPay: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(tbl_Patient entity)
        {
            throw new NotImplementedException();
        }
 
    }
}
