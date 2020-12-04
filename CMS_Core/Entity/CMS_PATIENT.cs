using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_PATIENT : IValidatableObject
    {
        #region Constructors  
        public CMS_PATIENT()
        {

        }
        #endregion

        public Int32 SID { get; set; }
        public Int32 SEQ { get; set; }
        public DateTime DATEIN { get; set; }
        public Int16 DOCTORID { get; set; }
        public Int64? PID { get; set; }
        public int LOCATIONID { get; set; }


        private String _LOCATIONIDNEW;

        public int VISIT_PATIENT_ID { get; set; }

        public String LOCATIONIDNEW
        {
            get { return _LOCATIONIDNEW; }
            set
            {
                _LOCATIONIDNEW = value; if (!string.IsNullOrEmpty(_LOCATIONIDNEW))
                {
                    LISTLOCATIONID = _LOCATIONIDNEW.Split(',');                   
                }
            }
        }

        public string[] LISTLOCATIONID { get; set; }
        public int OBJECTID { get; set; }
        public String DIAGNOSTIC { get; set; }
        public Int16 PRINTOUT { get; set; }
        public Int16 FULLRESULT { get; set; }
        public Int16 RETURNRESULT { get; set; }
        public DateTime PRINTTIME { get; set; }
        public String INVOICE { get; set; }
        public DateTime? INVOICETIME { get; set; }
        public String BED { get; set; }
        public String USERGETTEST { get; set; }
        public DateTime GETTESTTIME { get; set; }

       // public float? SUMMONEY { get; set; }

        private float? _SUMMONEY;
        private String _SUMMONEY_VIEW;

        public float? SUMMONEY { get { return _SUMMONEY; } set { _SUMMONEY = value; _SUMMONEY_VIEW = Common.Common.FmtAmt(_SUMMONEY.ToString()); } }
        public String SUMMONEY_VIEW { get { return _SUMMONEY_VIEW; } set { _SUMMONEY_VIEW = value; } }



        public float? SUMMONEYDISCOUNT { get; set; }

        public float? SUMMONEYPAY { get; set; }
        public DateTime RETURNTIME { get; set; }
        public DateTime VALIDTIME { get; set; }
        public float PAIDBYCARD { get; set; }
        public float PAIDINCASH { get; set; }
        public Int16 SENDRESULT { get; set; }
        public Int16 RESULTRATE { get; set; }
       // public DateTime TAIKHAM { get; set; }
        private DateTime _TAIKHAM;
        private String _TAIKHAM_VIEW;
        public DateTime TAIKHAM { get { return _TAIKHAM; } set { _TAIKHAM = value; } }
        public String TAIKHAM_VIEW { get { return _TAIKHAM_VIEW; } set { _TAIKHAM_VIEW = value; } }

        public Int16 TRANGTHAI { get; set; }
        public DateTime TUVAN { get; set; }
        public float DEFINEMONEYDOCTOR { get; set; }
        public float? POS { get; set; }
        public String USERCHECK { get; set; }
        public String USERVALID2 { get; set; }
        public Int16 RETURNTYPE { get; set; }
        public int PARTNERID { get; set; }
        public String GHICHU { get; set; }
        public String CHUANDOAN { get; set; }
        public int? DISCOUNT { get; set; }

        // public float? SPOTCASH { get; set; }

        private float? _SPOTCASH;
        private String _SPOTCASH_VIEW;

        public float? SPOTCASH { get { return _SPOTCASH; } set { _SPOTCASH = value; _SPOTCASH_VIEW = _SPOTCASH.ToString(); } }
        public String SPOTCASH_VIEW { get { return _SPOTCASH_VIEW; } set { _SPOTCASH_VIEW = value; } }



        // public float? MONEYPOS { get; set; }

        private float? _MONEYPOS;
        private String _MONEYPOS_VIEW;

        public float? MONEYPOS { get { return _MONEYPOS; } set { _MONEYPOS = value; _MONEYPOS_VIEW = _MONEYPOS.ToString(); } }
        public String MONEYPOS_VIEW { get { return _MONEYPOS_VIEW; } set { _MONEYPOS_VIEW = value; } }



        // public float? MONEYREFUNDS { get; set; }

        private float? _MONEYREFUNDS;
        private String _MONEYREFUNDS_VIEW;

        public float? MONEYREFUNDS { get { return _MONEYREFUNDS; } set { _MONEYREFUNDS = value; _MONEYREFUNDS_VIEW = _MONEYREFUNDS.ToString(); } }
        public String MONEYREFUNDS_VIEW { get { return _MONEYREFUNDS_VIEW; } set { _MONEYREFUNDS_VIEW = value; } }



        // public float? MONEYGIVE { get; set; }

        private float? _MONEYGIVE;
        private String _MONEYGIVE_VIEW;

        public float? MONEYGIVE { get { return _MONEYGIVE; } set { _MONEYGIVE = value; _MONEYGIVE_VIEW = _MONEYGIVE.ToString(); } }
        public String MONEYGIVE_VIEW { get { return _MONEYGIVE_VIEW; } set { _MONEYGIVE_VIEW = value; } }



        public int TYPECUSTOMERID { get; set; }
        public int DEPARTMENTSID { get; set; }
        public int SERVICE_GROUPID { get; set; }

      
        private String _SERVICEID;

      

        public String SERVICEID
        {
            get { return _SERVICEID; }
            set
            {
                _SERVICEID = value; if (!string.IsNullOrEmpty(_SERVICEID))
                {

                    mulSERVICEID = _SERVICEID.Split(',');
                    //mulSERVICEID = new string[datas.]
                    //int i = 0;
                    //foreach (string data in datas)
                    //{
                    //    mulSERVICEID[i++] = data.ToString();
                    //}

                }
            }
        }

        public string[] mulSERVICEID { get; set; }



        public String REASON { get; set; }

        public float TOTAL_PAY { get; set; }

        public String DEPARTMENT_NAME { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (!string.IsNullOrEmpty(this.GHICHU))
            {
                if (this.GHICHU.Length > 200)
                {
                    results.Add(new ValidationResult("Lý do vào viện quá 200 ký tự"));
                }
            }

           

           

            if (!string.IsNullOrEmpty(this.CHUANDOAN))
            {
                if (this.CHUANDOAN.Length > 500)
                {
                    results.Add(new ValidationResult("Chuẩn đoán vào viện quá 500 ký tự"));
                }
            }
            if (!string.IsNullOrEmpty(this.REASON))
            {
                if (this.REASON.Length > 500)
                {
                    results.Add(new ValidationResult("Lý do vào viện quá 500 ký tự"));
                }
            }
            else
            {
                results.Add(new ValidationResult("Mời bạn nhập vào lý do khám!"));
            }

            if (string.IsNullOrEmpty(SPOTCASH_VIEW))
            {
                SPOTCASH = 0;
            }
            else
            {
                SPOTCASH_VIEW = SPOTCASH_VIEW.Replace(",", "");
                SPOTCASH = (float)Convert.ToDouble(SPOTCASH_VIEW);
            }


            if (string.IsNullOrEmpty(MONEYPOS_VIEW))
            {
                MONEYPOS = 0;
            }
            else
            {
                MONEYPOS_VIEW = MONEYPOS_VIEW.Replace(",", "");
                MONEYPOS = (float)Convert.ToDouble(MONEYPOS_VIEW);
            }

            if (string.IsNullOrEmpty(MONEYGIVE_VIEW))
            {
                MONEYGIVE = 0;
            }
            else
            {
                MONEYGIVE_VIEW = MONEYGIVE_VIEW.Replace(",", "");
                MONEYGIVE = (float)Convert.ToDouble(MONEYGIVE_VIEW);
            }

            if (string.IsNullOrEmpty(MONEYREFUNDS_VIEW))
            {
                MONEYREFUNDS = 0;
            }
            else
            {
                MONEYREFUNDS_VIEW = MONEYREFUNDS_VIEW.Replace(",", "");
                MONEYREFUNDS = (float)Convert.ToDouble(MONEYREFUNDS_VIEW);
            }


            if (SUMMONEY < 0)
            {
                results.Add(new ValidationResult("Số tiền thanh toán không được nhỏ hơn 0"));
            }

            if (this.OBJECTID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn đối tượng khám!"));
            }

            if (this.TYPECUSTOMERID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn loại khách hàng!"));
            }

            //if (this.DEPARTMENTSID <= 0)
            //{
            //    results.Add(new ValidationResult("Mời bạn chọn khoa khám!"));
            //}

            if (this.PID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn PID bệnh nhân!"));
            }


            if (SUMMONEY < 0)
            {
                results.Add(new ValidationResult("Số tiền thanh toán không được nhỏ hơn 0"));
            }

            if (SUMMONEYDISCOUNT < 0)
            {
                results.Add(new ValidationResult("Số tiền giảm không được nhỏ hơn 0"));
            }

            if (SUMMONEYPAY < 0)
            {
                results.Add(new ValidationResult("Số tiền phải thanh toán không được nhỏ hơn 0"));
            }
            if (DISCOUNT < 0)
            {
                results.Add(new ValidationResult("Ưu đãi không được nhỏ hơn 0"));
            }

            if (SPOTCASH < 0)
            {
                results.Add(new ValidationResult("Tiền mặt không được nhỏ hơn 0"));
            }
            if (MONEYPOS < 0)
            {
                results.Add(new ValidationResult("Tiền POS không được nhỏ hơn 0"));
            }
            if (MONEYREFUNDS < 0)
            {
                results.Add(new ValidationResult("Tiền hoàn trả không được nhỏ hơn 0"));
            }

            if (MONEYGIVE < 0)
            {
                results.Add(new ValidationResult("Tiền khác đưa không được nhỏ hơn 0"));
            }
            else if (MONEYGIVE > 0)
            {
                if (MONEYGIVE < SUMMONEYPAY)
                {
                    results.Add(new ValidationResult("Số tiền khách đưa  nhỏ hơn tổng tiền phải thanh toán"));
                }
            }
            else if ((SPOTCASH + MONEYPOS < SUMMONEYPAY) && (SPOTCASH + MONEYPOS != 0))
            {
                results.Add(new ValidationResult("Tổng tiền mặt và tiền pos nhỏ hơn tổng tiền phải thanh toán"));
            }

            if(OBJECTID == 323)
            {
                if(MONEYGIVE > 0)
                {
                    results.Add(new ValidationResult("Khách hàng bảo hiểm không thu tiền"));
                }
            }
            return results;
        }
    }
}
