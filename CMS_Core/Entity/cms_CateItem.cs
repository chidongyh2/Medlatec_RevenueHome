using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_CateItem : IValidatableObject
    {
        #region Constructors  
        public cms_CateItem() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _CateItem;
        private string _CateItemDesc;
        private int _CateItemStatus;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string CateItem { get { return _CateItem; } set { _CateItem = value; } }
        public string CateItemDesc { get { return _CateItemDesc; } set { _CateItemDesc = value; } }
        public int CateItemStatus { get { return _CateItemStatus; } set { _CateItemStatus = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.CateItem))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên nhóm sản phầm"));
            }
            else if (this.CateItem.Length > 300)
            {
                results.Add(new ValidationResult("Tên nhóm sản phầm lớn hơn 300 ký tự"));
            }
            


            if (!string.IsNullOrEmpty(this.CateItemDesc))
            {
                if (this.CateItemDesc.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả nhóm sản phẩm không được dài quá 500 ký tự"));
                }

                
            }

            


            return results;
        }
        #endregion  }
    }
}
