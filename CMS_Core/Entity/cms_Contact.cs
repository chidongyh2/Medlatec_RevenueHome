using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Contact
    {
        #region Constructors  
        public cms_Contact() { }
        #endregion
        #region Private Fields  
        private int _contactId;
        private string _FullName;
        private string _Email;
        private string _Address;
        private string _Phone;
        private string _Title;
        private string _Content;
        private DateTime _DateCreate;
        private bool _FeedBack;
        private DateTime _DateFeedBack;
        #endregion
        #region Public Properties  
        public int contactId { get { return _contactId; } set { _contactId = value; } }
        public string FullName { get { return _FullName; } set { _FullName = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string Content { get { return _Content; } set { _Content = value; } }
        public DateTime DateCreate { get { return _DateCreate; } set { _DateCreate = value; } }
        public bool FeedBack { get { return _FeedBack; } set { _FeedBack = value; } }
        public DateTime DateFeedBack { get { return _DateFeedBack; } set { _DateFeedBack = value; } }
        #endregion  }
    }
}
