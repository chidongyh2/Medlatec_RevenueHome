using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_MEDICINE_EXPORT_STORE : IValidatableObject
    {
        public int ID { get; set; }
        public String CMS_MEDICINE_EXPORT_STORE_CODE { get; set; }
        public String CMS_MEDICINE_EXPORT_STORE_NOTE { get; set; }
        public String EMPLOYEECODE { get; set; }
        public float TOTAL_PRICE { get; set; }
        public String CUSTOMER_NAME { get; set; }
        public String CUSTOMER_ADDRESS { get; set; }
        public String CUSTOMER_MOBILE { get; set; }
        public String CUSTOMER_EMAIL { get; set; }
        public Int16 CUSTOMER_GENDER { get; set; }
        public float MONEY_CASH { get; set; }
        public float MONEY_POS { get; set; }
        public Int16 STATUS { get; set; }
        public int PARTNERID { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int REFUND_STORE { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();



            if (string.IsNullOrWhiteSpace(this.CMS_MEDICINE_EXPORT_STORE_CODE))
            {
                results.Add(new ValidationResult("Mã xuất kho không được để trống"));
            }
            else if (this.CMS_MEDICINE_EXPORT_STORE_CODE.Length > 50)
            {
                results.Add(new ValidationResult("Mã xuất kho không được dài quá 50 ký tự"));
            }


            if (string.IsNullOrWhiteSpace(this.CUSTOMER_NAME))
            {
                results.Add(new ValidationResult("Tên khách hàng không được để trống"));
            }
            else if (this.CUSTOMER_NAME.Length > 100)
            {
                results.Add(new ValidationResult("Tên khách hàng không được dài quá 100 ký tự"));
            }



            if (!string.IsNullOrWhiteSpace(this.CMS_MEDICINE_EXPORT_STORE_NOTE))
            {
                if (this.CMS_MEDICINE_EXPORT_STORE_NOTE.Length > 400)
                {
                    results.Add(new ValidationResult("Ghi chú xuất kho không được dài quá 400 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.EMPLOYEECODE))
            {
                if (this.EMPLOYEECODE.Length > 100)
                {
                    results.Add(new ValidationResult("Mã nhân viên không được quá 100 ký tự"));
                }
            }


            if (this.TOTAL_PRICE < 0)
            {
                results.Add(new ValidationResult("Tổng tiền không được nhỏ hơn 0"));
            }

          

         


            if (string.IsNullOrWhiteSpace(this.CUSTOMER_ADDRESS))
            {
                results.Add(new ValidationResult("Địa chỉ khách hàng không được để trống"));
            }
            else if (this.CUSTOMER_ADDRESS.Length > 200)
            {
                results.Add(new ValidationResult("Địa chỉ khách hàng không được quá 200 ký tự"));
            }




            if (!string.IsNullOrEmpty(this.CUSTOMER_MOBILE))
            {
                if (this.CUSTOMER_MOBILE.Length > 30)
                {
                    results.Add(new ValidationResult("Số điện thoại không được dài quá 30 ký tự"));
                }
            }

 

            if (!string.IsNullOrEmpty(this.CUSTOMER_EMAIL))
            {
                if (this.CUSTOMER_EMAIL.Length > 100)
                {
                    results.Add(new ValidationResult("Email khách hàng không được quá 30 ký tự"));
                }
            }


            return results;
        }
    }
}
