using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class CMS_PATIENT_SERVICE_REFUND : IValidatableObject
    {
        public int ID { get; set; }
        public int SID { get; set; }
        public Int64 PID { get; set; }
        public int SERVICE_ID { get; set; }
        public float SERVICE_PRICE { get; set; }
        public String SERVICE_NOTE { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public int PARTNERID { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public String SERVICE_NAME { get; set; }
        public int SERVICETYPE { get; set; }
        public int COUNT { get; set; }
        public int STATUS { get; set; }

        public String PATIENTNAME { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (this.PID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn bệnh nhân"));
            }

            if (this.SID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn bệnh nhân"));
            }

            if (this.SERVICE_ID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn dịch vụ"));
            }
            if (string.IsNullOrEmpty(this.SERVICE_NAME))
            {
                results.Add(new ValidationResult("Mời bạn chọn dịch vụ"));
            }
            else if (this.SERVICE_NAME.Length > 200)
            {
                results.Add(new ValidationResult("Tên dịch vụ không được quá 200 ký tự"));
            }


            return results;
        }
    }
}
