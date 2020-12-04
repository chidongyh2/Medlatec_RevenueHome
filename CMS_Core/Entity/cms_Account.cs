using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Account : IValidatableObject
    {
        #region Constructors  
        public cms_Account() { }
        #endregion
        #region Private Fields  
        private int _uid;
        private string _Username;
        private string _Password;
        private string _Email;
        private bool _IsFirstLogin;
        private DateTime _LastLogin;
        private int _AccountTypeId;
        private string _Hoten;
        private string _Mobile;
        private string _Ghichu;
        private DateTime _Ngaysinh;
        private string _GT;
        private bool _Dakh;
        private string _Sothich;
        private string _CNYT;
        private string _Fb;
        private string _instagram;
        private string _Manv;
        private string _Checkmail;
        private string _Nhanmail;
        private string _img;
        private int _status;
        private string _NgaysinhText;

        private int _PARTNERID;

        private int _CreateBy;
        private DateTime _Create_date;
        private int _UpdateBy;
        private DateTime _Update_date;
        private string _GroupName;
        private string _AccountLis;

        #endregion
        #region Public Properties  
        public int uid { get { return _uid; } set { _uid = value; } }
        public int PARTNERID { get { return _PARTNERID; } set { _PARTNERID = value; } }
        public string Username { get { return _Username; } set { _Username = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public bool IsFirstLogin { get { return _IsFirstLogin; } set { _IsFirstLogin = value; } }
        public DateTime LastLogin { get { return _LastLogin; } set { _LastLogin = value; } }
        public int AccountTypeId { get { return _AccountTypeId; } set { _AccountTypeId = value; } }
        public string Hoten { get { return _Hoten; } set { _Hoten = value; } }
        public string Mobile { get { return _Mobile; } set { _Mobile = value; } }
        public string Ghichu { get { return _Ghichu; } set { _Ghichu = value; } }
        public string AccountLis { get { return _AccountLis; } set { _AccountLis = value; } }
        

        public DateTime Ngaysinh { get { return _Ngaysinh; } set { _Ngaysinh = value; _NgaysinhText = _Ngaysinh.ToString("dd/MM/yyyy"); } }


        public string GT { get { return _GT; } set { _GT = value; } }
        public bool Dakh { get { return _Dakh; } set { _Dakh = value; } }
        public string Sothich { get { return _Sothich; } set { _Sothich = value; } }
        public string CNYT { get { return _CNYT; } set { _CNYT = value; } }
        public string Fb { get { return _Fb; } set { _Fb = value; } }
        public string instagram { get { return _instagram; } set { _instagram = value; } }
        public string Manv { get { return _Manv; } set { _Manv = value; } }
        public string Checkmail { get { return _Checkmail; } set { _Checkmail = value; } }
        public string Nhanmail { get { return _Nhanmail; } set { _Nhanmail = value; } }
        public string img { get { return _img; } set { _img = value; } }
        public string NgaysinhText { get { return _NgaysinhText; } set { _NgaysinhText = value; } }
        public int status { get { return _status; } set { _status = value; } }

        public string GroupName { get { return _GroupName; } set { _GroupName = value; } }

        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime Create_date { get { return _Create_date; } set { _Create_date = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime Update_date { get { return _Update_date; } set { _Update_date = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Username))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào Username"));
            }
            else if (this.Username.Length > 200)
            {
                results.Add(new ValidationResult("Username lớn hơn 200 ký tự"));
            }
            else if (this.Username.IndexOf(" ") != -1)
            {
                results.Add(new ValidationResult("Username không có ký tự trống"));
            }
            else if (Common.Common.ContainsUnicodeCharacter(this.Username))
            {
                results.Add(new ValidationResult("Username chứa ký tự không phải unicode"));
            }
            else if (Common.Common.hasSpecialChar(this.Username))
            {
                results.Add(new ValidationResult("Username có ký tự đặc biệt"));
            }


            if (!string.IsNullOrEmpty(this.Password))
            {
                if (this.Password.Length > 300)
                {
                    results.Add(new ValidationResult("Password không được dài quá 300 ký tự"));
                }

                //if (this.Password.Length < 6)
                //{
                //    results.Add(new ValidationResult("Password không được ngắn quá 6 ký tự"));
                //}

            }

            if (!string.IsNullOrEmpty(this.Email))
            {
                if (this.Email.Length > 100)
                {
                    results.Add(new ValidationResult("Email không được dài quá 100 ký tự"));
                }
            }else
            {
                results.Add(new ValidationResult("Mời bạn nhập vào email"));
            }

            if (string.IsNullOrWhiteSpace(this.Hoten))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào Hoten"));
            }
            else if (this.Hoten.Length > 200)
            {
                results.Add(new ValidationResult("Hoten lớn hơn 200 ký tự"));
            }
            else if (Common.Common.hasSpecialChar(this.Hoten))
            {
                results.Add(new ValidationResult("Họ tên có ký tự đặc biệt"));
            }

            if (!string.IsNullOrEmpty(this.Mobile))
            {
                if (this.Mobile.Length > 20)
                {
                    results.Add(new ValidationResult("Mobile không được dài quá 20 ký tự"));
                }
            }else
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mobile"));
            }

            if (!string.IsNullOrEmpty(this.Ghichu))
            {
                if (this.Ghichu.Length > 250)
                {
                    results.Add(new ValidationResult("Ghi chú không được dài quá 250 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.AccountLis))
            {
                if (this.AccountLis.Length > 100)
                {
                    results.Add(new ValidationResult("Account List không được dài quá 100 ký tự"));
                }
            }


            if (this.AccountTypeId == 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn nhóm account"));
            }


            return results;
        }
        #endregion  }
    }
}
