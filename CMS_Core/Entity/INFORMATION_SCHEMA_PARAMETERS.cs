using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class INFORMATION_SCHEMA_PARAMETERS
    {
        #region Constructors  
        public INFORMATION_SCHEMA_PARAMETERS() { }
        #endregion
        #region Private Fields  
        private string _SPECIFIC_CATALOG;
        private string _SPECIFIC_SCHEMA;
        private string _SPECIFIC_NAME;
        private int _ORDINAL_POSITION;
        private string _PARAMETER_MODE;
        private string _IS_RESULT;
        private string _AS_LOCATOR;
        private string _PARAMETER_NAME;
        private string _DATA_TYPE;
        private int _CHARACTER_MAXIMUM_LENGTH;
        private int _CHARACTER_OCTET_LENGTH;
        private string _COLLATION_CATALOG;
        private string _COLLATION_SCHEMA;
        private string _COLLATION_NAME;
        private string _CHARACTER_SET_CATALOG;
        private string _CHARACTER_SET_SCHEMA;
        private string _CHARACTER_SET_NAME;
        private int _NUMERIC_PRECISION;
        private int _NUMERIC_PRECISION_RADIX;
        private int _NUMERIC_SCALE;
        private int _DATETIME_PRECISION;
        private string _INTERVAL_TYPE;
        private int _INTERVAL_PRECISION;
        private string _USER_DEFINED_TYPE_CATALOG;
        private string _USER_DEFINED_TYPE_SCHEMA;
        private string _USER_DEFINED_TYPE_NAME;
        private string _SCOPE_CATALOG;
        private string _SCOPE_SCHEMA;
        private string _SCOPE_NAME;


        #endregion
        #region Public Properties  
        public string SPECIFIC_CATALOG { get { return _SPECIFIC_CATALOG; } set { _SPECIFIC_CATALOG = value; } }
        public string SPECIFIC_SCHEMA { get { return _SPECIFIC_SCHEMA; } set { _SPECIFIC_SCHEMA = value; } }
        public string SPECIFIC_NAME { get { return _SPECIFIC_NAME; } set { _SPECIFIC_NAME = value; } }
        public int ORDINAL_POSITION { get { return _ORDINAL_POSITION; } set { _ORDINAL_POSITION = value; } }
        public string PARAMETER_MODE { get { return _PARAMETER_MODE; } set { _PARAMETER_MODE = value; } }
        public string IS_RESULT { get { return _IS_RESULT; } set { _IS_RESULT = value; } }
        public string AS_LOCATOR { get { return _AS_LOCATOR; } set { _AS_LOCATOR = value; } }
        public string PARAMETER_NAME { get { return _PARAMETER_NAME; } set { _PARAMETER_NAME = value; } }
        public string DATA_TYPE { get { return _DATA_TYPE; } set { _DATA_TYPE = value; } }
        public int CHARACTER_MAXIMUM_LENGTH { get { return _CHARACTER_MAXIMUM_LENGTH; } set { _CHARACTER_MAXIMUM_LENGTH = value; } }
        public int CHARACTER_OCTET_LENGTH { get { return _CHARACTER_OCTET_LENGTH; } set { _CHARACTER_OCTET_LENGTH = value; } }
        public string COLLATION_CATALOG { get { return _COLLATION_CATALOG; } set { _COLLATION_CATALOG = value; } }
        public string COLLATION_SCHEMA { get { return _COLLATION_SCHEMA; } set { _COLLATION_SCHEMA = value; } }
        public string COLLATION_NAME { get { return _COLLATION_NAME; } set { _COLLATION_NAME = value; } }
        public string CHARACTER_SET_CATALOG { get { return _CHARACTER_SET_CATALOG; } set { _CHARACTER_SET_CATALOG = value; } }
        public string CHARACTER_SET_SCHEMA { get { return _CHARACTER_SET_SCHEMA; } set { _CHARACTER_SET_SCHEMA = value; } }
        public string CHARACTER_SET_NAME { get { return _CHARACTER_SET_NAME; } set { _CHARACTER_SET_NAME = value; } }
        public int NUMERIC_PRECISION { get { return _NUMERIC_PRECISION; } set { _NUMERIC_PRECISION = value; } }
        public int NUMERIC_PRECISION_RADIX { get { return _NUMERIC_PRECISION_RADIX; } set { _NUMERIC_PRECISION_RADIX = value; } }
        public int NUMERIC_SCALE { get { return _NUMERIC_SCALE; } set { _NUMERIC_SCALE = value; } }
        public int DATETIME_PRECISION { get { return _DATETIME_PRECISION; } set { _DATETIME_PRECISION = value; } }
        public string INTERVAL_TYPE { get { return _INTERVAL_TYPE; } set { _INTERVAL_TYPE = value; } }
        public int INTERVAL_PRECISION { get { return _INTERVAL_PRECISION; } set { _INTERVAL_PRECISION = value; } }
        public string USER_DEFINED_TYPE_CATALOG { get { return _USER_DEFINED_TYPE_CATALOG; } set { _USER_DEFINED_TYPE_CATALOG = value; } }
        public string USER_DEFINED_TYPE_SCHEMA { get { return _USER_DEFINED_TYPE_SCHEMA; } set { _USER_DEFINED_TYPE_SCHEMA = value; } }
        public string USER_DEFINED_TYPE_NAME { get { return _USER_DEFINED_TYPE_NAME; } set { _USER_DEFINED_TYPE_NAME = value; } }
        public string SCOPE_CATALOG { get { return _SCOPE_CATALOG; } set { _SCOPE_CATALOG = value; } }
        public string SCOPE_SCHEMA { get { return _SCOPE_SCHEMA; } set { _SCOPE_SCHEMA = value; } }
        public string SCOPE_NAME { get { return _SCOPE_NAME; } set { _SCOPE_NAME = value; } }

        #endregion

    }
}
