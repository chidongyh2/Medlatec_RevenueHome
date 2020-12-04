using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_PATIENTINFO_TOTAL
    {
        #region CMS_PATIENTINFO
        public Int64 PID { get; set; }
        public String PATIENTNAME { get; set; }
        public Int16 SEX { get; set; }
        public Int16 AGE { get; set; }
        public String ADDRESS { get; set; }
        public String PHONE { get; set; }
        public String PHONE1 { get; set; }
        public String SONHA { get; set; }
        public String HEM { get; set; }
        public String NGACH { get; set; }
        public String NGO { get; set; }
        public String STREET { get; set; }
        public String PRECINCT { get; set; }
        public Int16 DISTRICT { get; set; }
        public Int16 CITY { get; set; }
        public String EMAILADDRESS { get; set; }
        public String EMAILRESULT { get; set; }
        public String GHICHU { get; set; }
        public Int16 STATUS { get; set; }
        public DateTime CREATEDATE { get; set; }
        public Int16 CREATEBY { get; set; }
        public DateTime UPATEDATE { get; set; }
        public DateTime BIRTHDAY { get; set; }
        public int? weight { get; set; }
        public Int16 UPDATEBY { get; set; }
        public Int32 PARTNERID { get; set; }
        public String PCODE { get; set; }

        #endregion

        #region CMS_PATIENT
        public Int32 SID { get; set; }
        public Int32 SEQ { get; set; }
        public DateTime DATEIN { get; set; }
        public Int16 DOCTORID { get; set; }
        public String LOCATIONID { get; set; }
        public String OBJECTID { get; set; }
        public String OBJECT_NAME { get; set; }
        public String DIAGNOSTIC { get; set; }
        public Int16 PRINTOUT { get; set; }
        public Int16 FULLRESULT { get; set; }
        public Int16 RETURNRESULT { get; set; }
        public DateTime PRINTTIME { get; set; }
        public String INVOICE { get; set; }
        public DateTime INVOICETIME { get; set; }
        public String BED { get; set; }
        public String USERGETTEST { get; set; }
        public DateTime GETTESTTIME { get; set; }
        public float SUMMONEY { get; set; }
        public float SUMPERTAGE { get; set; }
        public float SUMTRANSPORT { get; set; }
        public DateTime RETURNTIME { get; set; }
        public DateTime VALIDTIME { get; set; }
        public float PAIDBYCARD { get; set; }
        public float PAIDINCASH { get; set; }
        public Int16 SENDRESULT { get; set; }
        public Int16 RESULTRATE { get; set; }
        public DateTime TAIKHAM { get; set; }
        public Int16 TRANGTHAI { get; set; }
        public DateTime TUVAN { get; set; }
        public float DEFINEMONEYDOCTOR { get; set; }
        public float POS { get; set; }
        public String USERCHECK { get; set; }
        public String USERVALID2 { get; set; }
        public Int16 RETURNTYPE { get; set; }
        public String GHICHU_CMS_PAITIENT { get; set; }
        public String CHUANDOAN { get; set; }

        public int TYPECUSTOMERID { get; set; }
        public String TYPECUSTOMER_NAME { get; set; }

        public int DEPARTMENTSID { get; set; }
        public String DEPARTMENTS_NAME { get; set; }

        public String REASON { get; set; }

        public float SUMMONEYPAY { get; set; }
        public float totalPay { get; set; }
        #endregion

    }
}
