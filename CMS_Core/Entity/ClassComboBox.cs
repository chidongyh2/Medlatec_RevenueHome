using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class ClassComboBox
    {
        #region Constructors  
        public ClassComboBox()
        {

        }
        #endregion
        #region Private Fields          
        private string _idfield;
        private string _namefield;

        #endregion
        #region Public Properties  

        public string idfield { get { return _idfield; } set { _idfield = value; } }
        public string namefield { get { return _namefield; } set { _namefield = value; } }


        #endregion

    }
}
