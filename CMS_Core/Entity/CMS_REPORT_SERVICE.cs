using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_REPORT_SERVICE
    {

        public int rownum { get; set; }
        public Int64 SERVICE_ID { get; set; }
        public string SERVICE_NAME { get; set; }
        public float Total_Price { get; set; }
        public int SERVICETYPE { get; set; }

        public string SERVICETYPE_NAME { get; set; }
        public int Count_Service { get; set; }

        public int SERVICE_GROUP_ID { get; set; }
        public string SERVICE_GROUP_NAME { get; set; }

    }
}
