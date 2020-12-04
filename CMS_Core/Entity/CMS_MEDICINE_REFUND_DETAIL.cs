using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class CMS_MEDICINE_REFUND_DETAIL : IValidatableObject
    {
        public int ID { get; set; }
        public String CMS_MEDICINE_EXPORT_STORE_CODE { get; set; }
        public int CMS_MEDICINE_EXPORT_STORE_ID { get; set; }
        public int MEDICINE_ID { get; set; }
        public String MEDICINE_CODE { get; set; }
        public int MEDICINE_AMOUNT { get; set; }
        public float MEDICINE_PRICE { get; set; }
        public DateTime MEDICINE_CREATE { get; set; }
        public DateTime MEDICINE_EXPIRED { get; set; }
        public String NOTE { get; set; }
        public Int16 STATUS { get; set; }
        public int PARTNERID { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int REFUND_STORE { get; set; }

        public String MEDICINE_NAME { get; set; }
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (this.CMS_MEDICINE_EXPORT_STORE_ID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn phiếu xuất thuốc"));
            }

            if (this.MEDICINE_ID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn tên thuốc"));
            }

            if (this.MEDICINE_AMOUNT <= 0)
            {
                results.Add(new ValidationResult("Số lượng thuốc phải lớn hơn 0"));
            }

            if (this.MEDICINE_PRICE <= 0)
            {
                results.Add(new ValidationResult("Giá tiền thuốc phải lớn hơn 0"));
            }
            if (this.REFUND_STORE <= 0)
            {
                results.Add(new ValidationResult("ID phiếu hoàn trả không được nhỏ hơn 0"));
            }



            return results;
        }
    }
}
