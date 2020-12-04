using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_PATIENT_ALLERGY : IValidatableObject
    {
        public int ID { get; set; }
        public String ALLERGY_NAME { get; set; }
        public int ALLERGY_TYPE { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int PARTNERID { get; set; }
        public int CREATEBY { get; set; }
        public String ALLERGY_NOTE { get; set; }
        public int PID { get; set; }

        public String ALLERGY_TYPE_NAME { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.ALLERGY_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên dị ứng"));
            }
            else if (this.ALLERGY_NAME.Length > 300)
            {
                results.Add(new ValidationResult("Tên dị ứng lớn hơn 300 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.ALLERGY_NOTE))
            {
                if (this.ALLERGY_NOTE.Length > 300)
                {
                    results.Add(new ValidationResult("Ghi chú dị ứng không được dài quá 300 ký tự"));
                }
            }
            if (this.PID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn PID bệnh nhân!"));
            }

            return results;
        }
    }
}
