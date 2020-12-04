using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_MEDICINE : IValidatableObject
    {
        public int ID { get; set; }
        public String MEDICINE_NAME { get; set; }
        public String MEDICINE_NAME_EN { get; set; }
        public String MEDICINE_DES { get; set; }
        public String MEDICINE_CODE { get; set; }
        public int MEDICINE_UNIT { get; set; }
        public String MEDICINE_NOTE { get; set; }
        public String MEDICINE_BARCODE { get; set; }
        public String MEDICINE_USAGE { get; set; }
        public int MEDICINE_TEMPERATURE { get; set; }
        public String MEDICINE_LIGHT { get; set; }
        public String MEDICINE_HANDS { get; set; }
        public String MEDICINE_WET { get; set; }
        public int MEDICINE_CREATEBY { get; set; }
        public DateTime MEDICINE_CREATEDATE { get; set; }
        public Int16 MEDICINE_STATUS { get; set; }
        public Int32 MEDICINE_LOCATION { get; set; }
        public float? MEDICINE_INVENTORY { get; set; }
        public int MEDICINE_UPDATEBY { get; set; }
        public DateTime MEDICINE_UPDATEDATE { get; set; }

        private int _MEDICINE_HUONGTHAN;
        private bool _MEDICINE_HUONGTHANCheck;
        public int MEDICINE_HUONGTHAN { get { return _MEDICINE_HUONGTHAN; } set { _MEDICINE_HUONGTHAN = value; if (_MEDICINE_HUONGTHAN == 1) _MEDICINE_HUONGTHANCheck = true; else _MEDICINE_HUONGTHANCheck = false; } }
        public bool MEDICINE_HUONGTHANCheck { get { return _MEDICINE_HUONGTHANCheck; } set { _MEDICINE_HUONGTHANCheck = value; } }


        private int _MEDICINE_INSURANCE;
        private bool _MEDICINE_INSURANCECheck;
        public int MEDICINE_INSURANCE { get { return _MEDICINE_INSURANCE; } set { _MEDICINE_INSURANCE = value; if (_MEDICINE_INSURANCE == 1) _MEDICINE_INSURANCECheck = true; else _MEDICINE_INSURANCECheck = false; } }
        public bool MEDICINE_INSURANCECheck { get { return _MEDICINE_INSURANCECheck; } set { _MEDICINE_INSURANCECheck = value; } }

        public Int32 PARTNERID { get; set; }
        public Int32 GROUP_MEDICINE { get; set; }
        public String GROUP_MEDICINE_NAME { get; set; }
        public String MEDICINE_UNIT_NAME { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.MEDICINE_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên thuốc"));
            }
            else if (this.MEDICINE_NAME.Length > 300)
            {
                results.Add(new ValidationResult("Tên thuốc lớn hơn 300 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.MEDICINE_NAME_EN))
            {
                if (this.MEDICINE_NAME_EN.Length > 300)
                {
                    results.Add(new ValidationResult("Tên tiếng anh thuốc không được dài quá 300 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.MEDICINE_DES))
            {
                if (this.MEDICINE_DES.Length > 4000)
                {
                    results.Add(new ValidationResult("Mô tả thuốc không được dài quá 4000 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.MEDICINE_CODE))
            {
                if (this.MEDICINE_CODE.Length > 200)
                {
                    results.Add(new ValidationResult("Mã tên thuốc lớn hơn 200 ký tự"));
                }
            }

            //if (string.IsNullOrEmpty(this.MEDICINE_CODE))
            //{
            //    results.Add(new ValidationResult("Mời bạn nhập vào mã tên thuốc"));
            //}
            //else if (this.MEDICINE_CODE.Length > 200)
            //{
            //    results.Add(new ValidationResult("Mã tên thuốc lớn hơn 200 ký tự"));
            //}


            if (this.MEDICINE_UNIT <= 0)
            {
                results.Add(new ValidationResult("Mời bạn nhập đơn vị"));
            }

            if (this.GROUP_MEDICINE <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn nhóm thuốc"));
            }


            if (!string.IsNullOrEmpty(this.MEDICINE_NOTE))
            {
                if (this.MEDICINE_NOTE.Length > 500)
                {
                    results.Add(new ValidationResult("Ghi chú thuốc không được dài quá 500 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.MEDICINE_USAGE))
            {
                if (this.MEDICINE_USAGE.Length > 800)
                {
                    results.Add(new ValidationResult("Hướng dẫn sử dụng thuốc không được dài quá 800 ký tự"));
                }
            }

           

            if (!string.IsNullOrEmpty(this.MEDICINE_LIGHT))
            {
                if (this.MEDICINE_LIGHT.Length > 200)
                {
                    results.Add(new ValidationResult("Ánh sáng thuốc không được dài quá 200 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.MEDICINE_HANDS))
            {
                if (this.MEDICINE_HANDS.Length > 200)
                {
                    results.Add(new ValidationResult("Để xa tâm tay thuốc không được dài quá 200 ký tự"));
                }
            }

            if(this.MEDICINE_INVENTORY < 0)
            {
                results.Add(new ValidationResult("Tồn kho không được để nhỏ hơn 0"));
            }

            if (!string.IsNullOrEmpty(this.MEDICINE_WET))
            {
                if (this.MEDICINE_WET.Length > 200)
                {
                    results.Add(new ValidationResult("Độ ẩm thuốc không được dài quá 200 ký tự"));
                }
            }

            if (this.MEDICINE_TEMPERATURE ==0)
            {
                results.Add(new ValidationResult("Mời bạn chọn nhiệt độ lữu trữ"));
            }

            return results;
        }
    }
}
