using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class tbl_Patient : IValidatableObject
    {
        #region Constructors  
        public tbl_Patient() { }
        #endregion
        #region Private Fields  
        private string _SID;
        private string _PatientName;
        private string _Seq;
        private DateTime _Intime;
        private DateTime _DateIN;
        private string _Sex;
        private string _DoctorID;
        private string _LocationID;
        private string _ObjectID;
        private string _Diagnostic;
        private int _Age;
        private bool _PrintOut;
        private bool _FullResult;
        private bool _ReturnResult;
        private DateTime _PrintTime;
        private string _PID;
        private string _UserI;
        private int _AutoID;
        private string _Invoice;
        private string _Address;
        private string _Status;
        private string _UserD;
        private DateTime _UpdateTime;
        private string _Comment;
        private bool _Valid;
        private string _Bed;
        private string _OrderID;
        private DateTime _InvoiceTime;
        private string _UserInvoice;
        private DateTime _GettestTime;
        private string _Usergettest;
        private float _SumMoney;
        private float _SumAgree;
        private float _SumPerTage;
        private float _SumTransport;
        private string _InsuranNo;
        private string _InsuranName;
        private string _Iden;
        private string _InsuranID;
        private DateTime _ReturnTime;
        private string _GID;
        private string _Phone;
        private bool _NotPrint;
        private bool _NotPrintMoney;
        private string _Sonha;
        private string _Hem;
        private string _Ngach;
        private string _Ngo;
        private string _Street;
        private string _Precinct;
        private string _District;
        private string _City;
        private bool _ShowWeb;
        private string _SubComment;
        private DateTime _ValidTime;
        private object _rowguid;
        private bool _ValidHL;
        private string _UserHL;
        private DateTime _ValidTimeHL;
        private bool _EmailResult;
        private float _PaidByCard;
        private float _PaidInCash;
        private string _EmailAddress;
        private bool _SendResult;
        private int _ResultRate;
        private bool _dept;
        private DateTime _taikham;
        private bool _trangthai;
        private DateTime _tuvan;
        private float _DefineMoneyDoctor;
        private float _pos;
        private int _random;
        private string _userC;
        private bool _Download;
        private string _UserCheck;
        private string _UserValid2;
        private bool _DownloadAMS;
        private bool _DownloadInf;
        private bool _SpecialPatient;
        private bool _TVThalas;
        private int _BloodPressureH;
        private int _BloodPressureL;
        private int _ReturnType;
        private bool _agree;
        private string _Commentagree;
        private string _Typeagree;
        private string _LocationName;
        private string _Locationid1;
        #endregion
        #region Public Properties  
        
        public string SID { get { return _SID; } set { _SID = value; } }
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        public string Locationid1 { get { return _Locationid1; } set { _Locationid1 = value; } }
        public bool agree { get { return _agree; } set { _agree = value; } }
        public string Typeagree { get { return _Typeagree; } set { _Typeagree = value; } }
        public string Commentagree { get { return _Commentagree; } set { _Commentagree = value; } }
        public string PatientName { get { return _PatientName; } set { _PatientName = value; } }
        public string Seq { get { return _Seq; } set { _Seq = value; } }
        public DateTime Intime { get { return _Intime; } set { _Intime = value; } }
        public DateTime DateIN { get { return _DateIN; } set { _DateIN = value; } }
        public string Sex { get { return _Sex; } set { _Sex = value; } }
        public string DoctorID { get { return _DoctorID; } set { _DoctorID = value; } }
        public string LocationID { get { return _LocationID; } set { _LocationID = value; } }
        public string ObjectID { get { return _ObjectID; } set { _ObjectID = value; } }
        public string Diagnostic { get { return _Diagnostic; } set { _Diagnostic = value; } }
        public int Age { get { return _Age; } set { _Age = value; } }
        public bool PrintOut { get { return _PrintOut; } set { _PrintOut = value; } }
        public bool FullResult { get { return _FullResult; } set { _FullResult = value; } }
        public bool ReturnResult { get { return _ReturnResult; } set { _ReturnResult = value; } }
        public DateTime PrintTime { get { return _PrintTime; } set { _PrintTime = value; } }
        public string PID { get { return _PID; } set { _PID = value; } }
        public string UserI { get { return _UserI; } set { _UserI = value; } }
        public int AutoID { get { return _AutoID; } set { _AutoID = value; } }
        public string Invoice { get { return _Invoice; } set { _Invoice = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string Status { get { return _Status; } set { _Status = value; } }
        public string UserD { get { return _UserD; } set { _UserD = value; } }
        public DateTime UpdateTime { get { return _UpdateTime; } set { _UpdateTime = value; } }
        public string Comment { get { return _Comment; } set { _Comment = value; } }
        public bool Valid { get { return _Valid; } set { _Valid = value; } }
        public string Bed { get { return _Bed; } set { _Bed = value; } }
        public string OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public DateTime InvoiceTime { get { return _InvoiceTime; } set { _InvoiceTime = value; } }
        public string UserInvoice { get { return _UserInvoice; } set { _UserInvoice = value; } }
        public DateTime GettestTime { get { return _GettestTime; } set { _GettestTime = value; } }
        public string Usergettest { get { return _Usergettest; } set { _Usergettest = value; } }
        public float SumMoney { get { return _SumMoney; } set { _SumMoney = value; } }
        public float SumAgree { get { return _SumAgree; } set { _SumAgree = value; } }
        public float SumPerTage { get { return _SumPerTage; } set { _SumPerTage = value; } }
        public float SumTransport { get { return _SumTransport; } set { _SumTransport = value; } }
        public string InsuranNo { get { return _InsuranNo; } set { _InsuranNo = value; } }
        public string InsuranName { get { return _InsuranName; } set { _InsuranName = value; } }
        public string Iden { get { return _Iden; } set { _Iden = value; } }
        public string InsuranID { get { return _InsuranID; } set { _InsuranID = value; } }
        public DateTime ReturnTime { get { return _ReturnTime; } set { _ReturnTime = value; } }
        public string GID { get { return _GID; } set { _GID = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public bool NotPrint { get { return _NotPrint; } set { _NotPrint = value; } }
        public bool NotPrintMoney { get { return _NotPrintMoney; } set { _NotPrintMoney = value; } }
        public string Sonha { get { return _Sonha; } set { _Sonha = value; } }
        public string Hem { get { return _Hem; } set { _Hem = value; } }
        public string Ngach { get { return _Ngach; } set { _Ngach = value; } }
        public string Ngo { get { return _Ngo; } set { _Ngo = value; } }
        public string Street { get { return _Street; } set { _Street = value; } }
        public string Precinct { get { return _Precinct; } set { _Precinct = value; } }
        public string District { get { return _District; } set { _District = value; } }
        public string City { get { return _City; } set { _City = value; } }
        public bool ShowWeb { get { return _ShowWeb; } set { _ShowWeb = value; } }
        public string SubComment { get { return _SubComment; } set { _SubComment = value; } }
        public DateTime ValidTime { get { return _ValidTime; } set { _ValidTime = value; } }
        public object rowguid { get { return _rowguid; } set { _rowguid = value; } }
        public bool ValidHL { get { return _ValidHL; } set { _ValidHL = value; } }
        public string UserHL { get { return _UserHL; } set { _UserHL = value; } }
        public DateTime ValidTimeHL { get { return _ValidTimeHL; } set { _ValidTimeHL = value; } }
        public bool EmailResult { get { return _EmailResult; } set { _EmailResult = value; } }
        public float PaidByCard { get { return _PaidByCard; } set { _PaidByCard = value; } }
        public float PaidInCash { get { return _PaidInCash; } set { _PaidInCash = value; } }
        public string EmailAddress { get { return _EmailAddress; } set { _EmailAddress = value; } }
        public bool SendResult { get { return _SendResult; } set { _SendResult = value; } }
        public int ResultRate { get { return _ResultRate; } set { _ResultRate = value; } }
        public bool dept { get { return _dept; } set { _dept = value; } }
        public DateTime taikham { get { return _taikham; } set { _taikham = value; } }
        public bool trangthai { get { return _trangthai; } set { _trangthai = value; } }
        public DateTime tuvan { get { return _tuvan; } set { _tuvan = value; } }
        public float DefineMoneyDoctor { get { return _DefineMoneyDoctor; } set { _DefineMoneyDoctor = value; } }
        public float pos { get { return _pos; } set { _pos = value; } }
        public int random { get { return _random; } set { _random = value; } }
        public string userC { get { return _userC; } set { _userC = value; } }
        public bool Download { get { return _Download; } set { _Download = value; } }
        public string UserCheck { get { return _UserCheck; } set { _UserCheck = value; } }
        public string UserValid2 { get { return _UserValid2; } set { _UserValid2 = value; } }
        public bool DownloadAMS { get { return _DownloadAMS; } set { _DownloadAMS = value; } }
        public bool DownloadInf { get { return _DownloadInf; } set { _DownloadInf = value; } }
        public bool SpecialPatient { get { return _SpecialPatient; } set { _SpecialPatient = value; } }
        public bool TVThalas { get { return _TVThalas; } set { _TVThalas = value; } }
        public int BloodPressureH { get { return _BloodPressureH; } set { _BloodPressureH = value; } }
        public int BloodPressureL { get { return _BloodPressureL; } set { _BloodPressureL = value; } }
        public int ReturnType { get { return _ReturnType; } set { _ReturnType = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if(!this.agree )
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
            
            if(this.SumPerTage > 100)
            {
                results.Add(new ValidationResult("Tỷ lệ giảm giá không được quá 100%"));
            }

            return results;
        }
        #endregion  }
    }
}
