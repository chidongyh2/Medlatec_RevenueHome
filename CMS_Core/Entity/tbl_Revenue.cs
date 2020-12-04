using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class tbl_Revenue : IValidatableObject
    {
        #region Constructors  

        public tbl_Revenue() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private string _userid;
        private string _locationid;
        private string _sid;
        private string _testcode;
        private string _testname;
        private string _CommentAgree;
        private int _Typeagree;
        private DateTime _datesave;
        private string _useridAgree;
        private int _levelAgree;
        private float _price;
        private bool _agree;
        private Int64 _IDSouce;
        private DateTime _NgayThu;
        private Int64 _IDCLS;
        private string _RevenueImages;
        #endregion
        #region Public Properties  
        public bool agree { get { return _agree; } set { _agree = value; } }
        public int ID { get { return _ID; } set { _ID = value; } }
        public Int64 IDSouce { get { return _IDSouce; } set { _IDSouce = value; } }
        public string userid { get { return _userid; } set { _userid = value; } }
        public string locationid { get { return _locationid; } set { _locationid = value; } }
        public string sid { get { return _sid; } set { _sid = value; } }
        public string testcode { get { return _testcode; } set { _testcode = value; } }
        public string testname { get { return _testname; } set { _testname = value; } }
        public string CommentAgree { get { return _CommentAgree; } set { _CommentAgree = value; } }
        public int Typeagree { get { return _Typeagree; } set { _Typeagree = value; } }
        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }
        public DateTime NgayThu { get { return _NgayThu; } set { _NgayThu = value; } }
        public string useridAgree { get { return _useridAgree; } set { _useridAgree = value; } }
        public int levelAgree { get { return _levelAgree; } set { _levelAgree = value; } }
        public float price { get { return _price; } set { _price = value; } }
        public Int64 IDCLS { get { return _IDCLS; } set { _IDCLS = value; } }
        public string RevenueImages { get { return _RevenueImages; } set { _RevenueImages = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.userid))
            {
                results.Add(new ValidationResult("Không có thông tin user cán bộ tại nhà"));
            }

            if (string.IsNullOrWhiteSpace(this.useridAgree))
            {
                results.Add(new ValidationResult("Không có thông tin người duyệt"));
            }

            if (!string.IsNullOrWhiteSpace(this.CommentAgree))
            {
                if (this.CommentAgree.Length > 200)
                {
                    results.Add(new ValidationResult("Nội dung từ chối quá 200 ký tự"));
                }
            }


           




            return results;
        }
        #endregion  }
    }
}