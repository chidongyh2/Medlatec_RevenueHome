using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_PATIENT_HISTORY : IValidatableObject
    {
        public int ID { get; set; }
        public String SICKNAME { get; set; }
        public int? SICKYEAR { get; set; }
        public String NOTE { get; set; }
        public int PARTNERID { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int PID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.SICKNAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên bệnh"));
            }
            else if (this.SICKNAME.Length > 300)
            {
                results.Add(new ValidationResult("Tên bệnh lớn hơn 300 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.NOTE))
            {
                if (this.NOTE.Length > 400)
                {
                    results.Add(new ValidationResult("Ghi chú bệnh không được dài quá 400 ký tự"));
                }
            }

            if(SICKYEAR < 1900 )
            {
                results.Add(new ValidationResult("Năm bị bệnh không được nhỏ hơn 1900"));
            }

            if (SICKYEAR > DateTime.Now.Year)
            {
                results.Add(new ValidationResult("Năm bị bệnh không được lớn hơn " + DateTime.Now.Year));
            }

            if (this.PID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn PID bệnh nhân!"));
            }
            return results;
        }
    }
}
