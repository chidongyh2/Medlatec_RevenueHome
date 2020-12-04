using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_item : IValidatableObject
    {

        #region Constructors  
        public cms_item() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _ItemName;
        private string _ItemDesc;
        private int _ItemUnit;
        private int _ItemColor;
        private float _ItemSurvive;
        private string _ItemUsage;
        private int _ItemProducer;
        private string _ItemNote;
        private int _ItemCateItemID;
        private int _Createby;
        private DateTime _CreateDate;
        private int _Updateby;
        private DateTime _UpdateDate;
        private float _ItemPrice;
        private int _ItemStatus;
        private string _ItemUnitName;
        private string _CateItemName;
        private float _ItemPay;
        private float _ItemAmount;
        private float _ItemTotal;
        private string _ItemPayView;
        private string _ItemAmountView;
        private string _ItemTotalView;
        private string _Note;

        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string ItemName { get { return _ItemName; } set { _ItemName = value; } }
        public string Note { get { return _Note; } set { _Note = value; } }
        public string ItemDesc { get { return _ItemDesc; } set { _ItemDesc = value; } }
        public int ItemUnit { get { return _ItemUnit; } set { _ItemUnit = value; } }
        public int ItemColor { get { return _ItemColor; } set { _ItemColor = value; } }
        public float ItemSurvive { get { return _ItemSurvive; } set { _ItemSurvive = value; } }
        public string ItemUsage { get { return _ItemUsage; } set { _ItemUsage = value; } }
        public int ItemProducer { get { return _ItemProducer; } set { _ItemProducer = value; } }
        public string ItemNote { get { return _ItemNote; } set { _ItemNote = value; } }
        public int ItemCateItemID { get { return _ItemCateItemID; } set { _ItemCateItemID = value; } }
        public int Createby { get { return _Createby; } set { _Createby = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int Updateby { get { return _Updateby; } set { _Updateby = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }

        public float ItemPrice { get { return _ItemPrice; } set { _ItemPrice = value; } }
        public string ItemUnitName { get { return _ItemUnitName; } set { _ItemUnitName = value; } }
        public string CateItemName { get { return _CateItemName; } set { _CateItemName = value; } }
        public float ItemPay { get { return _ItemPay; } set { _ItemPay = value; } }
        public float ItemAmount { get { return _ItemAmount; } set { _ItemAmount = value; } }

        public float ItemTotal { get { return _ItemTotal; } set { _ItemTotal = value; } }

        public int ItemStatus { get { return _ItemStatus; } set { _ItemStatus = value; } }

        public string ItemPayView { get { return _ItemPayView; } set { _ItemPayView = value; } }
        public string ItemAmountView { get { return _ItemAmountView; } set { _ItemAmountView = value; } }
        public string ItemTotalView { get { return _ItemTotalView; } set { _ItemTotalView = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.ItemName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên sản phầm"));
            }
            else if (this.ItemName.Length > 300)
            {
                results.Add(new ValidationResult("Tên sản phầm lớn hơn 300 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.ItemDesc))
            {
                if (this.ItemDesc.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả sản phẩm không được dài quá 500 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(ItemPayView))
            {
                ItemPay = float.Parse(ItemPayView.Replace(",", ""));
            }
            if (!string.IsNullOrEmpty(ItemAmountView))
            {
                ItemAmount = float.Parse(ItemAmountView.Replace(",", ""));
            }
            if (!string.IsNullOrEmpty(ItemTotalView))
            {
                ItemTotal = float.Parse(ItemTotalView.Replace(",", ""));
            }

            if (!string.IsNullOrEmpty(this.ItemNote))
            {
                if (this.ItemNote.Length > 500)
                {
                    results.Add(new ValidationResult("Ghi chú sản phẩm không được dài quá 500 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.ItemUsage))
            {
                if (this.ItemUsage.Length > 500)
                {
                    results.Add(new ValidationResult("Cách sử dụng sản phẩm không được dài quá 500 ký tự"));
                }
            }

            if (this.ItemSurvive <= 0)
            {
                results.Add(new ValidationResult("Giá tham khảo không được <= 0"));
            }


            if (ItemUnit <= 0)
            {
                results.Add(new ValidationResult("Đơn vị sản phẩm không được <= 0"));
            }


            return results;
        }
        #endregion  }
    }

}