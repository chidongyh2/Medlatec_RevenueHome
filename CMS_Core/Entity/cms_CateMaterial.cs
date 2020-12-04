using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_CateMaterial : IValidatableObject
    {
        #region Constructors  
        public cms_CateMaterial() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _CateMaterial;
        private string _CateMaterialDesc;
        private int _CateMaterialStatus;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string CateMaterial { get { return _CateMaterial; } set { _CateMaterial = value; } }
        public string CateMaterialDesc { get { return _CateMaterialDesc; } set { _CateMaterialDesc = value; } }
        public int CateMaterialStatus { get { return _CateMaterialStatus; } set { _CateMaterialStatus = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.CateMaterial))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào loại nguồn nguyên liệu"));
            }
            else if (this.CateMaterial.Length > 200)
            {
                results.Add(new ValidationResult("Loại nguồn nguyên liệu lớn hơn 200 ký tự"));
            }
             


            if (!string.IsNullOrEmpty(this.CateMaterialDesc))
            {
                if (this.CateMaterialDesc.Length > 300)
                {
                    results.Add(new ValidationResult("Mô tả loại nguồn nguyên liệu không được dài quá 300 ký tự"));
                }

                
            }
             


            return results;
        }
        #endregion  }
    }
}