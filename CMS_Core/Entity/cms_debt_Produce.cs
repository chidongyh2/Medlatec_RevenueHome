using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class cms_debt_Produce : IValidatableObject
    {
        #region Constructors  
        public cms_debt_Produce() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private int _ProducerID;
        private int _Year;
        private float _Total;
        private int _Status;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private String _ProducerName;
        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public int ProducerID { get { return _ProducerID; } set { _ProducerID = value; } }
        public int Year { get { return _Year; } set { _Year = value; } }
        public float Total { get { return _Total; } set { _Total = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public String ProducerName { get { return _ProducerName; } set { _ProducerName = value; } }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Year < DateTime.Now.Year - 2)
            {
                results.Add(new ValidationResult("Năm chốt công nợ của đối tác không được nhỏ hơn năm hiện tại!"));
            }

            if (Year > DateTime.Now.Year)
            {
                results.Add(new ValidationResult("Năm chốt công nợ của đối tác không được lớn hơn năm hiện tại!"));
            }

            if (ProducerID <= 0)
            {
                results.Add(new ValidationResult("Bạn chọn đối tác!"));
            }


            if (Total < 0)
            {
                results.Add(new ValidationResult("Số tiền nợ đối tác không thể âm!"));
            }

            return results;
        }
        #endregion  }
    }
}