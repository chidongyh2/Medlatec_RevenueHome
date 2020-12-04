using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class tbl_Result : IValidatableObject
    {
        #region Constructors  
        public tbl_Result() { }
        #endregion
        #region Private Fields  
        private int _AutoID;
        private string _SID;
        private string _Testcode;
        private string _Result;
        private string _Posneg;
        private string _Unit;
        private float _Price;
        private string _TestName;
        private string _NormalRange;
        private string _NormalRangeF;
        private int _PrintOrder;
        private bool _TestHead;
        private string _Category;
        private float _LowerLimit;
        private float _HigherLimit;
        private bool _Profile;
        private string _UserI;
        private string _UserU;
        private string _UserD;
        private DateTime _Updatetime;
        private bool _Download;
        private DateTime _Intime;
        private bool _Bold;
        private string _Invoice;
        private string _Status;
        private int _STS;
        private int _STSLH;
        private float _Cost;
        private string _Comment;
        private int _Color;
        private string _Criteria;
        private string _Type;
        private string _UserV;
        private string _TestCodeHIS;
        private string _OrderID;
        private int _Rerun;
        private int _InsIDN;
        private string _BLLower;
        private string _BLHigher;
        private string _TestNameE;
        private string _BLLowerE;
        private string _BLHigherE;
        private string _CommentE;
        private string _ResultText;
        private bool _RT;
        private bool _SendTest;
        private bool _ShowTestResult;
        private int _ResultType;
        private string _DiagnosticResult;
        private string _Conclusion;
        private object _IMG1;
        private string _IMGComment1;
        private object _IMG2;
        private string _IMGComment2;
        private object _IMG3;
        private string _IMGComment3;
        private object _IMG4;
        private string _IMGComment4;
        private object _IMG5;
        private string _IMGComment5;
        private string _UserUpd;
        private DateTime _TimeUpd;
        private string _Doctorcomment;
        private object _rowguid;
        private bool _ResultRateDetail;
        private string _ProfileID;
        private bool _Arising;
        private bool _CheckDel;
        private string _ResultMoM;
        private DateTime _Valid1Time;
        private int _InsDownload;
        private bool _Scan1;
        private bool _Scan2;
        private bool _Scan3;
        private bool _Scan4;
        private bool _Pending;
        private bool _NgoaiHD;
        private float _Cost2;
        private string _DoctorID2;
        private bool _Paid;
        private DateTime _InvoiceTime;
        private string _InLocationID;
        private bool _IsSYNC;
        private bool _agree;
        private string _Commentagree;
        private string _Typeagree;
        private string _LocationName;
        private string _Locationid;
        #endregion
        #region Public Properties  
        public int AutoID { get { return _AutoID; } set { _AutoID = value; } }
        public bool agree { get { return _agree; } set { _agree = value; } }
        public string Typeagree { get { return _Typeagree; } set { _Typeagree = value; } }
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        public string Locationid { get { return _Locationid; } set { _Locationid = value; } }
        public string Commentagree { get { return _Commentagree; } set { _Commentagree = value; } }
        public string SID { get { return _SID; } set { _SID = value; } }
        public string Testcode { get { return _Testcode; } set { _Testcode = value; } }
        public string Result { get { return _Result; } set { _Result = value; } }
        public string Posneg { get { return _Posneg; } set { _Posneg = value; } }
        public string Unit { get { return _Unit; } set { _Unit = value; } }
        public float Price { get { return _Price; } set { _Price = value; } }
        public string TestName { get { return _TestName; } set { _TestName = value; } }
        public string NormalRange { get { return _NormalRange; } set { _NormalRange = value; } }
        public string NormalRangeF { get { return _NormalRangeF; } set { _NormalRangeF = value; } }
        public int PrintOrder { get { return _PrintOrder; } set { _PrintOrder = value; } }
        public bool TestHead { get { return _TestHead; } set { _TestHead = value; } }
        public string Category { get { return _Category; } set { _Category = value; } }
        public float LowerLimit { get { return _LowerLimit; } set { _LowerLimit = value; } }
        public float HigherLimit { get { return _HigherLimit; } set { _HigherLimit = value; } }
        public bool Profile { get { return _Profile; } set { _Profile = value; } }
        public string UserI { get { return _UserI; } set { _UserI = value; } }
        public string UserU { get { return _UserU; } set { _UserU = value; } }
        public string UserD { get { return _UserD; } set { _UserD = value; } }
        public DateTime Updatetime { get { return _Updatetime; } set { _Updatetime = value; } }
        public bool Download { get { return _Download; } set { _Download = value; } }
        public DateTime Intime { get { return _Intime; } set { _Intime = value; } }
        public bool Bold { get { return _Bold; } set { _Bold = value; } }
        public string Invoice { get { return _Invoice; } set { _Invoice = value; } }
        public string Status { get { return _Status; } set { _Status = value; } }
        public int STS { get { return _STS; } set { _STS = value; } }
        public int STSLH { get { return _STSLH; } set { _STSLH = value; } }
        public float Cost { get { return _Cost; } set { _Cost = value; } }
        public string Comment { get { return _Comment; } set { _Comment = value; } }
        public int Color { get { return _Color; } set { _Color = value; } }
        public string Criteria { get { return _Criteria; } set { _Criteria = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }
        public string UserV { get { return _UserV; } set { _UserV = value; } }
        public string TestCodeHIS { get { return _TestCodeHIS; } set { _TestCodeHIS = value; } }
        public string OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public int Rerun { get { return _Rerun; } set { _Rerun = value; } }
        public int InsIDN { get { return _InsIDN; } set { _InsIDN = value; } }
        public string BLLower { get { return _BLLower; } set { _BLLower = value; } }
        public string BLHigher { get { return _BLHigher; } set { _BLHigher = value; } }
        public string TestNameE { get { return _TestNameE; } set { _TestNameE = value; } }
        public string BLLowerE { get { return _BLLowerE; } set { _BLLowerE = value; } }
        public string BLHigherE { get { return _BLHigherE; } set { _BLHigherE = value; } }
        public string CommentE { get { return _CommentE; } set { _CommentE = value; } }
        public string ResultText { get { return _ResultText; } set { _ResultText = value; } }
        public bool RT { get { return _RT; } set { _RT = value; } }
        public bool SendTest { get { return _SendTest; } set { _SendTest = value; } }
        public bool ShowTestResult { get { return _ShowTestResult; } set { _ShowTestResult = value; } }
        public int ResultType { get { return _ResultType; } set { _ResultType = value; } }
        public string DiagnosticResult { get { return _DiagnosticResult; } set { _DiagnosticResult = value; } }
        public string Conclusion { get { return _Conclusion; } set { _Conclusion = value; } }
        public object IMG1 { get { return _IMG1; } set { _IMG1 = value; } }
        public string IMGComment1 { get { return _IMGComment1; } set { _IMGComment1 = value; } }
        public object IMG2 { get { return _IMG2; } set { _IMG2 = value; } }
        public string IMGComment2 { get { return _IMGComment2; } set { _IMGComment2 = value; } }
        public object IMG3 { get { return _IMG3; } set { _IMG3 = value; } }
        public string IMGComment3 { get { return _IMGComment3; } set { _IMGComment3 = value; } }
        public object IMG4 { get { return _IMG4; } set { _IMG4 = value; } }
        public string IMGComment4 { get { return _IMGComment4; } set { _IMGComment4 = value; } }
        public object IMG5 { get { return _IMG5; } set { _IMG5 = value; } }
        public string IMGComment5 { get { return _IMGComment5; } set { _IMGComment5 = value; } }
        public string UserUpd { get { return _UserUpd; } set { _UserUpd = value; } }
        public DateTime TimeUpd { get { return _TimeUpd; } set { _TimeUpd = value; } }
        public string Doctorcomment { get { return _Doctorcomment; } set { _Doctorcomment = value; } }
        public object rowguid { get { return _rowguid; } set { _rowguid = value; } }
        public bool ResultRateDetail { get { return _ResultRateDetail; } set { _ResultRateDetail = value; } }
        public string ProfileID { get { return _ProfileID; } set { _ProfileID = value; } }
        public bool Arising { get { return _Arising; } set { _Arising = value; } }
        public bool CheckDel { get { return _CheckDel; } set { _CheckDel = value; } }
        public string ResultMoM { get { return _ResultMoM; } set { _ResultMoM = value; } }
        public DateTime Valid1Time { get { return _Valid1Time; } set { _Valid1Time = value; } }
        public int InsDownload { get { return _InsDownload; } set { _InsDownload = value; } }
        public bool Scan1 { get { return _Scan1; } set { _Scan1 = value; } }
        public bool Scan2 { get { return _Scan2; } set { _Scan2 = value; } }
        public bool Scan3 { get { return _Scan3; } set { _Scan3 = value; } }
        public bool Scan4 { get { return _Scan4; } set { _Scan4 = value; } }
        public bool Pending { get { return _Pending; } set { _Pending = value; } }
        public bool NgoaiHD { get { return _NgoaiHD; } set { _NgoaiHD = value; } }
        public float Cost2 { get { return _Cost2; } set { _Cost2 = value; } }
        public string DoctorID2 { get { return _DoctorID2; } set { _DoctorID2 = value; } }
        public bool Paid { get { return _Paid; } set { _Paid = value; } }
        public DateTime InvoiceTime { get { return _InvoiceTime; } set { _InvoiceTime = value; } }
        public string InLocationID { get { return _InLocationID; } set { _InLocationID = value; } }
        public bool IsSYNC { get { return _IsSYNC; } set { _IsSYNC = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (!this.agree)
            {
                if (string.IsNullOrWhiteSpace(this.Commentagree))
                {
                    results.Add(new ValidationResult("Mời bạn nhập nội dung từ chối!"));
                }
                else if (this.Commentagree.Length > 200)
                {
                    results.Add(new ValidationResult("Nội dung từ chối quá 200 ký tự"));
                }
            }

          

            return results;
        }
        #endregion  }
    }
}
