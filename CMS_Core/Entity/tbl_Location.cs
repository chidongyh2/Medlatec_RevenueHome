using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class tbl_Location
    {
        #region Constructors  
        public tbl_Location() { }
        #endregion
        #region Private Fields  
        private string _LocationID;
        private string _LocationName;
        private string _LocationNameE;
        private string _Location_L2;
        private int _StartBy;
        private object _rowguid;
        private string _LocationHIS;
        private string _LocationGroup;
        private bool _IsAdvisory;
        private bool _SendTest;
        private bool _SendSMSEmail;
        private string _Address;
        private bool _IsKSK;
        private string _LocationName2;
        private bool _isActive;
        private string _codeTN;
        private string _TNName;

        #endregion
        #region Public Properties  

        public string codeTN { get { return _codeTN; } set { _codeTN = value; } }

        public string TNName { get { return _TNName; } set { _TNName = value; } }
        public string LocationID { get { return _LocationID; } set { _LocationID = value; } }
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        public string LocationNameE { get { return _LocationNameE; } set { _LocationNameE = value; } }
        public string Location_L2 { get { return _Location_L2; } set { _Location_L2 = value; } }
        public int StartBy { get { return _StartBy; } set { _StartBy = value; } }
        public object rowguid { get { return _rowguid; } set { _rowguid = value; } }
        public string LocationHIS { get { return _LocationHIS; } set { _LocationHIS = value; } }
        public string LocationGroup { get { return _LocationGroup; } set { _LocationGroup = value; } }
        public bool IsAdvisory { get { return _IsAdvisory; } set { _IsAdvisory = value; } }
        public bool SendTest { get { return _SendTest; } set { _SendTest = value; } }
        public bool SendSMSEmail { get { return _SendSMSEmail; } set { _SendSMSEmail = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public bool IsKSK { get { return _IsKSK; } set { _IsKSK = value; } }
        public string LocationName2 { get { return _LocationName2; } set { _LocationName2 = value; } }
        public bool isActive { get { return _isActive; } set { _isActive = value; } }
        #endregion  }
    }
}
