using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class cms_Order_Debt_Producte : IValidatableObject
    {
        #region Constructors  
        public cms_Order_Debt_Producte() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private float _BillTotal;
        private int _ProducerID;
        private string _TENNSX;
        private string _BillNote;
        private DateTime _BillDate;
        private string _BillDateView;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private int _Status;
        private int _maxID;
        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public int maxID { get { return _maxID; } set { _maxID = value; } }
        public float BillTotal { get { return _BillTotal; } set { _BillTotal = value; } }
        public int ProducerID { get { return _ProducerID; } set { _ProducerID = value; } }
        public string TENNSX { get { return _TENNSX; } set { _TENNSX = value; } }
        public string BillNote { get { return _BillNote; } set { _BillNote = value; } }
        public DateTime BillDate { get { return _BillDate; } set { _BillDate = value; _BillDateView = _BillDate.ToString("dd/MM/yyyy"); } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string BillDateView { get { return _BillDateView; } set { _BillDateView = value; } }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

           if(!string.IsNullOrWhiteSpace(BillNote))
            {
                if(BillNote.Length > 500)
                {
                    results.Add(new ValidationResult("Ghi chú trả tiển đối tác không được lớn hơn 500 ký tự!"));
                }
            }

            if (ProducerID <= 0)
            {
                results.Add(new ValidationResult("Bạn chọn đối tác!"));
            }


            if (BillTotal < 0)
            {
                results.Add(new ValidationResult("Số tiền thanh toán không thể âm!"));
            }

            return results;
        }
        #endregion  }
    }

}