using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_News_Map_Tags
    {
        #region Constructors  
        public cms_News_Map_Tags() { }
        #endregion
        #region Private Fields  
        private int _Id;
        private int _newsId;
        private string _TagId;
        private DateTime _datesave;
        #endregion
        #region Public Properties  
        public int Id { get { return _Id; } set { _Id = value; } }
        public int newsId { get { return _newsId; } set { _newsId = value; } }
        public string TagId { get { return _TagId; } set { _TagId = value; } }
        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }
        #endregion
    }
}
