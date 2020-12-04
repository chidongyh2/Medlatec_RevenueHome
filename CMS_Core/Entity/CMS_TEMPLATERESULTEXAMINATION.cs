using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_TEMPLATERESULTEXAMINATION : IValidatableObject
    {
        public int ID { get; set; }
        public int GROUP_SERVICEID { get; set; }
        public int SERVICEID { get; set; }
        public String NAME { get; set; }
        public String TEMPLATE { get; set; }
        public String RESULT { get; set; }
        public Int16 STATUS { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int PARTNERID { get; set; }

        public String GROUP_SERVICE_NAME { get; set; }
        public String SERVICE_NAME { get; set; }
        public int SERVICETYPE { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên mẫu "));
            } else if(this.NAME.Length > 300)
            {
                results.Add(new ValidationResult("Độ dài tên mẫu quá 300 ký tự, Mời bạn kiểm tra lại! "));
            }

            if (string.IsNullOrWhiteSpace(this.TEMPLATE))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mẫu nhập kết quả "));
            }

            if (string.IsNullOrWhiteSpace(this.RESULT))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mẫu kết quả "));
            }

 

            return results;
        }
    }
}
