using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_SERVICE : IValidatableObject
    {
        public int ID { get; set; }
        public String SERVICE_NAME { get; set; }
        public String SERVICE_CODE { get; set; }
        public String SERVICE_NAME_ENG { get; set; }
        public int SERVICE_UNIT { get; set; }
        public float? SERVICE_PRICE { get; set; }
        public float? SERVICE_PRICE_INSURANCE { get; set; }
        public String SERVICE_RETURN_DATE { get; set; }
        public String SERVICE_NOTE { get; set; }
        public int SERVICE_STATUS { get; set; }
        public int SERVICE_CREATEBY { get; set; }
        public DateTime SERVICE_CREATEDATE { get; set; }
        public int PARTNERID { get; set; }
        public int SERVICE_UPDATEBY { get; set; }
        public DateTime SERVICE_UPDATEDATE { get; set; }
        public String UnitName { get; set; }
        private bool _view;
        private int _Permission;

        public int Permission { get { return _Permission; } set { _Permission = value; if (_Permission == 1) _view = true; else _view = false; } }
        public bool view { get { return _view; } set { _view = value; } }

        public String StatusPay { get; set; }
        public int is_pay { get; set; }
        public int SERVICETYPE { get; set; }

        public String VISIT_PATIENT_NAME { get; set; }
        public float? SERVICE_GROUP_PRICE { get; set; }

        public int VISIT_PATIENT { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.SERVICE_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên dịch vụ"));
            }
            else if (this.SERVICE_NAME.Trim().Length > 200)
            {
                results.Add(new ValidationResult("Tên dịch vụ lớn hơn 200 ký tự"));
            }
            else if (this.SERVICE_NAME.Trim().Length <2)
            {
                results.Add(new ValidationResult("Tên dịch vụ nhỏ hơn 2 ký tự"));
            }

            if (string.IsNullOrWhiteSpace(this.SERVICE_CODE))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mã dịch vụ"));
            }
            else if (this.SERVICE_CODE.Trim().Length > 100)
            {
                results.Add(new ValidationResult("Mã dịch vụ lớn hơn 100 ký tự"));
            }
            else if (this.SERVICE_CODE.Trim().Length < 2)
            {
                results.Add(new ValidationResult("Mã dịch vụ nhỏ hơn 2 ký tự"));
            }


            if (!string.IsNullOrEmpty(this.SERVICE_RETURN_DATE))
            {
                if (this.SERVICE_RETURN_DATE.Length > 200)
                {
                    results.Add(new ValidationResult("Thời gian trả dịch vụ không được quá 200 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.SERVICE_NAME_ENG))
            {
                if (this.SERVICE_NAME_ENG.Length > 200)
                {
                    results.Add(new ValidationResult("Tên tiếng anh dịch vụ không được quá 200 ký tự"));
                }
            }


            if (this.SERVICE_PRICE.GetValueOrDefault() <= 0)
            {
                results.Add(new ValidationResult("Giá dịch vụ không được nhỏ hơn 0"));
            }

            if(this.SERVICE_UNIT <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn đơn vị"));
            }

            //if (this.SERVICE_PRICE_INSURANCE.GetValueOrDefault() <= 0)
            //{
            //    results.Add(new ValidationResult("Giá dịch vụ bảo hiểm không được nhỏ hơn 0"));
            //}

            if (!string.IsNullOrEmpty(this.SERVICE_NOTE))
            {
                if (this.SERVICE_NOTE.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả dịch vụ không được quá 500 ký tự"));
                }
            }

            return results;
        }
    }
}
