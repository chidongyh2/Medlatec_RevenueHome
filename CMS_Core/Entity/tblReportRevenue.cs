using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CMS_Core.Entity
{
    [Serializable]
    public class tblReportRevenue : IValidatableObject
    {
        #region Constructors  

        public tblReportRevenue() { }
        #endregion
        #region Private Fields  
        private string _P_ID;
        private Int64 _MaBN;
        private string _S_ID;
        private string _HoTen;
        private string _GT;
        private string _LocationName;
        private string _GroupName;
        private DateTime _NgayThu;
        private string _UserTC;
        private float _TamThu;
        private float _TongCP;
        private float _PhiDiLai;
        private float _TienMat;
        private float _ThePOS;
        private float _TraTruoc;
        private float _ChKhoan;
        private float _TraSau;
        private float _TienGG;
        private float _ThucThu;
        private float _BHTT;
        private float _BHBLTT;
        private float _TienDiemPID;
        private float _TraKhach;
        private float _CDHA;
        private float _TDCN;
        private float _XN;
        private string _TenGG;
        private string _DC;
        private string _GhiChuTC;
        private string _DichVu;
        private string _TenTinh;
        private string _TenHuyen;
        private string _TheSuDung;
        private bool _agree;
        private string _Commentagree;
        private string _Commentagree1;
        private string _Typeagree;
        private string _Typeagree1;
        private string _Typeagree2;
        private string _Typeagree21;
        private float _SumAgree;
        private string _UserName;
        private string _MaNV;
        private string _useridAgree;
        private int _levelAgree;
        private Int64 _IDSouce;
        private string _NgayThutext;
        private string _LocationID;
        private int _type;
        private string _BankCardSHB;
        private string _BankCardSHBAddress;
        private Int64 _IDCLS;
        private string _pathpdf;
        private string _pathpdf_Sign;
        private bool _typeNotAgree;
        private string _RevenueImages;
        #endregion
        #region Public Properties  
        public string P_ID { get { return _P_ID; } set { _P_ID = value; } }
        public string RevenueImages { get { return _RevenueImages; } set { _RevenueImages = value; } }
        public string pathpdf { get { return _pathpdf; } set { _pathpdf = value; } }
        public string pathpdf_Sign { get { return _pathpdf_Sign; } set { _pathpdf_Sign = value; } }
        public Int64 MaBN { get { return _MaBN; } set { _MaBN = value; } }
        public bool typeNotAgree { get { return _typeNotAgree; } set { _typeNotAgree = value; } }
        public string S_ID { get { return _S_ID; } set { _S_ID = value; } }
        public string useridAgree { get { return _useridAgree; } set { _useridAgree = value; } }
        public string NgayThutext { get { return _NgayThutext; } set { _NgayThutext = value; } }
        public string HoTen { get { return _HoTen; } set { _HoTen = value; } }
        public string GT { get { return _GT; } set { _GT = value; } }
        public string BankCardSHB { get { return _BankCardSHB; } set { _BankCardSHB = value; } }
        public string BankCardSHBAddress { get { return _BankCardSHBAddress; } set { _BankCardSHBAddress = value; } }

        public int levelAgree { get { return _levelAgree; } set { _levelAgree = value; } }
        public int type { get { return _type; } set { _type = value; } }
        public Int64 IDSouce { get { return _IDSouce; } set { _IDSouce = value; } }
        public Int64 IDCLS { get { return _IDCLS; } set { _IDCLS = value; } }
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        public string LocationID { get { return _LocationID; } set { _LocationID = value; } }
        public string GroupName { get { return _GroupName; } set { _GroupName = value; } }
        public DateTime NgayThu { get { return _NgayThu; } set { _NgayThu = value; } }
        public string UserTC { get { return _UserTC; } set { _UserTC = value; } }
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        public string MaNV { get { return _MaNV; } set { _MaNV = value; } }
        public float TamThu { get { return _TamThu; } set { _TamThu = value; } }
        public float TongCP { get { return _TongCP; } set { _TongCP = value; } }
        public float PhiDiLai { get { return _PhiDiLai; } set { _PhiDiLai = value; } }
        public float TienMat { get { return _TienMat; } set { _TienMat = value; } }
        public float ThePOS { get { return _ThePOS; } set { _ThePOS = value; } }
        public float TraTruoc { get { return _TraTruoc; } set { _TraTruoc = value; } }
        public float ChKhoan { get { return _ChKhoan; } set { _ChKhoan = value; } }
        public float TraSau { get { return _TraSau; } set { _TraSau = value; } }
        public float TienGG { get { return _TienGG; } set { _TienGG = value; } }
        public float ThucThu { get { return _ThucThu; } set { _ThucThu = value; } }
        public float BHTT { get { return _BHTT; } set { _BHTT = value; } }
        public float BHBLTT { get { return _BHBLTT; } set { _BHBLTT = value; } }        
        public float TienDiemPID { get { return _TienDiemPID; } set { _TienDiemPID = value; } }
        public float TraKhach { get { return _TraKhach; } set { _TraKhach = value; } }
        public float CDHA { get { return _CDHA; } set { _CDHA = value; } }
        public float TDCN { get { return _TDCN; } set { _TDCN = value; } }
        public float XN { get { return _XN; } set { _XN = value; } }
        public string TenGG { get { return _TenGG; } set { _TenGG = value; } }
        public string DC { get { return _DC; } set { _DC = value; } }
        public string GhiChuTC { get { return _GhiChuTC; } set { _GhiChuTC = value; } }
        public string DichVu { get { return _DichVu; } set { _DichVu = value; } }
        public string TenTinh { get { return _TenTinh; } set { _TenTinh = value; } }
        public string TenHuyen { get { return _TenHuyen; } set { _TenHuyen = value; } }
        public string TheSuDung { get { return _TheSuDung; } set { _TheSuDung = value; } }

        public bool agree { get { return _agree; } set { _agree = value; } }
        public string Typeagree { get { return _Typeagree; } set { _Typeagree = value; } }
        public string Typeagree1 { get { return _Typeagree1; } set { _Typeagree1 = value; } }
        public string Typeagree2 { get { return _Typeagree2; } set { _Typeagree2 = value; } }
        public string Typeagree21 { get { return _Typeagree21; } set { _Typeagree21 = value; } }
        public string Commentagree { get { return _Commentagree; } set { _Commentagree = value; } }
        public string Commentagree1 { get { return _Commentagree1; } set { _Commentagree1 = value; } }
        public float SumAgree { get { return _SumAgree; } set { _SumAgree = value; } }

        
        public HttpPostedFileBase ImageFile { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.UserTC))
            {
                results.Add(new ValidationResult("Không có thông tin user cán bộ tại nhà"));
            }

            if (string.IsNullOrWhiteSpace(this.S_ID))
            {
                results.Add(new ValidationResult("Không có thông tin sid "));
            }

           if(this.TongCP <= 0)
            {
                results.Add(new ValidationResult("Tổng chi phí không thể nhỏ hơn 0! "));
            }

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
        #endregion 

    }

}
