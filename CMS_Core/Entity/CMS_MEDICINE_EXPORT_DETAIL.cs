using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_MEDICINE_EXPORT_DETAIL : IValidatableObject
    {
        public int ID { get; set; }
        public String CMS_MEDICINE_EXPORT_STORE_CODE { get; set; }
        public int CMS_MEDICINE_EXPORT_STORE_ID { get; set; }
        public int MEDICINE_ID { get; set; }
        public String MEDICINE_CODE { get; set; }
        public String MEDICINE_NAME { get; set; }


        private int? _MEDICINE_AMOUNT;
        private String _MEDICINE_AMOUNT_VIEW;
        public int? MEDICINE_AMOUNT { get { return _MEDICINE_AMOUNT; } set { _MEDICINE_AMOUNT = value; _MEDICINE_AMOUNT_VIEW = _MEDICINE_AMOUNT.ToString(); } }        
        public String MEDICINE_AMOUNT_VIEW { get { return _MEDICINE_AMOUNT_VIEW; } set { _MEDICINE_AMOUNT_VIEW = value; } }

        // public int? MEDICINE_AMOUNT { get; set; }

        //public String MEDICINE_AMOUNT_VIEW { get; set; }

        public int MEDICINE_UNIT { get; set; }

        public int? MEDICINE_TOTAL { get; set; }
        public String LOTMUMBER { get; set; }
        public float? MEDICINE_PRICE { get; set; }
        public int VAT { get; set; }


        private DateTime? _MEDICINE_CREATE;
        private DateTime? _MEDICINE_EXPIRED;
        private String _MEDICINE_CREATE_View;

        private String _MEDICINE_EXPIRED_View;


        public DateTime? MEDICINE_CREATE { get { return _MEDICINE_CREATE; } set { _MEDICINE_CREATE = value;  } }
        public String MEDICINE_CREATE_View { get { return _MEDICINE_CREATE_View; } set { _MEDICINE_CREATE_View = value; } }

        public DateTime? MEDICINE_EXPIRED { get { return _MEDICINE_EXPIRED  ; } set { _MEDICINE_EXPIRED = value; } }

        public String MEDICINE_EXPIRED_View { get { return _MEDICINE_EXPIRED_View; } set { _MEDICINE_EXPIRED_View = value; } }



        public String NOTE { get; set; }
        public Int16 STATUS { get; set; }
        public int PARTNERID { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }

        public bool isRefund { get; set; }

        public int Refund { get; set; }
        public int MEDICINE_UNIT_NAME { get; set; }
        public float? Refund_PRICE { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.MEDICINE_CODE))
            {
                results.Add(new ValidationResult("Mã thuốc không được để trống"));
            }
            else if (this.MEDICINE_CODE.Length > 100)
            {
                results.Add(new ValidationResult("Mã thuốc không được dài quá 100 ký tự"));
            }
            if (string.IsNullOrEmpty(MEDICINE_AMOUNT_VIEW))
            {
                MEDICINE_AMOUNT = 0;
            }
            else
            {
                MEDICINE_AMOUNT_VIEW = MEDICINE_AMOUNT_VIEW.Replace(",", "");
                MEDICINE_AMOUNT_VIEW = MEDICINE_AMOUNT_VIEW.Replace(".", "");
                MEDICINE_AMOUNT = Convert.ToInt32(MEDICINE_AMOUNT_VIEW);
            }


            if (this.MEDICINE_AMOUNT <= 0)
            {
                results.Add(new ValidationResult("Số lượng thuốc không được nhỏ hơn 0"));
            }

            if (this.MEDICINE_PRICE <= 0)
            {
                results.Add(new ValidationResult("Giá thuốc không được nhỏ hơn 0"));
            }

            if (this.MEDICINE_ID <= 0)
            {
                results.Add(new ValidationResult("Bạn chưa chọn thuốc"));
            }

            



            return results;
        }
    }
}
