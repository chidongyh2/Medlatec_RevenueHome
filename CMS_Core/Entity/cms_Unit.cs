using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Unit : IValidatableObject
    {
        #region Constructors  
        public cms_Unit() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _UnitName;
        private string _UnitDesc;
        private int _UnitStatus;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string UnitName { get { return _UnitName; } set { _UnitName = value; } }
        public string UnitDesc { get { return _UnitDesc; } set { _UnitDesc = value; } }
        public int UnitStatus { get { return _UnitStatus; } set { _UnitStatus = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.UnitName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên đơn vị tính"));
            }
            else if (this.UnitName.Length > 100)
            {
                results.Add(new ValidationResult("Tên đơn vị tính lớn hơn 100 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.UnitDesc))
            {
                if (this.UnitDesc.Length > 200)
                {
                    results.Add(new ValidationResult("Mô tả tên đơn vị tính không được dài quá 200 ký tự"));
                }
            }

            return results;
        }
        #endregion  }
    }
}
