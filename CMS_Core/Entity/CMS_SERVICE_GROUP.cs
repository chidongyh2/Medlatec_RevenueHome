using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_SERVICE_GROUP : IValidatableObject
    {
        public int ID { get; set; }
        public String SERVICE_GROUP_NAME { get; set; }
        public String SERVICE_GROUP_CODE { get; set; }
        public int SERVICE_ID { get; set; }
        public String SERVICE_GROUP_DESC { get; set; }
        public int SERVICE_GROUP_STATUS { get; set; }
        public DateTime SERVICE_GROUP_DATE { get; set; }
        public Decimal SERVICE_GROUP_CREATEBY { get; set; }
        public int PARTNERID { get; set; }
        public int SERVICE_GROUP_UPDATEBY { get; set; }
        public DateTime SERVICE_GROUP_UPDATEDATE { get; set; }

        public float? SERVICE_GROUP_PRICE { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.SERVICE_GROUP_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên nhóm dịch vụ"));
            }
            else if (this.SERVICE_GROUP_NAME.Length > 200)
            {
                results.Add(new ValidationResult("Tên nhóm dịch vụ lớn hơn 200 ký tự"));
            }

            if (string.IsNullOrWhiteSpace(this.SERVICE_GROUP_CODE))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mã nhóm dịch vụ"));
            }
            else if (this.SERVICE_GROUP_CODE.Length > 100)
            {
                results.Add(new ValidationResult("Mã nhóm dịch vụ lớn hơn 100 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.SERVICE_GROUP_DESC))
            {
                if (this.SERVICE_GROUP_DESC.Length > 200)
                {
                    results.Add(new ValidationResult("Mô tả nhóm dịch vụ không được quá 500 ký tự"));
                }
            }

            if (SERVICE_GROUP_PRICE != null)
            {
                if (SERVICE_GROUP_PRICE < 0)
                {
                    results.Add(new ValidationResult("Mời bạn nhập giá tiền cho dịch vụ"));
                }
            }
            else
            {
                results.Add(new ValidationResult("Mời bạn nhập giá tiền cho dịch vụ"));
            }


            return results;
        }
    }
}
