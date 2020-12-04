using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_SERVICE_GROUP_CATE
    {
        public Int64 ID { get; set; }
        public int GROUPID { get; set; }
        public int SERVICEID { get; set; }
        public int PARTNERID { get; set; }
        public int VISIT_PATIENT { get; set; }

    }
}
