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
    public class ImpCMS_ROOM_CLINIC : ICMS_ROOM_CLINIC
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_ROOM_CLINIC entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.ExecuteInsert("SP_CMS_ROOM_CLINIC_INSERT", entity.ROOM_NAME, entity.ROOM_DESC, entity.GROUP_SEVICEID, entity.SERVICE_ID, entity.DEPARTMENT_ID, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.PARTNERID, entity.STATUS, entity.SERVICETYPE);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(CMS_ROOM_CLINIC entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.ExecuteNonQuery("SP_CMS_ROOM_CLINIC_DELETE", entity.ID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + entity.ID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.ExecuteNonQuery("SP_CMS_ROOM_CLINIC_DELETE", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public CMS_ROOM_CLINIC Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                var data = sQLServer.SelectQueryCommand("SP_CMS_ROOM_CLINIC_BYID", id, PARTNERID);
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        return data[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logError.Info("CMS_DEPARTMENT: " + ex.ToString());
                return null;
            }
        }


        public CMS_ROOM_CLINIC GetRoomByServiceType(int SERVICETYPE, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                var data = sQLServer.SelectQueryCommand("SP_ROOM_CLINIC_BYSERVICETYPE", SERVICETYPE, PARTNERID);
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        return data[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetRoomByServiceType: " + ex.ToString());
                return null;
            }
        }



        public bool CheckRoomAndService(int LOCATIONID, int serviceid, int SERVICETYPE, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                var data = sQLServer.SelectQueryCommand("SP_ROOM_CLINIC_BYSERVICEIDNew", LOCATIONID, serviceid, SERVICETYPE, PARTNERID);
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                logError.Info("CheckRoomAndService: " + ex.ToString());
                return false;
            }
        }

        public List<CMS_ROOM_CLINIC> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.SelectQueryCommand("SP_CMS_ROOM_CLINIC_BYALL", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_ROOM_CLINIC> GetCMS_ROOM_CLINIC_BYSTATUS(int STATUS,int DEPARTMENT_ID,  int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.SelectQueryCommand("SP_CMS_ROOM_CLINIC_BYSTATUS", STATUS, DEPARTMENT_ID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_ROOM_CLINIC_BYSTATUS: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_ROOM_CLINIC> GetCMS_ROOM_CLINICByDEPARTMENTID(int DEPARTMENTID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.SelectQueryCommand("SP_CMS_ROOM_CLINIC_BYDID", DEPARTMENTID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_ROOM_CLINIC> GetCMS_ROOM_CLINICByGroupService(int GROUP_SERVICEID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.SelectQueryCommand("SP_CMS_ROOM_CLINIC_BYGROUPID", GROUP_SERVICEID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_ROOM_CLINIC> GetCMS_ROOM_CLINICBySERVICEID(int SERVICEID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.SelectQueryCommand("SP_CMS_ROOM_CLINIC_BYSERVICEID", SERVICEID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public CMS_ROOM_CLINIC GetName(string RoomName, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                var data = sQLServer.SelectQueryCommand("SP_CMS_ROOM_CLINIC_BYNAME", RoomName, PARTNERID);
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        return data[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logError.Info("GetName: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.ExecuteNonQuery("SP_CMS_ROOM_CLINIC_PUBLICH", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(CMS_ROOM_CLINIC entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_ROOM_CLINIC> sQLServer = new OracleServerConnection<CMS_ROOM_CLINIC>();
                return sQLServer.ExecuteNonQuery("SP_CMS_ROOM_CLINIC_UPDATE", entity.ID, entity.ROOM_NAME, entity.ROOM_DESC, entity.GROUP_SEVICEID, entity.SERVICE_ID, entity.DEPARTMENT_ID, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.PARTNERID, entity.STATUS, entity.SERVICETYPE);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public CMS_ROOM_CLINIC Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_ROOM_CLINIC> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_ROOM_CLINIC entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_ROOM_CLINIC entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_ROOM_CLINIC entity)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
