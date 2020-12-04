using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_TEMPLATEPRINT : IValidatableObject
    {
        public int ID { get; set; }
        public String NAME { get; set; }
        public String TEMPLATE { get; set; }
        public int PARTNERID { get; set; }
        public int TYPE { get; set; }
        public int STATUS { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên template"));
            }
            else if (this.NAME.Length > 200)
            {
                results.Add(new ValidationResult("Tên template lớn hơn 200 ký tự"));
            }

            if (string.IsNullOrEmpty(this.TEMPLATE))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mô tả template"));
            }
            else if (this.TEMPLATE.Length > 4000)
            {
                results.Add(new ValidationResult("Mô tả template lớn hơn 4000 ký tự"));
            }


            return results;
        }
    }
}
