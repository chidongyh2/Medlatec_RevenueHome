using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_GROUP_MEDICINE : IValidatableObject
    {
        public int ID { get; set; }
        public String GROUP_MEDICINE_NAME { get; set; }
        public String GROUP_MEDICINE_DESC { get; set; }
        public int GROUP_MEDICINE_PARENT { get; set; }
        public Int16 GROUP_MEDICINE_STATUS { get; set; }
        public int GROUP_MEDICINE_CREATEBY { get; set; }
        public DateTime GROUP_MEDICINE_CREATEDATE { get; set; }
        public int GROUP_MEDICINE_UPDATEBY { get; set; }
        public DateTime GROUP_MEDICINE_UPDATEDATE { get; set; }
        public int PARTNERID { get; set; }
        public String PARTNERNAME { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.GROUP_MEDICINE_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên nhóm thuốc"));
            }
            else if (this.GROUP_MEDICINE_NAME.Length > 300)
            {
                results.Add(new ValidationResult("Tên nhóm thuốc lớn hơn 300 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.GROUP_MEDICINE_DESC))
            {
                if (this.GROUP_MEDICINE_DESC.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả nhóm thuốc không được dài quá 500 ký tự"));
                }
            }

            return results;
        }
    }
}
