using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_News_Relate
    {
        #region Constructors  
        public cms_News_Relate() { }
        #endregion
        #region Private Fields  
        private int _Id;
        private int _newsIdSource;
        private int _newsIdRelate;
        private string _newsName;
        private int _cateId;
        private string _newsImages;
        private int _SourceId;
        private DateTime _datepub;
        private DateTime _datesave;
        #endregion
        #region Public Properties  
        public int Id { get { return _Id; } set { _Id = value; } }
        public int newsIdSource { get { return _newsIdSource; } set { _newsIdSource = value; } }
        public int newsIdRelate { get { return _newsIdRelate; } set { _newsIdRelate = value; } }
        public string newsName { get { return _newsName; } set { _newsName = value; } }
        public int cateId { get { return _cateId; } set { _cateId = value; } }
        public string newsImages { get { return _newsImages; } set { _newsImages = value; } }
        public int SourceId { get { return _SourceId; } set { _SourceId = value; } }
        public DateTime datepub { get { return _datepub; } set { _datepub = value; } }
        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }
        #endregion
    }
}
