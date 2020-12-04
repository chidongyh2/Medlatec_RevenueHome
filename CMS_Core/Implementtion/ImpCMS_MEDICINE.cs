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
    public class ImpCMS_MEDICINE : ICMS_MEDICINE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public string DeleteCMS_MEDICINE(CMS_MEDICINE _MEDICINE, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE> sQLServer = new OracleServerConnection<CMS_MEDICINE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_MEDICINE_DELETE", _MEDICINE.ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_MEDICINE: " + _MEDICINE.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_MEDICINE(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE> sQLServer = new OracleServerConnection<CMS_MEDICINE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_MEDICINE_DELETE", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_MEDICINE: " + Id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_MEDICINE> GetCMS_MEDICINE(int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE> sQLServer = new OracleServerConnection<CMS_MEDICINE>();
                return sQLServer.SelectQueryCommand("SP_CMS_MEDICINE_ALL", partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE> GetCMS_MEDICINEByID(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE> sQLServer = new OracleServerConnection<CMS_MEDICINE>();
                return sQLServer.SelectQueryCommand("SP_CMS_MEDICINE_BYID", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINE: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE> GetCMS_MEDICINEByName(string Name, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE> sQLServer = new OracleServerConnection<CMS_MEDICINE>();
                return sQLServer.SelectQueryCommand("SP_CMS_MEDICINE_BYName", Name, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINEByName: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE> GetAllCMS_MEDICINEByStatus(int parentid, int status, int partneridInput, int partneridUser, int TypeKeyword, string keyword)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE> sQLServer = new OracleServerConnection<CMS_MEDICINE>();
                return sQLServer.SelectQueryCommand("SP_CMS_MEDICINE_BYSTATUS", parentid, status, partneridInput, partneridUser, TypeKeyword, keyword);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_MEDICINEByStatus: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_MEDICINE> GetCMS_MEDICINEParent(int Parentid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE> sQLServer = new OracleServerConnection<CMS_MEDICINE>();
                return sQLServer.SelectQueryCommand("SP_CMS_MEDICINE_BYParent", Parentid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_MEDICINEParent: " + ex.ToString());
                return null;
            }
        }

        public string InsertCMS_MEDICINE(CMS_MEDICINE _MEDICINE)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_MEDICINE> sQLServer = new OracleServerConnection<CMS_MEDICINE>();
                return sQLServer.ExecuteInsert("SP_cms_medicine_Insert", _MEDICINE.MEDICINE_NAME, _MEDICINE.MEDICINE_NAME_EN, _MEDICINE.MEDICINE_DES, _MEDICINE.MEDICINE_CODE, _MEDICINE.MEDICINE_UNIT, _MEDICINE.MEDICINE_NOTE, _MEDICINE.MEDICINE_BARCODE, _MEDICINE.MEDICINE_USAGE, _MEDICINE.MEDICINE_TEMPERATURE, _MEDICINE.MEDICINE_LIGHT, _MEDICINE.MEDICINE_HANDS, _MEDICINE.MEDICINE_WET, _MEDICINE.MEDICINE_CREATEBY, _MEDICINE.MEDICINE_CREATEDATE, _MEDICINE.MEDICINE_STATUS, _MEDICINE.MEDICINE_LOCATION, _MEDICINE.MEDICINE_INVENTORY, _MEDICINE.MEDICINE_UPDATEBY, _MEDICINE.MEDICINE_UPDATEDATE, _MEDICINE.MEDICINE_HUONGTHAN, _MEDICINE.MEDICINE_INSURANCE, _MEDICINE.PARTNERID, _MEDICINE.GROUP_MEDICINE);
            }
            catch (Exception ex)
            {
                logError.Info("InsertCMS_MEDICINE: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string PUBLICCMS_MEDICINE(int Id, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_MEDICINE> sQLServer = new OracleServerConnection<CMS_MEDICINE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_MEDICINE_PUBLIC", Id, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_MEDICINE: " + Id + "  " + ex.ToString());
                return string.Empty;
            }
        }


        public string UpdateCMS_MEDICINE(CMS_MEDICINE _MEDICINE)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_GROUP_MEDICINE> sQLServer = new OracleServerConnection<CMS_GROUP_MEDICINE>();
                return sQLServer.ExecuteNonQuery("SP_cms_medicine_Update", _MEDICINE.ID, _MEDICINE.MEDICINE_NAME, _MEDICINE.MEDICINE_NAME_EN, _MEDICINE.MEDICINE_DES, _MEDICINE.MEDICINE_CODE, _MEDICINE.MEDICINE_UNIT, _MEDICINE.MEDICINE_NOTE, _MEDICINE.MEDICINE_BARCODE, _MEDICINE.MEDICINE_USAGE, _MEDICINE.MEDICINE_TEMPERATURE, _MEDICINE.MEDICINE_LIGHT, _MEDICINE.MEDICINE_HANDS, _MEDICINE.MEDICINE_WET, _MEDICINE.MEDICINE_CREATEBY, _MEDICINE.MEDICINE_CREATEDATE, _MEDICINE.MEDICINE_STATUS, _MEDICINE.MEDICINE_LOCATION, _MEDICINE.MEDICINE_INVENTORY, _MEDICINE.MEDICINE_UPDATEBY, _MEDICINE.MEDICINE_UPDATEDATE, _MEDICINE.MEDICINE_HUONGTHAN, _MEDICINE.MEDICINE_INSURANCE, _MEDICINE.PARTNERID, _MEDICINE.GROUP_MEDICINE);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_MEDICINE: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
