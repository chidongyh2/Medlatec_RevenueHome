using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Menu : IValidatableObject
    {
        #region Constructors  
        public cms_Menu() { }
        #endregion
        #region Private Fields  
        private int _menId;
        private string _menName;
        private string _menTitle;
        private string _menKeyword;
        private string _menDes;
        private string _menLinks;
        private int _cateId;
        private int _menOrd;
        private string _menImg;
        private int _MENDISPLAY;
        private int _MENStatus;
        private string _Style;
        private int _CreateBy;
        private DateTime _Create_date;
        private int _UpdateBy;
        private DateTime _Update_date;
        private bool _view;

        private int _parentID;
        private string _menuParrent;

        #endregion
        #region Public Properties  
        public int menId { get { return _menId; } set { _menId = value; } }
        public string menName { get { return _menName; } set { _menName = value; } }
        public string menTitle { get { return _menTitle; } set { _menTitle = value; } }
        public string menKeyword { get { return _menKeyword; } set { _menKeyword = value; } }
        public string menDes { get { return _menDes; } set { _menDes = value; } }
        public string menLinks { get { return _menLinks; } set { _menLinks = value; } }
        public int cateId { get { return _cateId; } set { _cateId = value; } }
        public int menOrd { get { return _menOrd; } set { _menOrd = value; } }
        public string menImg { get { return _menImg; } set { _menImg = value; } }
        public int MENDISPLAY { get { return _MENDISPLAY; } set { _MENDISPLAY = value; if (_MENDISPLAY == 1) { _view = true; } else _view = false; } }
        public int MENStatus { get { return _MENStatus; } set { _MENStatus = value; } }
        public string Style { get { return _Style; } set { _Style = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime Create_date { get { return _Create_date; } set { _Create_date = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime Update_date { get { return _Update_date; } set { _Update_date = value; } }
        public int parentID { get { return _parentID; } set { _parentID = value; } }
        public bool view { get { return _view; } set { _view = value; } }

        public string menuParrent { get { return _menuParrent; } set { _menuParrent = value; } }

        #endregion
        #region Public Properties  


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.menName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên menu"));
            }
            else if (this.menName.Length > 200)
            {
                results.Add(new ValidationResult("Tên menu lớn hơn 200 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.menTitle))
            {
                if (this.menTitle.Length > 300)
                {
                    results.Add(new ValidationResult("Tiêu đề menu không được dài quá 300 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.menKeyword))
            {
                if (this.menKeyword.Length > 500)
                {
                    results.Add(new ValidationResult("Từ khóa menu không được dài quá 500 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.menLinks))
            {
                if (this.menLinks.Length > 200)
                {
                    results.Add(new ValidationResult("Link menu không được dài quá 200 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.Style))
            {
                if (this.Style.Length > 100)
                {
                    results.Add(new ValidationResult("Style menu không được dài quá 100 ký tự"));
                }
            }

            if(this.menOrd < 0)
            {
                results.Add(new ValidationResult("Vị trí hiển thị không được nhỏ hơn 0"));
            }

            return results;
        }
        #endregion
    }
}
