using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Category : IValidatableObject
    {
        #region Constructors  
        public cms_Category() { }
        #endregion
        #region Private Fields  
        private int _cateId;
        private string _cateName;
        private string _cateKeyword;
        private string _cateDescription;
        private string _cateImages;
        private int _cateParrent;
        private int _cateOrd;
        private string _cateLang;
        private bool _isShowHome;
        private int _cateStatus;
        private string _CateAlias;
        private int _CreateBy;
        private DateTime _Create_date;
        private int _UpdateBy;
        private DateTime _Update_date;
        #endregion
        #region Public Properties  
        public int cateId { get { return _cateId; } set { _cateId = value; } }
        public string cateName { get { return _cateName; } set { _cateName = value; } }
        public string cateKeyword { get { return _cateKeyword; } set { _cateKeyword = value; } }
        public string cateDescription { get { return _cateDescription; } set { _cateDescription = value; } }
        public string cateImages { get { return _cateImages; } set { _cateImages = value; } }
        public int cateParrent { get { return _cateParrent; } set { _cateParrent = value; } }
        public int cateOrd { get { return _cateOrd; } set { _cateOrd = value; } }
        public string cateLang { get { return _cateLang; } set { _cateLang = value; } }
        public bool isShowHome { get { return _isShowHome; } set { _isShowHome = value; } }
        public int cateStatus { get { return _cateStatus; } set { _cateStatus = value; } }
        public string CateAlias { get { return _CateAlias; } set { _CateAlias = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime Create_date { get { return _Create_date; } set { _Create_date = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime Update_date { get { return _Update_date; } set { _Update_date = value; } }
        #endregion   



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.cateName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên chuyên mục"));
            }
            else if (this.cateName.Trim().Length > 200)
            {
                results.Add(new ValidationResult("Tên chuyên mục lớn hơn 200 ký tự"));
            }
            else if (this.cateName.Trim().Length < 2)
            {
                results.Add(new ValidationResult("Tên chuyên mục nhỏ hơn 2 ký tự"));
            }


            if (string.IsNullOrWhiteSpace(this.cateKeyword))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào từ khóa chuyên mục"));
            }
            else if (this.cateKeyword.Trim().Length > 300)
            {
                results.Add(new ValidationResult("Từ khóa chuyên mục lớn hơn 300 ký tự"));
            }
            else if (this.cateKeyword.Trim().Length < 2)
            {
                results.Add(new ValidationResult("Từ khóa chuyên mục nhỏ hơn 2 ký tự"));
            }

            if (string.IsNullOrWhiteSpace(this.cateDescription))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mô tả chuyên mục"));
            }
            else if (this.cateDescription.Trim().Length > 200)
            {
                results.Add(new ValidationResult("Mô tả chuyên mục lớn hơn 200 ký tự"));
            }
            else if (this.cateDescription.Trim().Length < 2)
            {
                results.Add(new ValidationResult("Mô tả chuyên mục nhỏ hơn 2 ký tự"));
            }


            if (cateOrd < 0 )
            {
                results.Add(new ValidationResult("Vị trị không để nhỏ hơn 0"));
            }

            if (cateParrent < 0)
            {
                results.Add(new ValidationResult("Chuyên mục cha không được nhỏ hơ 0"));
            }


            return results;
        }


        
    }
}
