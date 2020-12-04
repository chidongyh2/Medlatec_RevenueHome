using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_type_Meterial : IValidatableObject
    {
        #region Constructors  
        public cms_type_Meterial() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _TypeMeterialName;
        private string _TypeMeterialDesc;
        private int _TypeMeterialStatus;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string TypeMeterialName { get { return _TypeMeterialName; } set { _TypeMeterialName = value; } }
        public string TypeMeterialDesc { get { return _TypeMeterialDesc; } set { _TypeMeterialDesc = value; } }
        public int TypeMeterialStatus { get { return _TypeMeterialStatus; } set { _TypeMeterialStatus = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.TypeMeterialName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào loại nguyên liệu "));
            }
            else if (this.TypeMeterialName.Length > 200)
            {
                results.Add(new ValidationResult("Loại nguyên liệu lớn hơn 200 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.TypeMeterialDesc))
            {
                if (this.TypeMeterialDesc.Length > 300)
                {
                    results.Add(new ValidationResult("Mô tả loại nguyên liệu không được dài quá 300 ký tự"));
                }
            }



            return results;
        }
        #endregion  }
    }
}