using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_PATIENT_IMAGES : IValidatableObject
    {
        public int ID { get; set; }
        public int PATIENT_ID { get; set; }
        public int PID { get; set; }
        public int SERVICE_ID { get; set; }
        public int GROUP_SERVICE_ID { get; set; }
        public String PATHIMAGE { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int PARTNERID { get; set; }
        public int STATUS { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.PATHIMAGE))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào đường dẫn ảnh"));
            }
            else if (this.PATHIMAGE.Length > 500)
            {
                results.Add(new ValidationResult("Đường dẫn ảnh lớn hơn 300 ký tự"));
            }

            if(PATIENT_ID == 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn SID (mã đăng ký khám bệnh nhân)"));
            }

            if (PID == 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn PID bệnh nhân"));
            }
            if (SERVICE_ID == 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn dịch vụ bệnh nhân"));
            }

            return results;
        }
    }
}
