using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public  class Account_LogAction
    {
        #region Constructors  
        public Account_LogAction() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _Username;
        private DateTime _DateLog;
        private string _IP;
        private string _menu;
        private int _actionType;
        private string _logActionID;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string Username { get { return _Username; } set { _Username = value; } }
        public DateTime DateLog { get { return _DateLog; } set { _DateLog = value; } }
        public string IP { get { return _IP; } set { _IP = value; } }
        public string menu { get { return _menu; } set { _menu = value; } }
        public int actionType { get { return _actionType; } set { _actionType = value; } }
        public string logActionID { get { return _logActionID; } set { _logActionID = value; } }
        #endregion

    }
}
