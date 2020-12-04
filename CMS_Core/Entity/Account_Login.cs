using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public  class Account_Login 
    {
        #region Constructors  
        public Account_Login() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _Username;
        private DateTime _DateLogin;
        private string _IP;
        private string _Status;
        private int _Userid;
        
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string Username { get { return _Username; } set { _Username = value; } }
        public DateTime DateLogin { get { return _DateLogin; } set { _DateLogin = value; } }
        public string IP { get { return _IP; } set { _IP = value; } }
        public string Status { get { return _Status; } set { _Status = value; } }
        public int Userid { get { return _Userid; } set { _Userid = value; } }

        #endregion
    }
}
