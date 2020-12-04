using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_PATIENT_PRESCRIPTION : IValidatableObject
    {
        public Int64 ID { get; set; }
        public Int64 SID { get; set; }
        public Int64 PID { get; set; }
        public Int64 CPS_ID { get; set; }
        public String DOCTOR_NAME { get; set; }
        public int DOCTOR_ID { get; set; }
        public int MEDICINE_ID { get; set; }
        public String MEDICINE_CODE { get; set; }
        public String MEDICINE_NAME { get; set; }
        public int PARTNERID { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public String MEDICINE_USAGE { get; set; }
        public int MEDICINE_UNIT { get; set; }
        public String MEDICINE_UNIT_NAME { get; set; }
        public int? COUNT { get; set; }
        public String PATIENTINFO_NAME { get; set; }
        public String Create_PRESCRIPTION { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            //if (!string.IsNullOrWhiteSpace(this.MEDICINE_CODE))
            //{
            //    if (this.MEDICINE_CODE.Length > 50)
            //    {
            //        results.Add(new ValidationResult("Mã thuốc không được lớn hơn 50 ký tự"));
            //    }
            //}
            //else
            //{
            //    results.Add(new ValidationResult("Mời bạn nhập vào mã thuốc"));
            //}

            if (SID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn lượt khám"));
            }

            if (DOCTOR_ID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn bác sỹ"));
            }

            if (MEDICINE_ID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn thuốc"));
            }

            if (PID <= 0)
            {
                results.Add(new ValidationResult("Chưa có thông tin bệnh nhân"));
            }

            //if (CPS_ID <= 0)
            //{
            //    results.Add(new ValidationResult("Chưa có thông dịch vụ khám"));
            //}

            if (MEDICINE_ID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn tên thuốc"));
            }

            if (COUNT <= 0)
            {
                results.Add(new ValidationResult("Mời bạn nhập số lượng"));
            }

            
            return results;
        }
    }
}
