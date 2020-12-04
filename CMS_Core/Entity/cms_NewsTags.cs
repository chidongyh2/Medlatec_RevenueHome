using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_NewsTags
    {
        #region Constructors  
        public cms_NewsTags() { }
        #endregion
        #region Private Fields  
        private int _TagId;
        private string _TagName;
        private string _TagDes;
        #endregion
        #region Public Properties  
        public int TagId { get { return _TagId; } set { _TagId = value; } }
        public string TagName { get { return _TagName; } set { _TagName = value; } }
        public string TagDes { get { return _TagDes; } set { _TagDes = value; } }
        #endregion

    }
}
