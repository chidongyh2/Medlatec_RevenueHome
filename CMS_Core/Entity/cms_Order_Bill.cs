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
    public class cms_Order_Bill : IValidatableObject
    {
        #region Constructors  
        public cms_Order_Bill() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _OrderCode;
        private int _CustomerID;
        private string _CustomerName;
        private string _CustomerAdress;
        private string _CustomerMobile;
        private float _BillTotal;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private string _BillCode;
        private string _BillImage;
        private int _OrderID;
        private string _BillNote;
        private string _BillTotalView;
        private string _BillCodeGroup;
        private int _BillTop;
        private float _BillTotalGroup;
        public HttpPostedFileBase ImageFile { get; set; }
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string OrderCode { get { return _OrderCode; } set { _OrderCode = value; } }
        public int CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }
        public string CustomerAdress { get { return _CustomerAdress; } set { _CustomerAdress = value; } }
        public string CustomerMobile { get { return _CustomerMobile; } set { _CustomerMobile = value; } }
        public float BillTotal { get { return _BillTotal; } set { _BillTotal = value; } }
        public float BillTotalGroup { get { return _BillTotalGroup; } set { _BillTotalGroup = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public string BillCode { get { return _BillCode; } set { _BillCode = value; } }
        public string BillImage { get { return _BillImage; } set { _BillImage = value; } }
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public string BillNote { get { return _BillNote; } set { _BillNote = value; } }
        public string BillTotalView { get { return _BillTotalView; } set { _BillTotalView = value; } }
        public string BillCodeGroup { get { return _BillCodeGroup; } set { _BillCodeGroup = value; } }
        public int BillTop { get { return _BillTop; } set { _BillTop = value; } }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (!string.IsNullOrWhiteSpace(this.BillCode))
            {
                if (this.BillCode.Length > 50)
                {
                    results.Add(new ValidationResult("Mã hóa đơn lớn hơn 50 ký tự"));
                }
            }
             

            if (OrderID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn hóa đơn!"));
            }

            if (BillTotal <= 0)
            {
                results.Add(new ValidationResult("Mời bạn nhập giá hóa đơn!"));
            }



            return results;
        }
        #endregion  }
    }
}