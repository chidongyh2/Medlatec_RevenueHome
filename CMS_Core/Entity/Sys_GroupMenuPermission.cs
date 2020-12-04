using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class Sys_GroupMenuPermission
    {
        #region Constructors  
        public Sys_GroupMenuPermission() { }
        #endregion
        #region Private Fields  
        private int _GroupID;
        private int _MenID;
        private int _Permision;
        #endregion
        #region Public Properties  
        public int GroupID { get { return _GroupID; } set { _GroupID = value; } }
        public int MenID { get { return _MenID; } set { _MenID = value; } }
        public int Permision { get { return _Permision; } set { _Permision = value; } }
        #endregion
    }
}
