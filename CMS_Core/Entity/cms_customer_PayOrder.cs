using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_customer_PayOrder : IValidatableObject
    {
        #region Constructors  
        public cms_customer_PayOrder() { }
        #endregion
        #region Private Fields  
        private int _id;
        private int _CustomerID;
        private float _PayPrice;
        private string _Numberbill;
        private string _NumberbillBank;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private int _Status;
        private string _ImagePath;
        private int _OrderID;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public int CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }
        public float PayPrice { get { return _PayPrice; } set { _PayPrice = value; } }
        public string Numberbill { get { return _Numberbill; } set { _Numberbill = value; } }
        public string NumberbillBank { get { return _NumberbillBank; } set { _NumberbillBank = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; } }
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (this.CustomerID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn khách hàng"));
            }

            if (this.PayPrice <= 0)
            {
                results.Add(new ValidationResult("Số tiền trả phải lớn hơn 0"));
            }

            if (string.IsNullOrWhiteSpace(this.Numberbill))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên hóa đơn thanh toán"));
            }
            else if (this.Numberbill.Length > 100)
            {
                results.Add(new ValidationResult("Tên hóa đơn lớn hơn 100 ký tự"));
            }

            if (this.OrderID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn ID khách hàng"));
            }
            return results;
        }
        #endregion  }
    }

}