using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_AccountType : IValidatableObject
    {
        #region Constructors  
        public cms_AccountType() { }
        #endregion
        #region Private Fields  
        private int _AccountTypeId;
        private string _AName;
        private string _ADesc;
        private int _Status;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;

        #endregion
        #region Public Properties  
        public int AccountTypeId { get { return _AccountTypeId; } set { _AccountTypeId = value; } }
        public string AName { get { return _AName; } set { _AName = value; } }
        public string ADesc { get { return _ADesc; } set { _ADesc = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }

        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.AName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên nhóm"));
            }
            else if (this.AName.Length > 200)
            {
                results.Add(new ValidationResult("Tên nhóm lớn hơn 200 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.ADesc))
            {
                if (this.ADesc.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả nhóm không được dài quá 500 ký tự"));
                }
            }

            return results;
        }
        #endregion  }
    }
}
