using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class CMS_PATIENT_SERVICE : IValidatableObject
    {
        public int ID { get; set; }
        public int PATIENT_ID { get; set; }
        public int PID { get; set; }
        public int SERVICE_ID { get; set; }
        public float SERVICE_PRICE { get; set; }
        public String SERVICE_NOTE { get; set; }
        public String SERVICE_RESULT { get; set; }
        public Int16 IS_PRINT { get; set; }
        public DateTime PRINT_DATE { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public int PARTNERID { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public String SERVICE_NAME { get; set; }
        public String EXAMINATION_CONTENT { get; set; }
        public Int16 IS_PRINT_RESULT { get; set; }
        public DateTime PRINT_RESULT_DATE { get; set; }


        public String DOCTOR_NAME { get; set; }
        public int DOCTOR_ID { get; set; }

        public String Sick_Code { get; set; }
        public int COUNT { get; set; }
        public int IS_PAY { get; set; }
        public int SERVICE_GROUP_ID { get; set; }

        public int SERVICETYPE { get; set; }
        public bool isRefund { get; set; }
        public String CREATE_NAME { get; set; }

        public String PATIENTINFO_NAME { get; set; }
        public int VISIT_PATIENT_ID { get; set; }

        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (!string.IsNullOrWhiteSpace(this.SERVICE_RESULT))
            {
                if (this.SERVICE_RESULT.Length > 4000)
                {
                    results.Add(new ValidationResult("Kết quả khám không được lớn hơn 4000 ký tự"));
                }
            }

            //if (!string.IsNullOrWhiteSpace(this.EXAMINATION_CONTENT))
            //{
            //    if (this.EXAMINATION_CONTENT.Length > 4000)
            //    {
            //        results.Add(new ValidationResult("Nội dung khám không được lớn hơn 4000 ký tự"));
            //    }
            //}

            if (!string.IsNullOrWhiteSpace(this.SERVICE_NOTE))
            {
                if (this.EXAMINATION_CONTENT.Length > 500)
                {
                    results.Add(new ValidationResult("Nội dung dạn dò không được lớn hơn 500 ký tự"));
                }
            }

            if (PATIENT_ID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn lượt khám"));
            }

            if (PID <= 0)
            {
                results.Add(new ValidationResult("Chưa có thông tin bệnh nhân"));
            }

            if (SERVICE_ID <= 0)
            {
                results.Add(new ValidationResult("Chưa có thông dịch vụ khám"));
            }

            return results;
        }
    }
}
