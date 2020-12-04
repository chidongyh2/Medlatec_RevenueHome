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
    public class ImpCMS_SERVICE : ICMS_SERVICE
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string DeleteCMS_SERVICE(CMS_SERVICE _SERVICE, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SERVICE_DELETE", _SERVICE.ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_SERVICE: " + _SERVICE.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string DeleteCMS_SERVICE(int ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SERVICE_DELETE", ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_SERVICE: " + ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public List<CMS_SERVICE> GetAllCMS_SERVICE(int partnerid, int partnerUser)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_SELECT_ALL", partnerid, partnerUser);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_SERVICE: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SERVICE> GetAllCMS_SERVICE_BYSERVICETYPE(int partnerid, int partnerUser, int SERVICETYPE)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_SERVICE_BYSERVICETYPE", partnerid, partnerUser, SERVICETYPE);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_SERVICE_BYSERVICETYPE: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_SERVICE> GetAllCMS_SERVICE_BYGROUPSEVICEID(int groupid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_GROUP_CATE_ByGroupID", groupid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_SERVICE_BYGROUPSEVICEID: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_SERVICE> GetAllCMS_SERVICE_CHECKBYGROUPSEVICEID(int groupid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_GROUP_CATE_CheckBYGroupID", groupid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_SERVICE_BYGROUPSEVICEID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SERVICE> GetAllCMS_SERVICE_GROUPSEVICEIDANDSID(int groupid, Int64 sid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_GROUP_CATE_ByServiceID", groupid, sid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_SERVICE_GROUPSEVICEIDANDSID: " + ex.ToString());
                return null;
            }
        }

        //Get danh sach dịch vụ theo serviceid
        public List<CMS_SERVICE> GetAllCMS_SERVICE_BYLISTSEVICEID(string listServiceid, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_BYListServiceID", listServiceid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_SERVICE_BYLISTSEVICEID: " + ex.ToString());
                return null;
            }
        }


        //Get danh sach dịch vụ theo serviceid
        public List<CMS_SERVICE> GetAllCMS_SERVICE_BYLISTSEVICEID(string listServiceid, Int64 sid,  int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_SERVICE_ListServiceIDAndSID", listServiceid, sid, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetAllCMS_SERVICE_BYLISTSEVICEID: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_SERVICE> GetCMS_SERVICEByID(int ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_SELECT_BYID", ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_SERVICEByID: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_SERVICE> GetCMS_SERVICEBySID(int SID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_SELECT_BYSID", SID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_SERVICEBySID: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SERVICE> GetCMS_SERVICEBySID_NOPAY(int SID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_BYSID_NOPAY", SID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_SERVICEBySID: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_SERVICE> GetCMS_SERVICEByServiceName(string ServiceName, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_SELECT_BYNAME", ServiceName, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_SERVICEByServiceName: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SERVICE> GetCMS_SERVICEByServiceCode(string ServiceCode, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.SelectQueryCommand("SP_CMS_SERVICE_SELECT_BYCode", ServiceCode, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_SERVICEByServiceCode: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_SERVICE> GetCMS_SERVICEByServiceName(CMS_SERVICEViewModel SERVICEViewModel)
        {
            throw new NotImplementedException();
        }

        public string InsertCMS_SERVICE(CMS_SERVICE _SERVICE)
        {
            string result = string.Empty;
            try
            {
                if(_SERVICE.SERVICE_PRICE_INSURANCE == null)
                {
                    _SERVICE.SERVICE_PRICE_INSURANCE = 0;
                }
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.ExecuteInsert("SP_CMS_SERVICE_INSERT", _SERVICE.SERVICE_NAME, _SERVICE.SERVICE_CODE, _SERVICE.SERVICE_NAME_ENG, _SERVICE.SERVICE_UNIT, _SERVICE.SERVICE_PRICE, _SERVICE.SERVICE_PRICE_INSURANCE, _SERVICE.SERVICE_RETURN_DATE, _SERVICE.SERVICE_NOTE, _SERVICE.SERVICE_STATUS, _SERVICE.SERVICE_CREATEBY, _SERVICE.SERVICE_CREATEDATE, _SERVICE.PARTNERID, _SERVICE.SERVICE_UPDATEBY, _SERVICE.SERVICE_UPDATEDATE, _SERVICE.SERVICETYPE);
            }
            catch (Exception ex)
            {
                logError.Info("InsertCMS_SERVICE: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string PublicCMS_SERVICE(int ID, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SERVICE_PUBLIC", ID, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("PublicCMS_SERVICE: " + ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string UpdateCMS_SERVICE(CMS_SERVICE _SERVICE)
        {
            string result = string.Empty;
            try
            {
                if (_SERVICE.SERVICE_PRICE_INSURANCE == null)
                {
                    _SERVICE.SERVICE_PRICE_INSURANCE = 0;
                }
                

                OracleServerConnection<CMS_SERVICE> sQLServer = new OracleServerConnection<CMS_SERVICE>();
                return sQLServer.ExecuteNonQuery("SP_CMS_SERVICE_UPDATE", _SERVICE.ID, _SERVICE.SERVICE_NAME, _SERVICE.SERVICE_CODE, _SERVICE.SERVICE_NAME_ENG, _SERVICE.SERVICE_UNIT, _SERVICE.SERVICE_PRICE, _SERVICE.SERVICE_PRICE_INSURANCE, _SERVICE.SERVICE_RETURN_DATE, _SERVICE.SERVICE_NOTE, _SERVICE.SERVICE_STATUS, _SERVICE.SERVICE_CREATEBY, _SERVICE.SERVICE_CREATEDATE, _SERVICE.PARTNERID, _SERVICE.SERVICE_UPDATEBY, _SERVICE.SERVICE_UPDATEDATE, _SERVICE.SERVICETYPE);
            }
            catch (Exception ex)
            {
                logError.Info("UpdateCMS_SERVICE: " + ex.ToString());
                return result = string.Empty;
            }
        }
    }
}
