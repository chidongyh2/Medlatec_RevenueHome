using CMS_Core.Common;
using CMS_Core.Entity;
using CMS_Core.Interface;
using CMS_Core.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Implementtion
{
    public class IMPCMS_PATIENTINFO_TOTAL : ICMS_PATIENTINFO_TOTAL
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public List<CMS_PATIENTINFO_TOTAL> GetCMS_PATIENTINFO_TOTALByID(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_TOTAL> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_TOTAL>();
                return sQLServer.SelectQueryCommand("SP_PATIENTINFO_SELECT_BYPID", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_TOTALByID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO_TOTAL> GetCMS_PATIENTINFO_TOTALByALL(PatientViewModel viewModel, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_TOTAL> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_TOTAL>();
                return sQLServer.SelectQueryCommand("SP_PATIENTINFO_BYKeyword", viewModel.tungay, viewModel.denngay, viewModel.keyword, viewModel.TypeKeyword, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_TOTALByID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO_TOTAL> GetCMS_PATIENTINFO_TOTALByALL(DateTime start, DateTime end, string keyword, int typeKeyword, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_TOTAL> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_TOTAL>();
                return sQLServer.SelectQueryCommand("SP_PATIENTINFO_BYKeyword", start, end, keyword, typeKeyword, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_TOTALByALL: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO> GetCMS_PATIENTINFO_TOTALByWeirdo(DateTime start, DateTime end, string keyword, int typeKeyword, int Weirdo,int SERVICETYPE,  int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO> sQLServer = new OracleServerConnection<CMS_PATIENTINFO>();
                return sQLServer.SelectQueryCommand("SP_PATIENTINFO_BYWeirdo", start, end, keyword, typeKeyword, Weirdo, SERVICETYPE, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_TOTALByWeirdo: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO_TOTAL> GetCMS_PATIENTINFO_TOTALByInsurrance(DateTime start, DateTime end, string keyword, int typeKeyword, int Insurrance, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_TOTAL> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_TOTAL>();
                return sQLServer.SelectQueryCommand("SP_PATIENTINFO_BYINSURRANCE", start, end, keyword, typeKeyword, Insurrance, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_TOTALByInsurrance: " + ex.ToString());
                return null;
            }
        }

    }
}
