using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_NewsTypeMessage : IValidatableObject
    {
        #region Constructors  
        public cms_NewsTypeMessage() { }
        #endregion
        #region Private Fields  
        private int _TypeMessageId;
        private string _TypeMessageName;
        private DateTime _Datesave;
        private int _TypeMessageStatus;
        #endregion
        #region Public Properties  
        public int TypeMessageId { get { return _TypeMessageId; } set { _TypeMessageId = value; } }
        public string TypeMessageName { get { return _TypeMessageName; } set { _TypeMessageName = value; } }
        public DateTime Datesave { get { return _Datesave; } set { _Datesave = value; } }
        public int TypeMessageStatus { get { return _TypeMessageStatus; } set { _TypeMessageStatus = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.TypeMessageName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào kiểu bài viết"));
            }
            else if (this.TypeMessageName.Length > 200)
            {
                results.Add(new ValidationResult("Kiểu bài viết lớn hơn 200 ký tự"));
            }
            
            return results;
        }
        #endregion

    }
}
