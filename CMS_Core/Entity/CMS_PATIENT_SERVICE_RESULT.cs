using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class CMS_PATIENT_SERVICE_RESULT : IValidatableObject
    {
        public CMS_PATIENT_SERVICE_RESULT()
        {
            SECONDARY_SICK = string.Empty;
        }

        public int ID { get; set; }
        public Int64 PATIENT_ID { get; set; }
        public Int64 PID { get; set; }
        public int SERVICE_ID { get; set; }
        public float SERVICE_PRICE { get; set; }
        public String SERVICE_NOTE { get; set; }
        public String SERVICE_RESULT { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public int PARTNERID { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public String SERVICE_NAME { get; set; }
        public String EXAMINATION_CONTENT { get; set; }
        public String SERVICE_ADVICE { get; set; }
        public int MAINSICK { get; set; }

        public String MAINSICK_NAME { get; set; }

        public String SECONDARY_SICK { get; set; }
        public String HISTORY_SICK { get; set; }
        public int CPS_ID { get; set; }

        public String DOCTOR_NAME { get; set; }
        public int DOCTOR_ID { get; set; }
        public int SERVICE_GROUP_ID { get; set; }

        public int SERVICETYPE { get; set; }
        public int WEIRDO { get; set; }

        private DateTime? _APPOINTMENT;

        public DateTime? APPOINTMENT { get { return _APPOINTMENT; } set { _APPOINTMENT = value; APPOINTMENT_VIEW = _APPOINTMENT.HasValue ? _APPOINTMENT.Value.ToString("dd/MM/yyyy") : String.Empty; } }
       
      
        public String APPOINTMENT_VIEW { get; set; }

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


            if (string.IsNullOrWhiteSpace(this.EXAMINATION_CONTENT))
            {

                results.Add(new ValidationResult("Mời bạn nhập vào nội dung khám"));
            }

            if (!string.IsNullOrWhiteSpace(this.SERVICE_ADVICE))
            {
                if (this.SERVICE_ADVICE.Length > 1000)
                {
                    results.Add(new ValidationResult("Dặn dò không được lớn hơn 1000 ký tự"));
                }
            }

            if (!string.IsNullOrWhiteSpace(this.SERVICE_NOTE))
            {
                if (this.SERVICE_NOTE.Length > 500)
                {
                    results.Add(new ValidationResult("Nội dung dạn dò không được lớn hơn 500 ký tự"));
                }
            }

            if (!string.IsNullOrWhiteSpace(this.HISTORY_SICK))
            {
                if (this.HISTORY_SICK.Length > 500)
                {
                    results.Add(new ValidationResult("Tiền sử bệnh không được lớn hơn 500 ký tự"));
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

            if (WEIRDO != 0)
            {
                if (string.IsNullOrWhiteSpace(this.SERVICE_NOTE))
                {
                    results.Add(new ValidationResult("Mời bạn nhập ghi chú cho bệnh nhân bất thường!"));
                }
            }


            if (!string.IsNullOrEmpty(this.APPOINTMENT_VIEW))
            {

                DateTime dateTime = new DateTime();
                try
                {
                    dateTime = DateTime.ParseExact(APPOINTMENT_VIEW.Trim(), "dd/MM/yyyy", new CultureInfo("en-US"));
                    if ((dateTime - DateTime.Today).TotalDays < 1)
                    {
                        results.Add(new ValidationResult("Thời gian đặt lịch phải lớn hơn ngày hiện tại 1 ngày"));
                    }
                    else
                    {
                        _APPOINTMENT = dateTime;
                    }
                }
                catch
                {
                    results.Add(new ValidationResult("Dữ liệu ngày đặt lịch không đúng định dạng"));
                }
            }

          

            return results;
        }
    }
}
