using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class CMS_MEDICINE_REFUND_STORE : IValidatableObject
    {
        public int ID { get; set; }
        public int CMS_MEDICINE_EXPORT_STORE_ID { get; set; }
        public float TOTAL_PRICE_REFUND { get; set; }
        public String CUSTOMER_NAME { get; set; }
        public String CUSTOMER_MOBILE { get; set; }
        public String CUSTOMER_EMAIL { get; set; }
        public Int16 CUSTOMER_GENDER { get; set; }
        public Int16 STATUS { get; set; }
        public int PARTNERID { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }

        public String CMS_MEDICINE_EXPORT_STORE_CODE { get; set; }
        public String NOTE { get; set; }
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.CUSTOMER_NAME))
            {
                results.Add(new ValidationResult("Tên khách hàng không được để trống"));
            }
            else if (this.CUSTOMER_NAME.Length > 100)
            {
                results.Add(new ValidationResult("Tên khách hàng không được dài quá 100 ký tự"));
            }

            if (string.IsNullOrEmpty(this.CUSTOMER_MOBILE))
            {
                results.Add(new ValidationResult("SĐT khách hàng không được để trống"));
            }
            else if (this.CUSTOMER_MOBILE.Length > 50)
            {
                results.Add(new ValidationResult("SĐT khách hàng không được dài quá 50 ký tự"));
            }

            if (this.CMS_MEDICINE_EXPORT_STORE_ID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn phiếu xuất thuốc"));
            }

            //if (this.TOTAL_PRICE_REFUND <= 0)
            //{
            //    results.Add(new ValidationResult("Số tiền hoàn phải lớn hơn 0"));
            //}

           


            return results;
        }
    }
}
