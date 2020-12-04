using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Customer
    {
        #region Constructors  
        public cms_Customer() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _CustomerName;
        private string _CustomerDesc;
        private string _CustomerAdress;
        private string _CustomerMobile;
        private string _CustomerSurrogate;
        private string _CustomerSurrogateMobile;
        private string _CustomerEmail;
        private int _CustomerType;
        private string _CustomerWebsite;
        private float _CustomerTotal;
      
        private int _CustomerStatus;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private string _CustomerTypeName;
        private float _CustomerPay;
        private float _CustomerMaterial;
        private float _CustomerDebt;
        private float _Order_BillTotal;

        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }
        public string CustomerDesc { get { return _CustomerDesc; } set { _CustomerDesc = value; } }
        public string CustomerAdress { get { return _CustomerAdress; } set { _CustomerAdress = value; } }
        public string CustomerMobile { get { return _CustomerMobile; } set { _CustomerMobile = value; } }
        public string CustomerSurrogate { get { return _CustomerSurrogate; } set { _CustomerSurrogate = value; } }
        public string CustomerSurrogateMobile { get { return _CustomerSurrogateMobile; } set { _CustomerSurrogateMobile = value; } }
        public string CustomerEmail { get { return _CustomerEmail; } set { _CustomerEmail = value; } }
        public int CustomerType { get { return _CustomerType; } set { _CustomerType = value; } }
        public string CustomerWebsite { get { return _CustomerWebsite; } set { _CustomerWebsite = value; } }
        public float CustomerTotal { get { return _CustomerTotal; } set { _CustomerTotal = value; } }
        public float Order_BillTotal { get { return _Order_BillTotal; } set { _Order_BillTotal = value; } }
        public float CustomerPay { get { return _CustomerPay; } set { _CustomerPay = value; } }
        public float CustomerMaterial { get { return _CustomerMaterial; } set { _CustomerMaterial = value; } }
        public float CustomerDebt { get { return _CustomerDebt; } set { _CustomerDebt = value; } }

        public int CustomerStatus { get { return _CustomerStatus; } set { _CustomerStatus = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }

        public string CustomerTypeName { get { return _CustomerTypeName; } set { _CustomerTypeName = value; } }
       
        #endregion   
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

            if (!string.IsNullOrEmpty(this.CustomerDesc))
            {
                if (this.CustomerDesc.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả khách hàng không được dài quá 500 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.CustomerAdress))
            {
                if (this.CustomerAdress.Length > 500)
                {
                    results.Add(new ValidationResult("Địa chỉ khách hàng không được dài quá 500 ký tự"));
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

            return results;
        }
    }
}

 