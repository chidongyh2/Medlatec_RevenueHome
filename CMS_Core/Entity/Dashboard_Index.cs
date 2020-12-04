using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class Dashboard_Index
    {
        
        #region Private Fields  
        private Int64 _Total; // công nợ đối tác
        private Int64 _Total2; // công nợ khác hàng
        private Int64 _Total3;  // Ứng nguyên liệu
        private Int64 _Total4;  // mua nguyen lieu
        private Int64 _Total5;// Tiền hàng đang sản xuất
        private Int64 _Total6;// Tiền khách hàng ứng
        //  private DateTime _create_date;

        private string _create_date_View;
        
        #endregion
        #region Public Properties  
        public Int64 Total { get { return _Total; } set { _Total = value; } }
        public Int64 Total2 { get { return _Total2; } set { _Total2 = value; } }
        public Int64 Total3 { get { return _Total3; } set { _Total3 = value; } }
        public Int64 Total4 { get { return _Total4; } set { _Total4 = value; } }
        public Int64 Total5 { get { return _Total5; } set { _Total5 = value; } }
        public Int64 Total6 { get { return _Total6; } set { _Total6 = value; } }
        //   public DateTime create_date { get { return _create_date; } set { _create_date = value; _create_date_View = _create_date.ToString("ddMMyyyy"); } }         
        public string create_date_View { get { return _create_date_View; } set { _create_date_View = value; } }               
        #endregion

    }
}
