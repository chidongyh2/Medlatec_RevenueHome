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
    public class ImpCMS_TEMPLATERESULTEXAMINATION : ICMS_TEMPLATERESULTEXAMINATION
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_TEMPLATERESULTEXAMINATION entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                return sQLServer.ExecuteInsert("SP_resultexamination_INSERT", entity.GROUP_SERVICEID, entity.SERVICEID, entity.TEMPLATE, entity.RESULT, entity.STATUS, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.PARTNERID, entity.NAME, entity.SERVICETYPE);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(CMS_TEMPLATERESULTEXAMINATION entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                return sQLServer.ExecuteNonQuery("SP_RESULTEXAMINATION_DEL", entity.ID, PARTNERID);
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
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                return sQLServer.ExecuteNonQuery("SP_RESULTEXAMINATION_DEL", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Delete: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public CMS_TEMPLATERESULTEXAMINATION Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                var data = sQLServer.SelectQueryCommand("SP_RESULTEXAMINATION_BYID", id, PARTNERID);
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
                logError.Info("CMS_TEMPLATERESULTEXAMINATION: " + ex.ToString());
                return null;
            }
        }

        public CMS_TEMPLATERESULTEXAMINATION GetByName(string name, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                var data = sQLServer.SelectQueryCommand("SP_RESULTEXAMINATION_BYNAME", name, PARTNERID);
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
                logError.Info("CMS_TEMPLATERESULTEXAMINATION: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_TEMPLATERESULTEXAMINATION> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                return sQLServer.SelectQueryCommand("SP_RESULTEXAMINATION_BYALL", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }


        public List<CMS_TEMPLATERESULTEXAMINATION> GetCMS_TEMPLATERESULTEXAMINATION_BYSTATUS(int STATUS, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                return sQLServer.SelectQueryCommand("sp_RESULTEXAMINATION_bystatus", STATUS, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_TEMPLATERESULTEXAMINATION_BYSTATUS: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_TEMPLATERESULTEXAMINATION> GetCMS_TEMPLATERESULTEXAMINATIONByGroupService(int GROUP_SERVICEID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                return sQLServer.SelectQueryCommand("SP_RESULTEXAMINATION_BYGROUP", GROUP_SERVICEID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_TEMPLATERESULTEXAMINATION> GetCMS_TEMPLATERESULTEXAMINATIONBySERVICEID(int SERVICEID, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                return sQLServer.SelectQueryCommand("SP_RESULTEXAMINATION_SERVICEID", SERVICEID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public string Publish(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                return sQLServer.ExecuteNonQuery("SP_RESULTEXAMINATION_PUBLICH", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Publish: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Update(CMS_TEMPLATERESULTEXAMINATION entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION> sQLServer = new OracleServerConnection<CMS_TEMPLATERESULTEXAMINATION>();
                return sQLServer.ExecuteNonQuery("SP_resultexamination_Update", entity.ID, entity.GROUP_SERVICEID, entity.SERVICEID, entity.TEMPLATE, entity.RESULT, entity.STATUS, entity.CREATEBY, entity.CREATEDATE, entity.UPDATEBY, entity.UPDATEDATE, entity.PARTNERID, entity.NAME, entity.SERVICETYPE);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public CMS_TEMPLATERESULTEXAMINATION Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_TEMPLATERESULTEXAMINATION> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_TEMPLATERESULTEXAMINATION entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_TEMPLATERESULTEXAMINATION entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_TEMPLATERESULTEXAMINATION entity)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
