using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    public class COMPLEMENT_SETTUP : IValidatableObject
    {
        #region Constructors  
        public COMPLEMENT_SETTUP()
        {
            FIELD_NAME = string.Empty;
            CLASS = "form-control";
            LABEL_NAME = string.Empty;
            CATEGORYS_ID = 0;
            DISPLAYORDER = 0;
            COMPLEMENT_STATUS = 1;
            REQUIREDMESSAGE = string.Empty;
            REQUIRED = 0;
            TEXTBOX_TYPE = string.Empty;
        }
        #endregion
        #region Private Fields  
        private Int64 _ID;
        private Int64 _COMPLEMENTID;
        private string _CLASS;
        private string _LABEL_NAME;
        private string _PLACEHOLDER;
        private int _REQUIRED;
        private string _REQUIREDMESSAGE;
        private int _FIELDTYPE;
        private string _FIELD_NAME;
        private string _FIELD_VALUE;
        private int _CATEGORYS_ID;
        private int _DISPLAYORDER;
        private int _COMPLEMENT_STATUS;
        private int _ORIENTATION;
        private string _SQL;
        private int _COLS_LENGTH;
        private int _ROWS_LENGTH;
        private bool _REQUIREDVALUE;
        private bool _FIELD_VALUE_BOOL;
        private string _TEXTBOX_TYPE;
        private string _FIELDTYPE_NAME;
        private int _TYPEDATAINPUT;
        private string _SQLCHILD;
        private string _CHILDID;


        #endregion
        #region Public Properties  
        public Int64 ID { get { return _ID; } set { _ID = value; } }
        public Int64 COMPLEMENTID { get { return _COMPLEMENTID; } set { _COMPLEMENTID = value; } }
        public string CLASS { get { return _CLASS; } set { _CLASS = value; } }
        public string LABEL_NAME { get { return _LABEL_NAME; } set { _LABEL_NAME = value; } }
        public string PLACEHOLDER { get { return _PLACEHOLDER; } set { _PLACEHOLDER = value; } }
        public int REQUIRED { get { return _REQUIRED; } set { _REQUIRED = value; if (_REQUIRED == 0) _REQUIREDVALUE = false; if (_REQUIRED == 1) _REQUIREDVALUE = true; } }
        public bool REQUIREDVALUE { get { return _REQUIREDVALUE; } set { _REQUIREDVALUE = value; } }

        public string REQUIREDMESSAGE { get { return _REQUIREDMESSAGE; } set { _REQUIREDMESSAGE = value; } }
        public int FIELDTYPE { get { return _FIELDTYPE; } set { _FIELDTYPE = value; } }
        public string FIELD_NAME { get { return _FIELD_NAME; } set { _FIELD_NAME = value; } }
        public string FIELD_VALUE { get { return _FIELD_VALUE; } set { _FIELD_VALUE = value; if (!string.IsNullOrEmpty(_FIELD_VALUE)) { if (_FIELD_VALUE == "1") _FIELD_VALUE_BOOL = true; else _FIELD_VALUE_BOOL = false; } } }
        public int CATEGORYS_ID { get { return _CATEGORYS_ID; } set { _CATEGORYS_ID = value; } }
        public int DISPLAYORDER { get { return _DISPLAYORDER; } set { _DISPLAYORDER = value; } }
        public int COMPLEMENT_STATUS { get { return _COMPLEMENT_STATUS; } set { _COMPLEMENT_STATUS = value; } }
        public int ORIENTATION { get { return _ORIENTATION; } set { _ORIENTATION = value; } }
        public string SQL { get { return _SQL; } set { _SQL = value; } }
        public int COLS_LENGTH { get { return _COLS_LENGTH; } set { _COLS_LENGTH = value; } }
        public int ROWS_LENGTH { get { return _ROWS_LENGTH; } set { _ROWS_LENGTH = value; } }
        public bool FIELD_VALUE_BOOL { get { return _FIELD_VALUE_BOOL; } set { _FIELD_VALUE_BOOL = value; } }
        public string TEXTBOX_TYPE { get { return _TEXTBOX_TYPE; } set { _TEXTBOX_TYPE = value; } }
        public string FIELDTYPE_NAME { get { return _FIELDTYPE_NAME; } set { _FIELDTYPE_NAME = value; } }

        public int TYPEDATAINPUT { get { return _TYPEDATAINPUT; } set { _TYPEDATAINPUT = value; } }

        public string SQLCHILD { get { return _SQLCHILD; } set { _SQLCHILD = value; } }
        public string CHILDID { get { return _CHILDID; } set { _CHILDID = value; } }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.FIELD_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên chuyên mục"));
            }
            else if (this.FIELD_NAME.Length > 200)
            {
                results.Add(new ValidationResult("Tên chuyên mục lớn hơn 200 ký tự"));
            }
            else if (this.FIELD_NAME.IndexOf(" ") != -1)
            {
                results.Add(new ValidationResult("Tên chuyên mục không có ký tự trống"));
            }
            else if (Common.Common.hasSpecialChar(this.FIELD_NAME))
            {
                results.Add(new ValidationResult("Tên chuyên mục có ký tự đặc biệt"));
            }

            if (string.IsNullOrEmpty(this.CLASS))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào Class"));
            }
            else if (this.CLASS.Length > 200)
            {
                results.Add(new ValidationResult("Class không được dài quá 200 ký tự"));
            }

            if (string.IsNullOrEmpty(this.LABEL_NAME))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào Tiêu đề trường"));
            }
            else if (this.LABEL_NAME.Length > 200)
            {
                results.Add(new ValidationResult("Tiêu đề trường không được dài quá 200 ký tự"));
            }


            if (!string.IsNullOrEmpty(this.PLACEHOLDER))
            {
                if (this.PLACEHOLDER.Length > 200)
                {
                    results.Add(new ValidationResult("PLACEHOLDER không được dài quá 200 ký tự"));
                }
            }

            if (!string.IsNullOrEmpty(this.REQUIREDMESSAGE))
            {
                if (this.REQUIREDMESSAGE.Length > 400)
                {
                    results.Add(new ValidationResult("REQUIREDMESSAGE không được dài quá 400 ký tự"));
                }
            }

            if (this.CATEGORYS_ID == 0)
            {
                results.Add(new ValidationResult("Bạn chưa chọn ID chuyên mục"));
            }

            if (this.FIELDTYPE == 0)
            {
                results.Add(new ValidationResult("Bạn chưa chọn loại type "));
            }

            if (!string.IsNullOrEmpty(this.SQL))
            {
                if (this.SQL.Length > 300)
                {
                    results.Add(new ValidationResult("SQL không được dài quá 400 ký tự"));
                }
            }


            return results;
        }

        #endregion

    }
}
