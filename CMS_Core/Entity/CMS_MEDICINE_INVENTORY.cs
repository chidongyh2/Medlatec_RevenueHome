using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
   public class CMS_MEDICINE_INVENTORY
    {
        public int ID { get; set; }
        public String MEDICINE_NAME { get; set; }
        public String MEDICINE_CODE { get; set; }
        public int MEDICINE_ID { get; set; }
        public int STATUS { get; set; }
        public int PARTNERID { get; set; }
        public int INVENTORY { get; set; }
    }
}
