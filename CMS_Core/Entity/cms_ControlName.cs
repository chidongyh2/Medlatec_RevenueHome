using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_ControlName : IValidatableObject
    {
        #region Constructors  
        public cms_ControlName() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private string _ControlID;
        private string _ControlName;
        private int _menID;
        private string _ControlDes;
        private int _ControlStatus;
        private DateTime _datesave;
        private int _LangID;
        private string _menName;
        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public string ControlID { get { return _ControlID; } set { _ControlID = value; } }
        public string ControlName { get { return _ControlName; } set { _ControlName = value; } }
        public int menID { get { return _menID; } set { _menID = value; } }
        public string ControlDes { get { return _ControlDes; } set { _ControlDes = value; } }
        public int ControlStatus { get { return _ControlStatus; } set { _ControlStatus = value; } }
        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }
        public int LangID { get { return _LangID; } set { _LangID = value; } }
        public string menName { get { return _menName; } set { _menName = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.ControlID))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào ControlID"));
            }
            else if (this.ControlID.Length > 200)
            {
                results.Add(new ValidationResult("ControlID lớn hơn 200 ký tự"));
            }

            if (string.IsNullOrEmpty(this.ControlName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên Control"));
            }
            else if (this.ControlName.Length > 300)
            {
                results.Add(new ValidationResult("Tên ControlName lớn hơn 300 ký tự"));
            }


            if (!string.IsNullOrEmpty(this.ControlDes))
            {
                if (this.ControlDes.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả Control không được dài quá 500 ký tự"));
                }
            }

           

            return results;
        }
        #endregion
    }
}
