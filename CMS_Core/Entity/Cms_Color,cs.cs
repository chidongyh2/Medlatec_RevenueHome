using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class Cms_Color : IValidatableObject
    {
        #region Constructors  
        public Cms_Color() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _ColorName;
        private string _ColorDesc;
        private int _ColorStatus;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string ColorName { get { return _ColorName; } set { _ColorName = value; } }
        public string ColorDesc { get { return _ColorDesc; } set { _ColorDesc = value; } }
        public int ColorStatus { get { return _ColorStatus; } set { _ColorStatus = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.ColorName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mầu nguyên liệu "));
            }
            else if (this.ColorName.Length > 200)
            {
                results.Add(new ValidationResult("Mầu nguyên liệu lớn hơn 200 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.ColorDesc))
            {
                if (this.ColorDesc.Length > 300)
                {
                    results.Add(new ValidationResult("Mô tả mầu nguyên liệu không được dài quá 300 ký tự"));
                }
            }



            return results;
        }
        #endregion  }
    }
}
