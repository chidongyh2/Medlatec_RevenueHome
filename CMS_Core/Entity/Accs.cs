using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class Accs
    {
        #region Constructors  
        public Accs() { }
        #endregion
        #region Private Fields  
        private string _IDAcc;
        private string _Pwd;
        private string _HoTen;
        private bool _Admin;
        private bool _Enb;
        private string _MaKhoa;
        private string _MaNV;
        private string _MaBS;
        private string _IDAccNew;
        private string _IDTam;
        private string _MaDV;
        private int _IsLab;
        private string _MaGenThe;
        private string _UserLC;
        private string _UserLab;
        private DateTime _NgayAuto;
        private string _MaTaiNha;
        private int _IsTongDai;
        private string _Phone;
        private string _UserKSK;
        private string _MaPhong;
        private bool _IsDieuDuong;
        private int _IndexCheck;
        private string _Pass;
        private DateTime _LastLogin;
        private string _IDKSK;
        private int _XoaOFFKSK;
        private string _MaDonVi;
        private int _IDKey;
        private string _UserMapKSK;
        private string _NoteAcc;
        private string _EmailAddress;
        private int _ChucDanh;
        private string _Type;
        #endregion
        #region Public Properties  
        public string IDAcc { get { return _IDAcc; } set { _IDAcc = value; } }
        public string Pwd { get { return _Pwd; } set { _Pwd = value; } }
        public string HoTen { get { return _HoTen; } set { _HoTen = value; } }
        public bool Admin { get { return _Admin; } set { _Admin = value; } }
        public bool Enb { get { return _Enb; } set { _Enb = value; } }
        public string MaKhoa { get { return _MaKhoa; } set { _MaKhoa = value; } }
        public string MaNV { get { return _MaNV; } set { _MaNV = value; } }
        public string MaBS { get { return _MaBS; } set { _MaBS = value; } }
        public string IDAccNew { get { return _IDAccNew; } set { _IDAccNew = value; } }
        public string IDTam { get { return _IDTam; } set { _IDTam = value; } }
        public string MaDV { get { return _MaDV; } set { _MaDV = value; } }
        public int IsLab { get { return _IsLab; } set { _IsLab = value; } }
        public string MaGenThe { get { return _MaGenThe; } set { _MaGenThe = value; } }
        public string UserLC { get { return _UserLC; } set { _UserLC = value; } }
        public string UserLab { get { return _UserLab; } set { _UserLab = value; } }
        public DateTime NgayAuto { get { return _NgayAuto; } set { _NgayAuto = value; } }
        public string MaTaiNha { get { return _MaTaiNha; } set { _MaTaiNha = value; } }
        public int IsTongDai { get { return _IsTongDai; } set { _IsTongDai = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string UserKSK { get { return _UserKSK; } set { _UserKSK = value; } }
        public string MaPhong { get { return _MaPhong; } set { _MaPhong = value; } }
        public bool IsDieuDuong { get { return _IsDieuDuong; } set { _IsDieuDuong = value; } }
        public int IndexCheck { get { return _IndexCheck; } set { _IndexCheck = value; } }
        public string Pass { get { return _Pass; } set { _Pass = value; } }
        public DateTime LastLogin { get { return _LastLogin; } set { _LastLogin = value; } }
        public string IDKSK { get { return _IDKSK; } set { _IDKSK = value; } }
        public int XoaOFFKSK { get { return _XoaOFFKSK; } set { _XoaOFFKSK = value; } }
        public string MaDonVi { get { return _MaDonVi; } set { _MaDonVi = value; } }
        public int IDKey { get { return _IDKey; } set { _IDKey = value; } }
        public string UserMapKSK { get { return _UserMapKSK; } set { _UserMapKSK = value; } }
        public string NoteAcc { get { return _NoteAcc; } set { _NoteAcc = value; } }
        public string EmailAddress { get { return _EmailAddress; } set { _EmailAddress = value; } }
        public int ChucDanh { get { return _ChucDanh; } set { _ChucDanh = value; } }
        public string Type { get { return _Type; } set { _Type = value; } }
        #endregion  }
    }
}