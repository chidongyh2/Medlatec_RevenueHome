using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Permission
    {
        #region Constructors  
        public cms_Permission() { }
        #endregion
        #region Private Fields  
        private int _permissionId;
        private string _permissionName;
        private string _permissionValue;
        #endregion
        #region Public Properties  
        public int permissionId { get { return _permissionId; } set { _permissionId = value; } }
        public string permissionName { get { return _permissionName; } set { _permissionName = value; } }
        public string permissionValue { get { return _permissionValue; } set { _permissionValue = value; } }
        #endregion
    }
}
