using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_SICK : IValidatableObject
    {
        public int ID { get; set; }
        public String SICK_NAME { get; set; }
        public String SICK_DESC { get; set; }
        public String SICK_SYMPTOM { get; set; }
        public String SICK_HEALING { get; set; }
        public String SICK_NOTE { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int SICK_STATUS { get; set; }
        public int PARTNERID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.SICK_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên bệnh"));
            }
            else if (this.SICK_NAME.Trim().Length > 200)
            {
                results.Add(new ValidationResult("Tên bệnh lớn hơn 200 ký tự"));
            }
            else if (this.SICK_NAME.Trim().Length < 2)
            {
                results.Add(new ValidationResult("Tên bệnh nhỏ hơn 2 ký tự"));
            }


            if (string.IsNullOrWhiteSpace(this.SICK_DESC))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mô tả bệnh"));
            }
            else if (this.SICK_DESC.Trim().Length > 300)
            {
                results.Add(new ValidationResult("Mô tả bệnh lớn hơn 300 ký tự"));
            }
            else if (this.SICK_DESC.Trim().Length < 2)
            {
                results.Add(new ValidationResult("Mô tả bệnh nhỏ hơn 2 ký tự"));
            }

            if (!string.IsNullOrWhiteSpace(this.SICK_SYMPTOM))
            {
                if (this.SICK_SYMPTOM.Trim().Length > 400)
                {
                    results.Add(new ValidationResult("Triệu chứng bệnh lớn hơn 400 ký tự"));
                }
                   
            }

            if (!string.IsNullOrWhiteSpace(this.SICK_HEALING))
            {
                if (this.SICK_HEALING.Trim().Length > 400)
                {
                    results.Add(new ValidationResult("Cách chữa bệnh lớn hơn 400 ký tự"));
                }

            }

            if (!string.IsNullOrWhiteSpace(this.SICK_NOTE))
            {
                if (this.SICK_NOTE.Trim().Length > 400)
                {
                    results.Add(new ValidationResult("Ghi chú bệnh lớn hơn 400 ký tự"));
                }

            }


            return results;
        }
    }
}
