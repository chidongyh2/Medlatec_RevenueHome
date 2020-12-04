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
    public class ImpCMS_PATIENTINFO_APPOINTMENT : ICMS_PATIENTINFO_APPOINTMENT
    {
        ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");
        public string Add(CMS_PATIENTINFO_APPOINTMENT entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.ExecuteInsert("SP_APPOINTMENT_INSERT", entity.PATIENTNAME, entity.SEX, entity.AGE, entity.ADDRESS, entity.PHONE, entity.PHONE1, entity.SONHA, entity.HEM, entity.NGACH, entity.NGO, entity.STREET, entity.PRECINCT, entity.DISTRICT, entity.CITY, entity.EMAILADDRESS, entity.EMAILRESULT, entity.GHICHU, entity.STATUS, entity.CREATEDATE, entity.CREATEBY, entity.UPATEDATE, entity.UPDATEBY, entity.PARTNERID, entity.BIRTHDAY, entity.RELATIONSHIP, entity.IDENTIFICATION, entity.IDENTIFICATION_DATE, entity.IDENTIFICATION_ISSUED, entity.PASSPORT, entity.PASSPORT_DATE, entity.PASSPORT_ISSUED, entity.PARENTS_INFO, entity.INSURANCE_CARD, entity.INSURANCE_CARD_PLACE, entity.INSURANCE_CARD_START, entity.INSURANCE_CARD_END, entity.partnerid_Code, entity.REASON, entity.PATIENTIMAGE, entity.CHANNEL, entity.DEPARTMENTSID, entity.weight, entity.APPOINTMENT, entity.PATIENTINFO_ID);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }


        public string AddByPID(Int64 pid, DateTime APPOINTMENT, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.ExecuteInsert("SP_APPOINTMENT_INSERTBYPID", pid, APPOINTMENT, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("Add: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Delete(CMS_PATIENTINFO_APPOINTMENT entity, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.ExecuteNonQuery("SP_APPOINTMENT_DELETE", entity.PID, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_PATIENTINFO: " + entity.PID + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public string Delete(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.ExecuteNonQuery("SP_APPOINTMENT_DELETE", id, PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("DeleteCMS_PATIENTINFO: " + id + "  " + ex.ToString());
                return string.Empty;
            }
        }

        public CMS_PATIENTINFO_APPOINTMENT Get(int id, int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                var data = sQLServer.SelectQueryCommand("SP_APPOINTMENT_BYPID", id, PARTNERID);
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
                logError.Info("CMS_PATIENTINFO_APPOINTMENT: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO_APPOINTMENT> GetAll(int PARTNERID)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.SelectQueryCommand("SP_APPOINTMENT_SELECTALL", PARTNERID);
            }
            catch (Exception ex)
            {
                logError.Info("GetAll: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO_APPOINTMENT> GetCMS_PATIENTINFO_APPOINTMENTByName(string PATIENTNAME, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.SelectQueryCommand("SP_APPOINTMENT_BYNAME", PATIENTNAME, partnerid);

            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PARTNERByName: " + ex.ToString());
                return null;
            }
        }

        public List<CMS_PATIENTINFO_APPOINTMENT> GetCMS_PATIENTINFO_APPOINTMENT_ByALL(DateTime start, DateTime end, string keyword, int typeKeyword, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.SelectQueryCommand("SP_APPOINTMENT_BYKeyword", start, end, keyword, typeKeyword, partnerid);
            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_ByALL: " + ex.ToString());
                return null;
            }
        }


        public CMS_PATIENTINFO_APPOINTMENT CONVERT_PATIENTINFO_TO_APPOINTMENT(CMS_PATIENTINFO _PATIENTINFO)
        {
            CMS_PATIENTINFO_APPOINTMENT  data = new CMS_PATIENTINFO_APPOINTMENT();

            try
            {
                if(_PATIENTINFO != null)
                {
                    data.ADDRESS = _PATIENTINFO.ADDRESS;
                    data.AGE = _PATIENTINFO.AGE;
                    data.BIRTHDAY = _PATIENTINFO.BIRTHDAY;
                    data.CITY = _PATIENTINFO.CITY;
                    data.DISTRICT = _PATIENTINFO.DISTRICT;
                    data.EMAILADDRESS = _PATIENTINFO.EMAILADDRESS;
                    data.HEM = _PATIENTINFO.HEM;
                    data.IDENTIFICATION = _PATIENTINFO.IDENTIFICATION;
                    data.IDENTIFICATION_DATE = _PATIENTINFO.IDENTIFICATION_DATE;
                    data.IDENTIFICATION_ISSUED = _PATIENTINFO.IDENTIFICATION_ISSUED;
                    data.INSURANCE_CARD = _PATIENTINFO.INSURANCE_CARD;
                    data.INSURANCE_CARD_END = _PATIENTINFO.INSURANCE_CARD_END;
                    data.INSURANCE_CARD_PLACE = _PATIENTINFO.INSURANCE_CARD_PLACE;
                    data.INSURANCE_CARD_START = _PATIENTINFO.INSURANCE_CARD_START;
                    data.NGACH = _PATIENTINFO.NGACH;
                    data.NGO = _PATIENTINFO.NGO;
                    data.PASSPORT = _PATIENTINFO.PASSPORT;
                    data.PASSPORT_DATE = _PATIENTINFO.PASSPORT_DATE;
                    data.PASSPORT_ISSUED = _PATIENTINFO.PASSPORT_ISSUED;
                    data.PATIENTNAME = _PATIENTINFO.PATIENTNAME;                    
                    data.PHONE = _PATIENTINFO.PHONE;
                    data.PHONE1 = _PATIENTINFO.PHONE1;
                    data.SEX = _PATIENTINFO.SEX;
                    data.STREET = _PATIENTINFO.STREET;                    
                }
            }
            catch (Exception ex)
            {
                logError.Info("CONVERT_PATIENTINFO_TO_APPOINTMENT: " + ex.ToString());
                return null;
            }

            return data;
        }

        public CMS_PATIENTINFO CONVERT_APPOINTMENT_TO_PATIENTINFO(CMS_PATIENTINFO_APPOINTMENT _PATIENTINFO_APPOINTMENT )
        {
            CMS_PATIENTINFO data = new CMS_PATIENTINFO();

            try
            {
                if (_PATIENTINFO_APPOINTMENT != null)
                {
                    data.ADDRESS = _PATIENTINFO_APPOINTMENT.ADDRESS;
                    data.AGE = _PATIENTINFO_APPOINTMENT.AGE;
                    data.BIRTHDAY = _PATIENTINFO_APPOINTMENT.BIRTHDAY;
                    data.CITY = _PATIENTINFO_APPOINTMENT.CITY;
                    data.DISTRICT = _PATIENTINFO_APPOINTMENT.DISTRICT;
                    data.EMAILADDRESS = _PATIENTINFO_APPOINTMENT.EMAILADDRESS;
                    data.HEM = _PATIENTINFO_APPOINTMENT.HEM;
                    data.IDENTIFICATION = _PATIENTINFO_APPOINTMENT.IDENTIFICATION;
                    data.IDENTIFICATION_DATE = _PATIENTINFO_APPOINTMENT.IDENTIFICATION_DATE;
                    data.IDENTIFICATION_ISSUED = _PATIENTINFO_APPOINTMENT.IDENTIFICATION_ISSUED;
                    data.INSURANCE_CARD = _PATIENTINFO_APPOINTMENT.INSURANCE_CARD;
                    data.INSURANCE_CARD_END = _PATIENTINFO_APPOINTMENT.INSURANCE_CARD_END;
                    data.INSURANCE_CARD_PLACE = _PATIENTINFO_APPOINTMENT.INSURANCE_CARD_PLACE;
                    data.INSURANCE_CARD_START = _PATIENTINFO_APPOINTMENT.INSURANCE_CARD_START;
                    data.NGACH = _PATIENTINFO_APPOINTMENT.NGACH;
                    data.NGO = _PATIENTINFO_APPOINTMENT.NGO;
                    data.PASSPORT = _PATIENTINFO_APPOINTMENT.PASSPORT;
                    data.PASSPORT_DATE = _PATIENTINFO_APPOINTMENT.PASSPORT_DATE;
                    data.PASSPORT_ISSUED = _PATIENTINFO_APPOINTMENT.PASSPORT_ISSUED;
                    data.PATIENTNAME = _PATIENTINFO_APPOINTMENT.PATIENTNAME;
                    data.PHONE = _PATIENTINFO_APPOINTMENT.PHONE;
                    data.PHONE1 = _PATIENTINFO_APPOINTMENT.PHONE1;
                    data.SEX = _PATIENTINFO_APPOINTMENT.SEX;
                    data.STREET = _PATIENTINFO_APPOINTMENT.STREET;
                }
            }
            catch (Exception ex)
            {
                logError.Info("CONVERT_APPOINTMENT_TO_PATIENTINFO: " + ex.ToString());
                return null;
            }

            return data;
        }


        public List<CMS_PATIENTINFO_APPOINTMENT> GetCMS_PATIENTINFO_APPOINTMENT_BYID(string PCODE, int partnerid)
        {
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.SelectQueryCommand("SP_APPOINTMENT_BYPCODE", PCODE, partnerid);

            }
            catch (Exception ex)
            {
                logError.Info("GetCMS_PATIENTINFO_APPOINTMENT_BYID: " + ex.ToString());
                return null;
            }
        }

        public string Update(CMS_PATIENTINFO_APPOINTMENT entity, int PARTNERID)
        {
            string result = string.Empty;
            try
            {
                OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT> sQLServer = new OracleServerConnection<CMS_PATIENTINFO_APPOINTMENT>();
                return sQLServer.ExecuteNonQuery("SP_APPOINTMENT_update", entity.PID, entity.PATIENTNAME, entity.SEX, entity.AGE, entity.ADDRESS, entity.PHONE, entity.PHONE1, entity.SONHA, entity.HEM, entity.NGACH, entity.NGO, entity.STREET, entity.PRECINCT, entity.DISTRICT, entity.CITY, entity.EMAILADDRESS, entity.EMAILRESULT, entity.GHICHU, entity.STATUS, entity.CREATEDATE, entity.CREATEBY, entity.UPATEDATE, entity.UPDATEBY, entity.PARTNERID, entity.BIRTHDAY, entity.RELATIONSHIP, entity.IDENTIFICATION, entity.IDENTIFICATION_DATE, entity.IDENTIFICATION_ISSUED, entity.PASSPORT, entity.PASSPORT_DATE, entity.PASSPORT_ISSUED, entity.PARENTS_INFO, entity.INSURANCE_CARD, entity.INSURANCE_CARD_PLACE, entity.INSURANCE_CARD_START, entity.INSURANCE_CARD_END, entity.partnerid_Code, entity.REASON, entity.PATIENTIMAGE, entity.CHANNEL, entity.DEPARTMENTSID, entity.weight, entity.APPOINTMENT);
            }
            catch (Exception ex)
            {
                logError.Info("Update: " + ex.ToString());
                return result = string.Empty;
            }
        }

        public string Publish(int id, int PARTNERID)
        {
            throw new NotImplementedException();
        }

        public CMS_PATIENTINFO_APPOINTMENT Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CMS_PATIENTINFO_APPOINTMENT> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Add(CMS_PATIENTINFO_APPOINTMENT entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(CMS_PATIENTINFO_APPOINTMENT entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CMS_PATIENTINFO_APPOINTMENT entity)
        {
            throw new NotImplementedException();
        }

        public string Publish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
