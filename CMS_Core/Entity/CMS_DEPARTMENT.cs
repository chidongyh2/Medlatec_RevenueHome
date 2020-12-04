using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_DEPARTMENT : IValidatableObject
    {
        public int ID { get; set; }
        public String DEPARTMENT_NAME { get; set; }
        public String DEPARTMENT_DESC { get; set; }
        public Int16 DEPARTMENT_STATUS { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int PARTNERID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.DEPARTMENT_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên khoa khám"));
            }
            else if (this.DEPARTMENT_NAME.Length > 300)
            {
                results.Add(new ValidationResult("Tên khoa khám lớn hơn 300 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.DEPARTMENT_DESC))
            {
                if (this.DEPARTMENT_DESC.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả khoa khám không được dài quá 500 ký tự"));
                }
            }
            
            return results;
        }
    }
}
