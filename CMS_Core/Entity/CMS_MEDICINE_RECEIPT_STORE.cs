using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_MEDICINE_RECEIPT_STORE : IValidatableObject
    {
        public int ID { get; set; }
        public String MEDICINE_RECEIPT_STORE_CODE { get; set; }
        public String MEDICINE_RECEIPT_STORE_NOTE { get; set; }
        public String CONTRACT { get; set; }
      
       // public DateTime? CONTRACT_DATE { get; set; }

        private DateTime? _CONTRACT_DATE;
        private String _CONTRACT_DATE_VIEW;

        public DateTime? CONTRACT_DATE { get { return _CONTRACT_DATE; } set { _CONTRACT_DATE = value; _CONTRACT_DATE_VIEW = _CONTRACT_DATE.HasValue ? _CONTRACT_DATE.Value.ToString("dd/MM/yyyy") : String.Empty; } }
       // public String CONTRACT_DATE_VIEW { get; set; }

        public string CONTRACT_DATE_VIEW { get { return _CONTRACT_DATE_VIEW; } set { _CONTRACT_DATE_VIEW = value; } }


        public float TOTAL_PRICE { get; set; }
        public int VAT { get; set; }
        public float TOTAL_PAYMENTS { get; set; }
        public int STATUS { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int PARTNERID { get; set; }
        public int MEDICINE_SUPPLIER_ID { get; set; }
        public String NOTE { get; set; }
        public String MEDICINE_SUPPLIER_NAME { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();


            if (!string.IsNullOrEmpty(this.CONTRACT))
            {
                if (this.CONTRACT.Length > 50)
                {
                    results.Add(new ValidationResult("Số hợp đồng không được dài quá 50 ký tự"));
                }
            }else
            {
                results.Add(new ValidationResult("Mời bạn nhập số hợp đồng!"));
            }


            if (!string.IsNullOrEmpty(this.MEDICINE_RECEIPT_STORE_CODE))
            {
                if (this.MEDICINE_RECEIPT_STORE_CODE.Length > 50)
                {
                    results.Add(new ValidationResult("Mã nhập thuốc không được dài quá 50 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.MEDICINE_RECEIPT_STORE_NOTE))
            {
                if (this.MEDICINE_RECEIPT_STORE_NOTE.Length > 400)
                {
                    results.Add(new ValidationResult("Ghi chú nhập thuốc không được dài quá 400 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.CONTRACT))
            {
                if (this.CONTRACT.Length > 50)
                {
                    results.Add(new ValidationResult("Số hợp đồng nhập thuốc không được dài quá 50 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.CONTRACT_DATE_VIEW))
            {

                DateTime dateTime = new DateTime();
                try
                {
                    dateTime = DateTime.ParseExact(CONTRACT_DATE_VIEW.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    CONTRACT_DATE = dateTime;
                }
                catch
                {
                    results.Add(new ValidationResult("Dữ liệu ngày hợp đồng không đúng định dạng"));                     
                }
            }
            else
            {
                results.Add(new ValidationResult("Mời bạn chọn ngày ngày hợp đồng"));
            }


            if (this.TOTAL_PRICE < 0)
            {
                results.Add(new ValidationResult("Giá nhập lô thuốc phải khác 0"));
            }
            if (this.MEDICINE_SUPPLIER_ID < 0)
            {
                results.Add(new ValidationResult("Nhà cung cấp không thể nhỏ hon 0"));
            }

            if (!string.IsNullOrEmpty(this.NOTE))
            {
                if (this.NOTE.Length > 400)
                {
                    results.Add(new ValidationResult("Ghi chú nhập thuốc không được dài quá 400 ký tự"));
                }
            }

            //if(this.MEDICINE_SUPPLIER_ID == 0)
            //{
            //    results.Add(new ValidationResult("Mời bạn chọn nhà cung cấp"));
            //}


            return results;
        }
    }
}
