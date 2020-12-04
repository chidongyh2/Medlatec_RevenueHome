using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Type : IValidatableObject
    {
        #region Constructors  
        public cms_Type() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _TypeName;
        private string _TypeDesc;
        private int _TypeStatus;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private int _TypeOrder;

        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string TypeName { get { return _TypeName; } set { _TypeName = value; } }
        public string TypeDesc { get { return _TypeDesc; } set { _TypeDesc = value; } }
        public int TypeStatus { get { return _TypeStatus; } set { _TypeStatus = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }

        public int TypeOrder { get { return _TypeOrder; } set { _TypeOrder = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.TypeName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên trạng thái đơn hàng"));
            }
            else if (this.TypeName.Length > 300)
            {
                results.Add(new ValidationResult("Trạng thái đơn hàng lớn hơn 300 ký tự"));
            }



            if (!string.IsNullOrEmpty(this.TypeDesc))
            {
                if (this.TypeDesc.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả trạng thái đơn hàng không được dài quá 500 ký tự"));
                }


            }

            if(this.TypeOrder < 0)
            {
                results.Add(new ValidationResult("Vị trí trạng thái không được nhỏ hơn 0"));
            }



            return results;
        }
        #endregion  }
    }

}