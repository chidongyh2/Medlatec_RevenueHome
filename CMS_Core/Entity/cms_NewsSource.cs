using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public  class cms_NewsSource : IValidatableObject
    {
        #region Constructors  
        public cms_NewsSource() { }
        #endregion
        #region Private Fields  
        private int _SourceId;
        private string _SourceName;
        private string _SourceLink;
        private int _SourceStatus;
        #endregion
        #region Public Properties  
        public int SourceId { get { return _SourceId; } set { _SourceId = value; } }
        public string SourceName { get { return _SourceName; } set { _SourceName = value; } }
        public string SourceLink { get { return _SourceLink; } set { _SourceLink = value; } }
        public int SourceStatus { get { return _SourceStatus; } set { _SourceStatus = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.SourceName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào nguồn tin"));
            }
            else if (this.SourceName.Length > 200)
            {
                results.Add(new ValidationResult("Nguồn tin lớn hơn 200 ký tự"));
            }

            if (string.IsNullOrEmpty(this.SourceLink))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào link nguồn tin"));
            }
            else if (this.SourceLink.Length > 200)
            {
                results.Add(new ValidationResult("Link nguồn tin lớn hơn 200 ký tự"));
            }
             
            return results;
        }
        #endregion
    }
}
