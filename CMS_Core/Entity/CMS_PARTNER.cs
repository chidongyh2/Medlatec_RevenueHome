using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_PARTNER : IValidatableObject
    {
        public int ID { get; set; }
        public string PARTNER_NAME { get; set; }
        public string PARTNER_ADDRESS { get; set; }
        public string PARTNER_MOBILE { get; set; }
        public string PARTNER_EMAIL { get; set; }
        public string PARTNER_WEBSITE { get; set; }
        public string PARTNER_SURROGATE { get; set; }
        public string PARTNER_SURROGATE_MOBILE { get; set; }
        public string PARTNER_SURROGATE_POSITION { get; set; }
        public string PARTNER_MANAGER { get; set; }
        public string PARTNER_MANAGER_MOBILE { get; set; }
        public string PARTNER_MANAGER_EMAIL { get; set; }
        public int PARTNER_STATUS { get; set; }
        public int PARTNER_CREATE { get; set; }
        public string PARTNER_CODE { get; set; }

        
        public System.DateTime PARTNER_CREATE_DATE { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.PARTNER_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên đối tác"));
            }
            else if (this.PARTNER_NAME.Trim().Length > 100)
            {
                results.Add(new ValidationResult("Tên đối tác lớn hơn 100 ký tự"));
            }
            else if (this.PARTNER_NAME.Trim().Length < 4)
            {
                results.Add(new ValidationResult("Tên đối tác nhỏ hơn 4 ký tự"));
            }

            if (string.IsNullOrEmpty(this.PARTNER_ADDRESS))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào địa chỉ đối tác"));
            }
            else if (this.PARTNER_ADDRESS.Trim().Length > 200)
            {
                results.Add(new ValidationResult("Địa chỉ đối tác lớn hơn 200 ký tự"));
            }
            else if (this.PARTNER_ADDRESS.Trim().Length < 4)
            {
                results.Add(new ValidationResult("Địa chỉ đối tác nhỏ hơn 4 ký tự"));
            }

            if (string.IsNullOrEmpty(this.PARTNER_MOBILE))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào điện thoại đối tác"));
            }
            else if (this.PARTNER_MOBILE.Length > 50)
            {
                results.Add(new ValidationResult("Điện thoại đối tác lớn hơn 50 ký tự"));
            }

            if (string.IsNullOrEmpty(this.PARTNER_EMAIL))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào email đối tác"));
            }
            else if (this.PARTNER_EMAIL.Length > 100)
            {
                results.Add(new ValidationResult("Email đối tác lớn hơn 100 ký tự"));
            }

            if (string.IsNullOrEmpty(this.PARTNER_SURROGATE))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào người đại diện đối tác"));
            }
            else if (this.PARTNER_SURROGATE.Length > 100)
            {
                results.Add(new ValidationResult("Người đại diện đối tác lớn hơn 100 ký tự"));
            }

            if (string.IsNullOrEmpty(this.PARTNER_CODE))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào code đối tác"));
            }
            else if (this.PARTNER_CODE.Length != 3)
            {
                results.Add(new ValidationResult("Code đối tác khác 3 ký tự"));
            }
            else if (this.PARTNER_CODE.IndexOf(" ") != -1)
            {
                results.Add(new ValidationResult("Code đối tác không có ký tự trống"));
            }
            else if (Common.Common.ContainsUnicodeCharacter(this.PARTNER_CODE))
            {
                results.Add(new ValidationResult("Code đối tác chứa ký tự không phải unicode"));
            }
            else if (Common.Common.hasSpecialChar(this.PARTNER_CODE))
            {
                results.Add(new ValidationResult("Code đối tác có ký tự đặc biệt"));
            }


            if (!string.IsNullOrEmpty(this.PARTNER_SURROGATE_MOBILE))
            {
                if (this.PARTNER_SURROGATE_MOBILE.Length > 50)
                {
                    results.Add(new ValidationResult("Điện thoại người đại diện không được quá 50 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.PARTNER_SURROGATE_POSITION))
            {
                if (this.PARTNER_SURROGATE_POSITION.Length > 100)
                {
                    results.Add(new ValidationResult("Vị trí người đại diện không được quá 100 ký tự"));
                }
            }

            return results;
        }
    }
}
