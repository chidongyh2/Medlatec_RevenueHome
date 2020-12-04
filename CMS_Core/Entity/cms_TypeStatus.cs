using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_TypeStatus
    {
        #region Constructors  
        public cms_TypeStatus() { }
        #endregion
        #region Private Fields  
        private int _TypeStatusId;
        private string _TypeStatusName;
        private string _TypeStatusDesc;
        private DateTime _Datesave;
        #endregion
        #region Public Properties  
        public int TypeStatusId { get { return _TypeStatusId; } set { _TypeStatusId = value; } }
        public string TypeStatusName { get { return _TypeStatusName; } set { _TypeStatusName = value; } }
        public string TypeStatusDesc { get { return _TypeStatusDesc; } set { _TypeStatusDesc = value; } }
        public DateTime Datesave { get { return _Datesave; } set { _Datesave = value; } }
        #endregion
    }
}
