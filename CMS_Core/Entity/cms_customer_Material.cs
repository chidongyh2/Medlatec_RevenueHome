using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class cms_customer_Material : IValidatableObject
    {
        #region Constructors  
        public cms_customer_Material() { }
        #endregion
        #region Private Fields  
        private int _id;
        private int _CustomerID;
        private int _MaterialID;
        private string _MaterialName;
        private int _MaterialUnit;
        private string _MaterialUnitName;
        private float _Amount;
        private float _Price;
        private float _TotalPrice;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private int _Status;
        private int _ProducerID;
        private int _OrderID;
        private int _customer_MaterialID;
        private string _CreateByName;
        private string _Ordercode;
        private int _isDebt;
        private float _TotalDebt;
        private DateTime _DateDebt;
        private int _DebtBill;
        private string _note;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public int CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }
        public int MaterialID { get { return _MaterialID; } set { _MaterialID = value; } }
        public string MaterialName { get { return _MaterialName; } set { _MaterialName = value; } }
        public string MaterialUnitName { get { return _MaterialUnitName; } set { _MaterialUnitName = value; } }
        public int MaterialUnit { get { return _MaterialUnit; } set { _MaterialUnit = value; } }
        public float Amount { get { return _Amount; } set { _Amount = value; } }
        public float Price { get { return _Price; } set { _Price = value; } }
        public float TotalPrice { get { return _TotalPrice; } set { _TotalPrice = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int ProducerID { get { return _ProducerID; } set { _ProducerID = value; } }
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public int customer_MaterialID { get { return _customer_MaterialID; } set { _customer_MaterialID = value; } }
        public string CreateByName { get { return _CreateByName; } set { _CreateByName = value; } }
        public string Ordercode { get { return _Ordercode; } set { _Ordercode = value; } }

        public int isDebt { get { return _isDebt; } set { _isDebt = value; } }
        public float TotalDebt { get { return _TotalDebt; } set { _TotalDebt = value; } }
        public DateTime DateDebt { get { return _DateDebt; } set { _DateDebt = value; } }
        public int DebtBill { get { return _DebtBill; } set { _DebtBill = value; } }
        public string note { get { return _note; } set { _note = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (this.CustomerID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn khách hàng"));
            }

            if (this.MaterialID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn nguyên liệu sản xuất"));
            }

            if (this.Amount <= 0)
            {
                results.Add(new ValidationResult("Số lượng nguyên liệu phải lớn hơn 0"));
            }

            if (this.ProducerID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn đối tác"));
            }

            if (this.Price <= 0)
            {
                results.Add(new ValidationResult("Giá tiền nguyên liệu phải lớn hơn 0"));
            }

            if (this.OrderID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn chọn hóa đơn"));
            }
            if (!string.IsNullOrEmpty(this.note))
            {
                if(note.Length > 500)
                results.Add(new ValidationResult("Ghi chú nhập dữ liệu không được lớn hơn 500 ký tự"));
            }

            return results;
        }
        #endregion  }
    }
}