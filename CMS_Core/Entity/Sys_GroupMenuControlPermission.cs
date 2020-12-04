using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class Sys_GroupMenuControlPermission : IValidatableObject
    {
        #region Constructors  
        public Sys_GroupMenuControlPermission() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private int _GroupID;
        private int _MenID;
        private string _ControlID;
        private int _Permision;
        private bool _CheckPermision;
        private DateTime _datesave;
        private string _MenLink;
        private string _GroupName;
        private string _ControlName;
        private int _PARTNERID;
        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public int GroupID { get { return _GroupID; } set { _GroupID = value; } }
        public int MenID { get { return _MenID; } set { _MenID = value; } }
        public string ControlID { get { return _ControlID; } set { _ControlID = value; } }
        public int Permision { get { return _Permision; } set { _Permision = value; if (_Permision == 1) _CheckPermision = true; else _CheckPermision = false; } }
        public bool CheckPermision { get { return _CheckPermision; } set { _CheckPermision = value; } }

        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }
        public string MenLink { get { return _MenLink; } set { _MenLink = value; } }
        public string GroupName { get { return _GroupName; } set { _GroupName = value; } }
        public string ControlName { get { return _ControlName; } set { _ControlName = value; } }
        public int PARTNERID { get { return _PARTNERID; } set { _PARTNERID = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (GroupID <= 0)
            {
                results.Add(new ValidationResult("Chưa chọn nhóm account!"));
            }

            if (MenID <= 0)
            {
                results.Add(new ValidationResult("Chưa chọn menu!"));
            }

            if (string.IsNullOrEmpty(ControlID))
            {
                results.Add(new ValidationResult("Mời bạn chọn id control!"));
            }


 

            return results;
        }
        #endregion
    }
}
