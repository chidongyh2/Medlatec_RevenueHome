using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class Sys_User
    {
        #region Constructors  
        public Sys_User() { }
        #endregion
        #region Private Fields  
        private string _UserID;
        private string _UserName;
        private string _Password;
        private string _ShortName;
        private object _Photo;
        private bool _Active;
        private int _PartnerID;
        private object _DigitalSignature;
        private string _Phone;
        private string _StartBy;
        private string _UserCode;
        private string _UserFull;
        private string _LocationID;
        private DateTime _createdate;
        #endregion
        #region Public Properties  
        public string UserID { get { return _UserID; } set { _UserID = value; } }
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public string ShortName { get { return _ShortName; } set { _ShortName = value; } }
        public object Photo { get { return _Photo; } set { _Photo = value; } }
        public bool Active { get { return _Active; } set { _Active = value; } }
        public int PartnerID { get { return _PartnerID; } set { _PartnerID = value; } }
        public object DigitalSignature { get { return _DigitalSignature; } set { _DigitalSignature = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string StartBy { get { return _StartBy; } set { _StartBy = value; } }
        public string UserCode { get { return _UserCode; } set { _UserCode = value; } }
        public string UserFull { get { return _UserFull; } set { _UserFull = value; } }
        public string LocationID { get { return _LocationID; } set { _LocationID = value; } }
        public DateTime createdate { get { return _createdate; } set { _createdate = value; } }
        #endregion  }
    }
}
