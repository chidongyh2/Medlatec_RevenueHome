using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_News : IValidatableObject
    {
        #region Constructors  
        public cms_News() { }
        #endregion
        #region Private Fields  
        private int _newsId;
        private int _cateId;
        private int _SourceId;
        private int _userId;
        private string _newsName;
        private string _newsKeyword;
        private string _newsDescription;       
        private string _newsContent;
        private string _newsImages;
        private string _newsTitleImages;
        private string _newsAuthor;
        private DateTime _dateCreate;
        private string _newsFile;
        private bool _copyRight;
        private bool _allowComment;
        private bool _alowSend;
        private bool _alowPrint;
        private string _lang;
        private int _AccountTypeId;
        private DateTime _datepub;
        private int _Status;
        private string _UrlSource;
        private int _VoteID;
        private int _newsTypeMessage;
        private string _cateIdList;
        private string _datepubText;
        private string _ParentName;
        private string _ChildName;


        public HttpPostedFileBase ImageFile { get; set; }
        public HttpPostedFileBase ImageFB { get; set; }

        #endregion
        #region Public Properties  
        public int newsId { get { return _newsId; } set { _newsId = value; } }
        public int cateId { get { return _cateId; } set { _cateId = value; } }
        public int SourceId { get { return _SourceId; } set { _SourceId = value; } }
        public int userId { get { return _userId; } set { _userId = value; } }
        public string newsName { get { return _newsName; } set { _newsName = value; } }
        public string newsKeyword { get { return _newsKeyword; } set { _newsKeyword = value; } }
        public string newsDescription { get { return _newsDescription; } set { _newsDescription = value; } }
        public string newsContent { get { return _newsContent; } set { _newsContent = value; } }
        public string newsImages { get { return _newsImages; } set { _newsImages = value; } }
        public string newsTitleImages { get { return _newsTitleImages; } set { _newsTitleImages = value; } }
        public string newsAuthor { get { return _newsAuthor; } set { _newsAuthor = value; } }
        public DateTime dateCreate { get { return _dateCreate; } set { _dateCreate = value; } }
        public string newsFile { get { return _newsFile; } set { _newsFile = value; } }
        public bool copyRight { get { return _copyRight; } set { _copyRight = value; } }
        public bool allowComment { get { return _allowComment; } set { _allowComment = value; } }
        public bool alowSend { get { return _alowSend; } set { _alowSend = value; } }
        public bool alowPrint { get { return _alowPrint; } set { _alowPrint = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int AccountTypeId { get { return _AccountTypeId; } set { _AccountTypeId = value; } }
        public DateTime datepub { get { return _datepub; } set { _datepub = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string UrlSource { get { return _UrlSource; } set { _UrlSource = value; } }
        public int VoteID { get { return _VoteID; } set { _VoteID = value; } }
        public int newsTypeMessage { get { return _newsTypeMessage; } set { _newsTypeMessage = value; } }
        public string cateIdList { get { return _cateIdList; } set { _cateIdList = value; } }
        public string datepubText { get { return _datepubText; } set { _datepubText = value; } }
        public string ParentName { get { return _ParentName; } set { _ParentName = value; } }
        public string ChildName { get { return _ChildName; } set { _ChildName = value; } }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.newsName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tiêu đề bài viết"));
            }
            else if (this.newsName.Length > 300)
            {
                results.Add(new ValidationResult("Tiêu đề bài viết lớn hơn 300 ký tự"));
            }

            if (string.IsNullOrEmpty(this.newsDescription))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào Sapo viết"));
            }
            else if (this.newsDescription.Length > 300)
            {
                results.Add(new ValidationResult("Sapo bài viết lớn hơn 300 ký tự"));
            }

          
            if (!string.IsNullOrEmpty(this.newsAuthor))
            {
                if (this.newsAuthor.Length > 200)
                {
                    results.Add(new ValidationResult("Tên tác giả không được dài quá 200 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.newsKeyword))
            {
                if (this.newsKeyword.Length > 500)
                {
                    results.Add(new ValidationResult("Từ khóa bài viết không được dài quá 500 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.UrlSource))
            {
                if (this.UrlSource.Length > 400)
                {
                    results.Add(new ValidationResult("Link bài gốc không được dài quá 400 ký tự"));
                }
            }

            

            return results;
        }
        #endregion

    }
}
