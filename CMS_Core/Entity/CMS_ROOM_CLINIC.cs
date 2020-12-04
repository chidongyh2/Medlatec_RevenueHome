using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_ROOM_CLINIC : IValidatableObject
    {
        public int ID { get; set; }
        public String ROOM_NAME { get; set; }
        public String ROOM_DESC { get; set; }
        public int GROUP_SEVICEID { get; set; }
        public int SERVICE_ID { get; set; }
        public int DEPARTMENT_ID { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int PARTNERID { get; set; }
        public int STATUS { get; set; }
        public int SERVICETYPE { get; set; }
        
        public String DEPARTMENT_NAME { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.ROOM_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên phòng khám"));
            }
            else if (this.ROOM_NAME.Length > 300)
            {
                results.Add(new ValidationResult("Tên phòng khám lớn hơn 300 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.ROOM_DESC))
            {
                if (this.ROOM_DESC.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả phòng khám không được dài quá 500 ký tự"));
                }
            }

            if(DEPARTMENT_ID == 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn khoa"));
            }

            return results;
        }
    }
}
