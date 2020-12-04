using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_Material : IValidatableObject
    {
        #region Constructors  
        public cms_Material() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _MaterialName;
        private string _MaterialDesc;
        private float _MaterialHeight;
        private float _MaterialWidht;
        private int _MaterialUnit;
        private int _MaterialCateID;
        private int _ProducerID;
        private int _MaterialColor;
       
        private int _MaterialType;
        private int _MaterialStatus;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private float _MaterialPrice;
        private string _MaterialPriceView;
        private string _MaterialUnitName;
        private string _MaterialCateName;
        private string _ProducerName;
        private string _MaterialColorName;
        private float _Amount;
        private float _TotalPrice;
        private string _AmountView;
        private string _TotalPriceView;
        private string _note;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string MaterialName { get { return _MaterialName; } set { _MaterialName = value; } }
        public string MaterialDesc { get { return _MaterialDesc; } set { _MaterialDesc = value; } }
        public float MaterialHeight { get { return _MaterialHeight; } set { _MaterialHeight = value; } }
        public float MaterialWidht { get { return _MaterialWidht; } set { _MaterialWidht = value; } }
        public int MaterialUnit { get { return _MaterialUnit; } set { _MaterialUnit = value; } }
        public int MaterialCateID { get { return _MaterialCateID; } set { _MaterialCateID = value; } }
     
        public int ProducerID { get { return _ProducerID; } set { _ProducerID = value; } }
        public int MaterialColor { get { return _MaterialColor; } set { _MaterialColor = value; } }
        public int MaterialType { get { return _MaterialType; } set { _MaterialType = value; } }
        public int MaterialStatus { get { return _MaterialStatus; } set { _MaterialStatus = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public float MaterialPrice { get { return _MaterialPrice; } set { _MaterialPrice = value; } }
        public string MaterialUnitName { get { return _MaterialUnitName; } set { _MaterialUnitName = value; } }
        public string MaterialCateName { get { return _MaterialCateName; } set { _MaterialCateName = value; } }
        public string ProducerName { get { return _ProducerName; } set { _ProducerName = value; } }
        public string MaterialColorName { get { return _MaterialColorName; } set { _MaterialColorName = value; } }
        public float Amount { get { return _Amount; } set { _Amount = value; } }
        public float TotalPrice { get { return _TotalPrice; } set { _TotalPrice = value; } }
        public string AmountView { get { return _AmountView; } set { _AmountView = value; } }
        public string TotalPriceView { get { return _TotalPriceView; } set { _TotalPriceView = value; } }

        public string MaterialPriceView { get { return _MaterialPriceView; } set { _MaterialPriceView = value; } }

        public string note { get { return _note; } set { _note = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.MaterialName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên nguyên liệu"));
            }
            else if (this.MaterialName.Length > 300)
            {
                results.Add(new ValidationResult("Tên nguyên liệu lớn hơn 300 ký tự"));
            }

            if (!string.IsNullOrEmpty(this.MaterialDesc))
            {
                if (this.MaterialDesc.Length > 500)
                {
                    results.Add(new ValidationResult("Mô tả nguyên liệu không được dài quá 500 ký tự"));
                }
            }

            if (this.MaterialHeight <= 0)
            {
                results.Add(new ValidationResult("Chiều cao nguyên liệu không được <= 0"));
            }

            if (this.MaterialWidht <= 0)
            {
                results.Add(new ValidationResult("Chiều rộng nguyên liệu không được <= 0"));
            }

            if (this.ProducerID <= 0)
            {
                results.Add(new ValidationResult("Nhà cung cấp nguyên liệu không được <= 0"));
            }

            if(!string.IsNullOrEmpty(MaterialPriceView))
            {
                MaterialPrice = float.Parse(MaterialPriceView.Replace(",", ""));
            }
            if (!string.IsNullOrEmpty(AmountView))
            {
                Amount = float.Parse(AmountView.Replace(",", ""));
            }

            if (this.MaterialPrice <= 0)
            {
                results.Add(new ValidationResult("Giá nguyên liệu không được <= 0"));
            }
            if (!string.IsNullOrEmpty(this.note))
            {
                if (note.Length > 500)
                    results.Add(new ValidationResult("Ghi chú nhập dữ liệu không được lớn hơn 500 ký tự"));
            }

            if (MaterialUnit <= 0)
            {
                results.Add(new ValidationResult("Đơn vị sản phẩm không được <= 0"));
            }

            if (MaterialUnit <= 0)
            {
                results.Add(new ValidationResult("Số lượng không được <= 0"));
            }
            return results;
        }
        #endregion  }
    }
}
