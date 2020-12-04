using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class VP
    {
        #region Constructors  
        public VP() { }
        #endregion
        #region Private Fields  
        private int _IDVP;
        private int _MaBN;
        private string _MaNhCP;
        private int _IDPh;
        private int _IDCT;
        private string _MaCP;
        private string _TenCP;
        private DateTime _Ngay;
        private string _MaKhoa;
        private string _MaDT;
        private int _IDGoiTTCT;
        private int _IDGoiKSKCT;
        private bool _QuaTC;
        private bool _DaTT;
        private bool _DaThuPT;
        private bool _TTNgTr;
        private bool _TTRV;
        private DateTime _NgayTT;
        private int _CCT;
        private bool _NgGio;
        private bool _TrTuyen;
        private bool _NgoaiDM;
        private double _SL;
        private double _DG;
        private double _DGBH;
        private bool _KgLam;
        private bool _Mien;
        private string _UserEdit;
        private DateTime _NgayEdit;
        private bool _NgTru;
        private bool _TrongPT;
        private bool _TuTh;
        private int _Lock;
        private string _Tab;
        private bool _Del;
        private string _MaHT;
        private int _DMTrTuyen;
        private bool _BHBL;
        private bool _KhongTT;
        private DateTime _TGDuyet;
        private double _KhTT;
        private double _BHTT;
        private double _BHBLTT;
        private double _BHBLDuyet;
        private DateTime _NgayAuto;
        private int _KhoiDoanhThu;
        private string _VP_BSCDThem;
        private string _VP_UserThuThem;
        private DateTime _VP_NgayThuThem;
        private int _VP_LamThem;
        private string _VP_BSTraTien;
        private int _VP_Pending;
        private string _IsBravo;
        private string _IsNoiBo;
        private int _MaGoiCD;
        private int _MaGoiCDCT;
        private bool _BSDuyetBHYT;
        private DateTime _TGDuyetLanDau;
        private string _NguoiDuyetLanDau;
        private string _NguoiDuyet;
        private bool _agree;
        private string _Commentagree;
        private string _Typeagree;
        #endregion
        #region Public Properties  
        public int IDVP { get { return _IDVP; } set { _IDVP = value; } }
        public int MaBN { get { return _MaBN; } set { _MaBN = value; } }
        public string MaNhCP { get { return _MaNhCP; } set { _MaNhCP = value; } }
        public int IDPh { get { return _IDPh; } set { _IDPh = value; } }
        public int IDCT { get { return _IDCT; } set { _IDCT = value; } }
        public string MaCP { get { return _MaCP; } set { _MaCP = value; } }
        public string TenCP { get { return _TenCP; } set { _TenCP = value; } }
        public DateTime Ngay { get { return _Ngay; } set { _Ngay = value; } }
        public string MaKhoa { get { return _MaKhoa; } set { _MaKhoa = value; } }
        public string MaDT { get { return _MaDT; } set { _MaDT = value; } }
        public int IDGoiTTCT { get { return _IDGoiTTCT; } set { _IDGoiTTCT = value; } }
        public int IDGoiKSKCT { get { return _IDGoiKSKCT; } set { _IDGoiKSKCT = value; } }
        public bool QuaTC { get { return _QuaTC; } set { _QuaTC = value; } }
        public bool DaTT { get { return _DaTT; } set { _DaTT = value; } }
        public bool DaThuPT { get { return _DaThuPT; } set { _DaThuPT = value; } }
        public bool TTNgTr { get { return _TTNgTr; } set { _TTNgTr = value; } }
        public bool TTRV { get { return _TTRV; } set { _TTRV = value; } }
        public DateTime NgayTT { get { return _NgayTT; } set { _NgayTT = value; } }
        public int CCT { get { return _CCT; } set { _CCT = value; } }
        public bool NgGio { get { return _NgGio; } set { _NgGio = value; } }
        public bool TrTuyen { get { return _TrTuyen; } set { _TrTuyen = value; } }
        public bool NgoaiDM { get { return _NgoaiDM; } set { _NgoaiDM = value; } }
        public double SL { get { return _SL; } set { _SL = value; } }
        public double DG { get { return _DG; } set { _DG = value; } }
        public double DGBH { get { return _DGBH; } set { _DGBH = value; } }
        public bool KgLam { get { return _KgLam; } set { _KgLam = value; } }
        public bool Mien { get { return _Mien; } set { _Mien = value; } }
        public string UserEdit { get { return _UserEdit; } set { _UserEdit = value; } }
        public DateTime NgayEdit { get { return _NgayEdit; } set { _NgayEdit = value; } }
        public bool NgTru { get { return _NgTru; } set { _NgTru = value; } }
        public bool TrongPT { get { return _TrongPT; } set { _TrongPT = value; } }
        public bool TuTh { get { return _TuTh; } set { _TuTh = value; } }
        public int Lock { get { return _Lock; } set { _Lock = value; } }
        public string Tab { get { return _Tab; } set { _Tab = value; } }
        public bool Del { get { return _Del; } set { _Del = value; } }
        public string MaHT { get { return _MaHT; } set { _MaHT = value; } }
        public int DMTrTuyen { get { return _DMTrTuyen; } set { _DMTrTuyen = value; } }
        public bool BHBL { get { return _BHBL; } set { _BHBL = value; } }
        public bool KhongTT { get { return _KhongTT; } set { _KhongTT = value; } }
        public DateTime TGDuyet { get { return _TGDuyet; } set { _TGDuyet = value; } }
        public double KhTT { get { return _KhTT; } set { _KhTT = value; } }
        public double BHTT { get { return _BHTT; } set { _BHTT = value; } }
        public double BHBLTT { get { return _BHBLTT; } set { _BHBLTT = value; } }
        public double BHBLDuyet { get { return _BHBLDuyet; } set { _BHBLDuyet = value; } }
        public DateTime NgayAuto { get { return _NgayAuto; } set { _NgayAuto = value; } }
        public int KhoiDoanhThu { get { return _KhoiDoanhThu; } set { _KhoiDoanhThu = value; } }
        public string VP_BSCDThem { get { return _VP_BSCDThem; } set { _VP_BSCDThem = value; } }
        public string VP_UserThuThem { get { return _VP_UserThuThem; } set { _VP_UserThuThem = value; } }
        public DateTime VP_NgayThuThem { get { return _VP_NgayThuThem; } set { _VP_NgayThuThem = value; } }
        public int VP_LamThem { get { return _VP_LamThem; } set { _VP_LamThem = value; } }
        public string VP_BSTraTien { get { return _VP_BSTraTien; } set { _VP_BSTraTien = value; } }
        public int VP_Pending { get { return _VP_Pending; } set { _VP_Pending = value; } }
        public string IsBravo { get { return _IsBravo; } set { _IsBravo = value; } }
        public string IsNoiBo { get { return _IsNoiBo; } set { _IsNoiBo = value; } }
        public int MaGoiCD { get { return _MaGoiCD; } set { _MaGoiCD = value; } }
        public int MaGoiCDCT { get { return _MaGoiCDCT; } set { _MaGoiCDCT = value; } }
        public bool BSDuyetBHYT { get { return _BSDuyetBHYT; } set { _BSDuyetBHYT = value; } }
        public DateTime TGDuyetLanDau { get { return _TGDuyetLanDau; } set { _TGDuyetLanDau = value; } }
        public string NguoiDuyetLanDau { get { return _NguoiDuyetLanDau; } set { _NguoiDuyetLanDau = value; } }
        public string NguoiDuyet { get { return _NguoiDuyet; } set { _NguoiDuyet = value; } }
        public bool agree { get { return _agree; } set { _agree = value; } }
        public string Typeagree { get { return _Typeagree; } set { _Typeagree = value; } }
        public string Commentagree { get { return _Commentagree; } set { _Commentagree = value; } }
        #endregion  }
    }
}
