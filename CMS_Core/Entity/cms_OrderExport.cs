using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class cms_OrderExport : IValidatableObject
    {
        #region Constructors  
        public cms_OrderExport() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _OrderCode;
        private int _CustomerID;
        private string _CustomerName;
        private string _CustomerAdress;
        private string _CustomerMobile;
        private string _CustomerEmail;
        private float _OrderExportTotal;
        private DateTime _OrderExportDate;
        private int _CreateBy;
        private DateTime _CreateDate;
        private int _UpdateBy;
        private DateTime _UpdateDate;
        private string _OrderExportNote;
        private int _Status;
        private int _OrderID;
        private string _OrderExport_Code;
        private string _OrderExportDateView;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string OrderCode { get { return _OrderCode; } set { _OrderCode = value; } }
        public int CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }
        public string CustomerAdress { get { return _CustomerAdress; } set { _CustomerAdress = value; } }
        public string CustomerMobile { get { return _CustomerMobile; } set { _CustomerMobile = value; } }
        public string CustomerEmail { get { return _CustomerEmail; } set { _CustomerEmail = value; } }
        public float OrderExportTotal { get { return _OrderExportTotal; } set { _OrderExportTotal = value; } }
        public DateTime OrderExportDate { get { return _OrderExportDate; } set { _OrderExportDate = value; _OrderExportDateView = _OrderExportDate.ToString("dd/MM/yyyy"); } }
        public int CreateBy { get { return _CreateBy; } set { _CreateBy = value; } }
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }
        public int UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public DateTime UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public string OrderExportNote { get { return _OrderExportNote; } set { _OrderExportNote = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int OrderID { get { return _OrderID; } set { _OrderID = value; } }
        public string OrderExport_Code { get { return _OrderExport_Code; } set { _OrderExport_Code = value; } }

        public string OrderExportDateView { get { return _OrderExportDateView; } set { _OrderExportDateView = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();


            if (CustomerID <= 0)
            {
                results.Add(new ValidationResult("Mời bạn nhập chọn id khách hàng"));
            }

             
            


            return results;
        }
        #endregion  }
    }
}
