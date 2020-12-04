using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Order : IValidatableObject
    {
        #region Constructors  
        public cms_Order() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _OrderCode;
        private int _CustomerID;
        private string _CustomerName;
        private string _CustomerAdress;
        private string _CustomerMobile;
        private string _CustomerSurrogate;
        private string _CustomerSurrogateMobile;
        private string _CustomerEmail;
        private int _CustomerType;
        private float _OrderTotal;
        private DateTime _StartDate;
        private string _StartDateView;
        private DateTime _Enddate;
        private string _EnddateView;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private string _CustomerTypeName;
        private float _OrderPay;
        private float _OrderMaterial;
        private string _OrderNote;
        private string _OrderPayView;
        private string _OrderMaterialView;
        private float _OrderBill;
        private string _CreateByName;
        private int _Order_BillID;
        private string _color;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string OrderCode { get { return _OrderCode; } set { _OrderCode = value; } }
        public int CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }
        public string CustomerAdress { get { return _CustomerAdress; } set { _CustomerAdress = value; } }
        public string CustomerMobile { get { return _CustomerMobile; } set { _CustomerMobile = value; } }
        public string CustomerSurrogate { get { return _CustomerSurrogate; } set { _CustomerSurrogate = value; } }
        public string CustomerSurrogateMobile { get { return _CustomerSurrogateMobile; } set { _CustomerSurrogateMobile = value; } }
        public string CustomerEmail { get { return _CustomerEmail; } set { _CustomerEmail = value; } }
        public int CustomerType { get { return _CustomerType; } set { _CustomerType = value; } }
        public float OrderTotal { get { return _OrderTotal; } set { _OrderTotal = value; } }
        public DateTime StartDate { get { return _StartDate; } set { _StartDate = value; _StartDateView = _StartDate.ToString("dd/MM/yyyy"); } }
        public DateTime Enddate { get { return _Enddate; } set { _Enddate = value; _EnddateView = _Enddate.ToString("dd/MM/yyyy"); } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public string CustomerTypeName { get { return _CustomerTypeName; } set { _CustomerTypeName = value; } }
        public float OrderPay { get { return _OrderPay; } set { _OrderPay = value; } }
        public float OrderMaterial { get { return _OrderMaterial; } set { _OrderMaterial = value; } }
        public string StartDateView { get { return _StartDateView; } set { _StartDateView = value; } }
        public string EnddateView { get { return _EnddateView; } set { _EnddateView = value; } }

        public string OrderNote { get { return _OrderNote; } set { _OrderNote = value; } }
        public string CreateByName { get { return _CreateByName; } set { _CreateByName = value; } }
        public string OrderPayView { get { return _OrderPayView; } set { _OrderPayView = value; } }

        public string OrderMaterialView { get { return _OrderMaterialView; } set { _OrderMaterialView = value; } }
        public float OrderBill { get { return _OrderBill; } set { _OrderBill = value; } }
        public int Order_BillID { get { return _Order_BillID; } set { _Order_BillID = value; } }
        public string color { get { return _color; } set { _color = value; } }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.CustomerName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên khách hàng"));
            }
            else if (this.CustomerName.Length > 300)
            {
                results.Add(new ValidationResult("Tên khách hàng lớn hơn 300 ký tự"));
            }

            //if (CustomerID <= 0)
            //{
            //    results.Add(new ValidationResult("Mời bạn chọn khách hàng!"));
            //}

            if (!string.IsNullOrEmpty(this.CustomerAdress))
            {
                if (this.CustomerAdress.Length > 500)
                {
                    results.Add(new ValidationResult("Địa chỉ khách hàng không được dài quá 500 ký tự"));
                }
            }



            if (!string.IsNullOrEmpty(this.OrderNote))
            {
                if (this.OrderNote.Length > 1000)
                {
                    results.Add(new ValidationResult("ghi chú khách hàng không được dài quá 1000 ký tự"));
                }
            }

            if (string.IsNullOrWhiteSpace(this.CustomerMobile))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào số điện thoại khách hàng"));
            }
            else if (this.CustomerMobile.Length > 50)
            {
                results.Add(new ValidationResult("Số điện thoại khách hàng lớn hơn 50 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.CustomerSurrogate))
            {
                if (this.CustomerSurrogate.Length > 200)
                {
                    results.Add(new ValidationResult("Người đại diện khách hàng không được dài quá 200 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.CustomerEmail))
            {
                if (this.CustomerEmail.Length > 100)
                {
                    results.Add(new ValidationResult("Email khách hàng không được dài quá 100 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.CustomerSurrogateMobile))
            {
                if (this.CustomerSurrogateMobile.Length > 50)
                {
                    results.Add(new ValidationResult("Số điện thoại người đại diện khách hàng không được dài quá 50 ký tự"));
                }
            }

            //if (Enddate < DateTime.Now)
            //{
            //    results.Add(new ValidationResult("Thơi gian kết thúc phải lớn hơn ngày hiện tại"));
            //}
            //if (StartDate > Enddate)
            //{
            //    results.Add(new ValidationResult("Thơi gian bắt  đầu nhỏ hơn thời gian kết thúc"));
            //}

            return results;
        }
        #endregion  }
    }
}