using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_News_Cate : IValidatableObject
    {
        #region Constructors  
        public cms_News_Cate() { }
        #endregion
        #region Private Fields  
        private int _Id;
        private int _newsId;
        private int _CateId;
        private string _newsName;
        private string _newsDescription;
        private string _newsImages;
        private DateTime _datepub;
        private int _Status;
        private DateTime _datesave;
        #endregion
        #region Public Properties  
        public int Id { get { return _Id; } set { _Id = value; } }
        public int newsId { get { return _newsId; } set { _newsId = value; } }
        public int CateId { get { return _CateId; } set { _CateId = value; } }
        public string newsName { get { return _newsName; } set { _newsName = value; } }
        public string newsDescription { get { return _newsDescription; } set { _newsDescription = value; } }
        public string newsImages { get { return _newsImages; } set { _newsImages = value; } }
        public DateTime datepub { get { return _datepub; } set { _datepub = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }

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

            if (string.IsNullOrEmpty(this.newsImages))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào ảnh đại diện"));
            }
            else if (this.newsImages.Length > 300)
            {
                results.Add(new ValidationResult("Ảnh đại diện bài viết lớn hơn 300 ký tự"));
            }
             

            return results;
        }
        #endregion
    }
}
