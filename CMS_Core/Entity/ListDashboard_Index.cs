using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class ListDashboard_Index
    {

        #region Private Fields  
        private List<Dashboard_Index> _Revenue;
        private List<Dashboard_Index> _PatienInfos;
        private List<Dashboard_Index> _RevenueMedicine;
        private List<Dashboard_Index> _Prescriptions;

        #endregion  
        #region Public Properties  
        public List<Dashboard_Index> Revenue { get { return _Revenue; } set { _Revenue = value; } }
        public List<Dashboard_Index> PatienInfos { get { return _PatienInfos; } set { _PatienInfos = value; } }
        public List<Dashboard_Index> RevenueMedicine { get { return _RevenueMedicine; } set { _RevenueMedicine = value; } }
        public List<Dashboard_Index> Prescriptions { get { return _Prescriptions; } set { _Prescriptions = value; } }
        #endregion

    }
}
