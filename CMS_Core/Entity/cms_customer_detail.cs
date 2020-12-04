using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_customer_detail : IValidatableObject
    {
        #region Constructors  
        public cms_customer_detail() { }
        #endregion
        #region Private Fields  
        private int _id;
        private int _CustomerID;
        private int _ItemID;
        private string _ItemName;
        private int _ItemUnit;
        private float _Amount;
        private float _Price;
        private float _TotalPrice;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private int _Status;
        private string _ItemUnitName;
        private int _ItemCateItemID;
        private string _ItemCateItemIDName;
        private int _OrderID;
        private float _AmountExport;
        private float _AmountOldExport;
        private string _OrderCode;
        private int _OrderID2;
        private string _OrderCode2;
        private string _note;
        
        #endregion
        #region Public Properties  

        public float AmountExport { get { return _AmountExport; } set { _AmountExport = value; } }
        public float AmountOldExport { get { return _AmountOldExport; } set { _AmountOldExport = value; } }
        public int id { get { return _id; } set { _id = value; } }
        public int CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }
        public int ItemID { get { return _ItemID; } set { _ItemID = value; } }
        public string ItemName { get { return _ItemName; } set { _ItemName = value; } }
        public string Note { get { return _note; } set { _note = value; } }
        public int ItemUnit { get { return _ItemUnit; } set { _ItemUnit = value; } }
        public float Amount { get { return _Amount; } set { _Amount = value; } }
        public float Price { get { return _Price; } set { _Price = value; } }
        public float TotalPrice { get { return _TotalPrice; } set { _TotalPrice = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int ItemCateItemID { get { return _ItemCateItemID; } set { _ItemCateItemID = value; } }
        public string ItemUnitName { get { return _ItemUnitName; } set { _ItemUnitName = value; } }
        public string ItemCateItemIDName { get { return _ItemCateItemIDName; } set { _ItemCateItemIDName = value; } }
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }

        public int OrderID2 { get { return _OrderID2; } set { _OrderID2 = value; } }
        public string OrderCode { get { return _OrderCode; } set { _OrderCode = value; } }
        public string OrderCode2 { get { return _OrderCode2; } set { _OrderCode2 = value; } }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (this.CustomerID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn khách hàng"));
            }

            if (this.ItemID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn sản phẩm"));
            }

            if (this.Amount <= 0)
            {
                results.Add(new ValidationResult("Số lượng sản phẩm phải lớn hơn 0"));
            }
            if (this.Price <= 0)
            {
                results.Add(new ValidationResult("Giá tiền sản phẩm phải lớn hơn 0"));
            }
            if (this.OrderID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn ID khách hàng"));
            }
            if (!string.IsNullOrEmpty(Note))
            {
                if (Note.Length > 500)
                {
                    results.Add(new ValidationResult("Ghi chú sản phầm không được quá 500 ký tự!"));
                }
            }

            return results;
        }
        #endregion  }
    }
}
