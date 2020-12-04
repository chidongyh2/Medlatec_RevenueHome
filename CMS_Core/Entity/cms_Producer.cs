using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class cms_Producer : IValidatableObject
    {
        #region Constructors  
        public cms_Producer() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private string _MANSX;
        private string _TENNSX;
        private string _DIACHI;
        private string _SODT;
        private string _SOFAX;
        private string _EMAIL;
        private string _WEBSITE;
        private string _SANPHAM;
        private int _Status;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private float _ProducerPayTotal;
        private float _ProducerDebtTotal;

        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public string MANSX { get { return _MANSX; } set { _MANSX = value; } }
        public string TENNSX { get { return _TENNSX; } set { _TENNSX = value; } }
        public string DIACHI { get { return _DIACHI; } set { _DIACHI = value; } }
        public string SODT { get { return _SODT; } set { _SODT = value; } }
        public string SOFAX { get { return _SOFAX; } set { _SOFAX = value; } }
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; } }
        public string WEBSITE { get { return _WEBSITE; } set { _WEBSITE = value; } }
        public string SANPHAM { get { return _SANPHAM; } set { _SANPHAM = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public float ProducerPayTotal { get { return _ProducerPayTotal; } set { _ProducerPayTotal = value; } }
        public float ProducerDebtTotal { get { return _ProducerDebtTotal; } set { _ProducerDebtTotal = value; } }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.TENNSX))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào loại tên nhà sản xuất"));
            }
            else if (this.TENNSX.Length > 200)
            {
                results.Add(new ValidationResult("Tên nhà sản xuất lớn hơn 200 ký tự"));
            }



            if (!string.IsNullOrEmpty(this.DIACHI))
            {
                if (this.DIACHI.Length > 300)
                {
                    results.Add(new ValidationResult("Địa chỉ nhà sản xuất không được dài quá 300 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.SODT))
            {
                if (this.SODT.Length > 50)
                {
                    results.Add(new ValidationResult("Số điện thoại nhà sản xuất không được dài quá 300 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.EMAIL))
            {
                if (this.EMAIL.Length > 100)
                {
                    results.Add(new ValidationResult("Email nhà sản xuất không được dài quá 100 ký tự"));
                }
            }


            return results;
        }
        #endregion  }
    }
}