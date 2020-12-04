using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class CMS_TYPE_TEMPLATEPRINT
    {
        public int ID { get; set; }
        public String NAME { get; set; }
        public String DES { get; set; }
        public int STATUS { get; set; }
    }
}
