using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class ALL_ARGUMENTS
    {
        #region Constructors  
        public ALL_ARGUMENTS() { }
        #endregion
        #region Private Fields  
        private string _object_name;
        private string _argument_name;
        private string _data_type;
        private int _position;
        private string _in_out;
        #endregion
        #region Public Properties  
        public string object_name { get { return _object_name; } set { _object_name = value; } }
        public string argument_name { get { return _argument_name; } set { _argument_name = value; } }
        public string data_type { get { return _data_type; } set { _data_type = value; } }
        public int position { get { return _position; } set { _position = value; } }
        public string in_out { get { return _in_out; } set { _in_out = value; } }

        #endregion

    }
}
