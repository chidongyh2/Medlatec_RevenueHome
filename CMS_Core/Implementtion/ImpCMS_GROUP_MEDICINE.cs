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
    public class ImpCMS_GROUP_MEDICINE : ICMS_GROUP_MEDICINE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string DeleteCMS_GROUP_MEDICINE(CMS_GROUP_MEDICINE _GROUP_MEDICINE, int partnerid)
        {
            try
            {
                OracleServerConnection<cms_Category> sQLServer = new OracleServerConnection<cms_Category>();
                return sQLServer.ExecuteNonQuery("SP_CMS_GROUP_MEDICINE_DELETE", _GROUP_MEDICINE.ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_GROUP_MEDICINE: " + _GROUP_MEDICINE.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_GROUP_MEDICINE(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<cms_Category> sQLServer = new OracleServerConnection<cms_Category>();
                return sQLServer.ExecuteNonQuery("SP_CMS_GROUP_MEDICINE_DELETE", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_GROUP_MEDICINE: " + Id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_GROUP_MEDICINE> GetCMS_GROUP_MEDICINE(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.SelectQueryCommand("SP_CMS_GROUP_MEDICINE_ALL", partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_GROUP_MEDICINE: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_GROUP_MEDICINE> GetCMS_GROUP_MEDICINENew()
        {
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.SelectQueryCommand("GetCMS_GROUP_MEDICINE234");
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_GROUP_MEDICINE: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_GROUP_MEDICINE> GetAllCMS_GROUP_MEDICINEByStatus(int parentid, int status, int partneridInput, int partneridUser)
        {
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.SelectQueryCommand("SP_CMS_GROUP_MEDICINE_BYSTATUS", parentid, status, partneridInput,partneridUser);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllcms_CategoryByStatus: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_GROUP_MEDICINE> GetCMS_GROUP_MEDICINEByID(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.SelectQueryCommand("SP_CMS_GROUP_MEDICINE_BYID", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_GROUP_MEDICINEByID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_GROUP_MEDICINE> GetCMS_GROUP_MEDICINEByName(string Name, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.SelectQueryCommand("SP_CMS_GROUP_MEDICINE_BYNAME", Name, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_GROUP_MEDICINEByName: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_GROUP_MEDICINE> GetCMS_GROUP_MEDICINEParent(int partnerid)
        {
            throw new NotImplementedException();
        }

        public string InsertCMS_GROUP_MEDICINE(CMS_GROUP_MEDICINE _GROUP_MEDICINE)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.ExecuteInsert("SP_CMS_GROUP_MEDICINE_Insert", _GROUP_MEDICINE.GROUP_MEDICINE_NAME, _GROUP_MEDICINE.GROUP_MEDICINE_DESC, _GROUP_MEDICINE.GROUP_MEDICINE_PARENT, _GROUP_MEDICINE.GROUP_MEDICINE_STATUS, _GROUP_MEDICINE.GROUP_MEDICINE_CREATEBY, _GROUP_MEDICINE.GROUP_MEDICINE_CREATEDATE, _GROUP_MEDICINE.GROUP_MEDICINE_UPDATEBY, _GROUP_MEDICINE.GROUP_MEDICINE_UPDATEDATE, _GROUP_MEDICINE.PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Insertcms_Category: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string PUBLICCMS_GROUP_MEDICINE(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<cms_Category> sQLServer = new OracleServerConnection<cms_Category>();
                return sQLServer.ExecuteNonQuery("SP_CMS_GROUP_MEDICINE_PUBLIC", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("PUBLICCMS_GROUP_MEDICINE: " + Id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string UpdateCMS_GROUP_MEDICINE(CMS_GROUP_MEDICINE _GROUP_MEDICINE)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_GROUP_MEDICINE_Update", _GROUP_MEDICINE.ID, _GROUP_MEDICINE.GROUP_MEDICINE_NAME, _GROUP_MEDICINE.GROUP_MEDICINE_DESC, _GROUP_MEDICINE.GROUP_MEDICINE_PARENT, _GROUP_MEDICINE.GROUP_MEDICINE_STATUS, _GROUP_MEDICINE.GROUP_MEDICINE_CREATEBY, _GROUP_MEDICINE.GROUP_MEDICINE_CREATEDATE, _GROUP_MEDICINE.GROUP_MEDICINE_UPDATEBY, _GROUP_MEDICINE.GROUP_MEDICINE_UPDATEDATE, _GROUP_MEDICINE.PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_GROUP_MEDICINE: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
