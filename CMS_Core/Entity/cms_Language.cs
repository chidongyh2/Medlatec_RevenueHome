using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Language
    {
        #region Constructors  
        public cms_Language() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private string _LanguageName;
        private string _LanguageDes;
        private int _LanguageStatus;
        private DateTime _datesave;
        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public string LanguageName { get { return _LanguageName; } set { _LanguageName = value; } }
        public string LanguageDes { get { return _LanguageDes; } set { _LanguageDes = value; } }
        public int LanguageStatus { get { return _LanguageStatus; } set { _LanguageStatus = value; } }
        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }
        #endregion
    }
}
