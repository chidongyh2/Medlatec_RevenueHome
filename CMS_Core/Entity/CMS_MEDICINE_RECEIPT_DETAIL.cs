using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_MEDICINE_RECEIPT_DETAIL : IValidatableObject
    {
        private DateTime _DATEOFMANUFACTURE;
        private DateTime _EXPIRYDATE;
        private String _DATEOFMANUFACTURE_View;

        private String _EXPIRYDATE_View;


        public int ID { get; set; }
        public String MEDICINE_CODE { get; set; }
        public String NOTE { get; set; }

        private int? _AMOUNT;
        private String _AMOUNT_VIEW;
        public int? AMOUNT { get { return _AMOUNT; } set { _AMOUNT = value; _AMOUNT_VIEW = _AMOUNT.ToString(); } }
        public String AMOUNT_VIEW { get { return _AMOUNT_VIEW; } set { _AMOUNT_VIEW = value; } }


        // public float? AMOUNT { get; set; }

        private float? _IMPORTPRICE;
        private String _IMPORTPRICE_VIEW;

        public float? IMPORTPRICE { get { return _IMPORTPRICE; } set { _IMPORTPRICE = value; _IMPORTPRICE_VIEW = _IMPORTPRICE.ToString(); } }
        public String IMPORTPRICE_VIEW { get { return _IMPORTPRICE_VIEW; } set { _IMPORTPRICE_VIEW = value; } }


        //public float? IMPORTPRICE { get; set; }
        public Int16 VAT { get; set; }


        private float? _EXPORTPRICE;
        private String _EXPORTPRICE_VIEW;

        public float? EXPORTPRICE { get { return _EXPORTPRICE; } set { _EXPORTPRICE = value; _EXPORTPRICE_VIEW = _EXPORTPRICE.ToString(); } }
        public String EXPORTPRICE_VIEW { get { return _EXPORTPRICE_VIEW; } set { _EXPORTPRICE_VIEW = value; } }



        // public float? EXPORTPRICE { get; set; }
        public String LOTMUMBER { get; set; }

        public DateTime DATEOFMANUFACTURE { get { return _DATEOFMANUFACTURE; } set { _DATEOFMANUFACTURE = value; _DATEOFMANUFACTURE_View = _DATEOFMANUFACTURE.ToString("dd/MM/yyyy"); } }
        public String DATEOFMANUFACTURE_View { get { return _DATEOFMANUFACTURE_View; } set { _DATEOFMANUFACTURE_View = value; } }

        public DateTime EXPIRYDATE { get { return _EXPIRYDATE; } set { _EXPIRYDATE = value; _EXPIRYDATE_View = _EXPIRYDATE.ToString("dd/MM/yyyy"); } }

        public String EXPIRYDATE_View { get { return _EXPIRYDATE_View; } set { _EXPIRYDATE_View = value; } }

        public int MANUFACTUREID { get; set; }
        public Int16 KYGUI { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int PARTNERID { get; set; }

        public int PROVIDEDID { get; set; }
        public int MEDICINE_ID { get; set; }

        public int MEDICINE_UNIT { get; set; }
        public String MEDICINE_UNIT_NAME { get; set; }

        public int RECEIPT_STORE_ID { get; set; }

        public String REGISTRATIONNUMBER { get; set; }

        public String MEDICINE_NAME { get; set; }

        public int TOTAL_AMOUNT { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (this.MEDICINE_ID <= 0)
            {
                results.Add(new ValidationResult("Bạn chưa chọn thuốc"));
            }

            if (!string.IsNullOrEmpty(this.MEDICINE_CODE))
            {
                if (this.MEDICINE_CODE.Length > 50)
                {
                    results.Add(new ValidationResult("Mã thuốc không được dài quá 50 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.NOTE))
            {
                if (this.NOTE.Length > 300)
                {
                    results.Add(new ValidationResult("Ghi chú thuốc không được dài quá 300 ký tự"));
                }
            }


            if (string.IsNullOrEmpty(AMOUNT_VIEW))
            {
                AMOUNT = 0;
            }
            else
            {
                AMOUNT_VIEW = AMOUNT_VIEW.Replace(",", "");
                AMOUNT = Convert.ToInt32(AMOUNT_VIEW);
            }

            if (string.IsNullOrEmpty(IMPORTPRICE_VIEW))
            {
                IMPORTPRICE = 0;
            }
            else
            {
                IMPORTPRICE_VIEW = IMPORTPRICE_VIEW.Replace(",", "");
                IMPORTPRICE = (float)Convert.ToDouble(IMPORTPRICE_VIEW);
            }

            if (string.IsNullOrEmpty(EXPORTPRICE_VIEW))
            {
                EXPORTPRICE = 0;
            }
            else
            {
                EXPORTPRICE_VIEW = EXPORTPRICE_VIEW.Replace(",", "");
                EXPORTPRICE = (float)Convert.ToDouble(EXPORTPRICE_VIEW);
            }


            if (this.AMOUNT <= 0)
            {
                results.Add(new ValidationResult("Số lượng nhập thuốc phải khác 0"));
            }

            if (this.IMPORTPRICE <= 0)
            {
                results.Add(new ValidationResult("Giá nhập thuốc phải khác 0"));
            }

            if (this.EXPORTPRICE <= 0)
            {
                results.Add(new ValidationResult("Giá xuất thuốc phải khác 0"));
            }

            if (this.EXPORTPRICE < this.IMPORTPRICE)
            {
                results.Add(new ValidationResult("Giá thuốc xuất phải lớn hơn giá thuốc nhập"));
            }

            if (!string.IsNullOrEmpty(this.LOTMUMBER))
            {
                if (this.LOTMUMBER.Length > 300)
                {
                    results.Add(new ValidationResult("Số lô thuốc không được dài quá 300 ký tự"));
                }
            }
            if (this.EXPIRYDATE < DateTime.Now)
            {
                results.Add(new ValidationResult("Hạn sử dụng không được nhỏ hơn ngày hiện tại"));
            }

            if (this.DATEOFMANUFACTURE > DateTime.Now)
            {
                results.Add(new ValidationResult("Ngày sản xuất không được lớn hơn ngày hiện tại"));
            }

            //if (this.MANUFACTUREID == 0)
            //{
            //    results.Add(new ValidationResult("Mời bạn chọn nhà sản xuất"));
            //}

            //if (this.RECEIPT_STORE_ID == 0)
            //{
            //    results.Add(new ValidationResult("Mời bạn nhập ID phiếu nhập"));
            //}

            return results;
        }
    }

}
