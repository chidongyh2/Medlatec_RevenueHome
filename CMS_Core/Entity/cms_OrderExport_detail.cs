using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class cms_OrderExport_detail : IValidatableObject
    {
        #region Constructors  
        public cms_OrderExport_detail() { }
        #endregion
        #region Private Fields  
        private int _id;
        private int _OrderExportID;
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
        private int _OrderID;
        private bool _view;
        private string _ItemUnitName;
        private string _OrderCode;
        private string _codeItemExport;
        private string _OrderNote;

        

        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public int OrderExportID { get { return _OrderExportID; } set { _OrderExportID = value; } }
        public int CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }
        public int ItemID { get { return _ItemID; } set { _ItemID = value; } }
        public string ItemName { get { return _ItemName; } set { _ItemName = value; } }
        public int ItemUnit { get { return _ItemUnit; } set { _ItemUnit = value; } }
        public float Amount { get { return _Amount; } set { _Amount = value; } }
        public float Price { get { return _Price; } set { _Price = value; } }
        public float TotalPrice { get { return _TotalPrice; } set { _TotalPrice = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public string ItemUnitName { get { return _ItemUnitName; } set { _ItemUnitName = value; } }
        public bool view { get { return _view; } set { _view = value; } }
        public string OrderCode { get { return _OrderCode; } set { _OrderCode = value; } }
        public string codeItemExport { get { return _codeItemExport; } set { _codeItemExport = value; } }
        public string OrderNote { get { return _OrderNote; } set { _OrderNote = value; } }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            
            if(CustomerID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn nhập chọn id khách hàng"));
            }

            if (OrderID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn nhập chọn hóa đơn"));
            }
            if (ItemID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn nhập chọn hàng hóa"));
            }
            if (Amount <= 0)
            {
                results.Add(new ValidationResult("Mời bạn nhập chọn số lượng"));
            }

            return results;
        }
        #endregion  }
    }
}