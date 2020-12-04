using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
   public class CMS_SERVICE_TYPE
    {
        public int ID { get; set; }
        public String NAME { get; set; }
        public int STATUS { get; set; }
        public String TYPEDESC { get; set; }
        public int CREATEBY { get; set; }
        public DateTime CREATEDATE { get; set; }
        public int UPDATEBY { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public int PARTNERID { get; set; }
    }
}
