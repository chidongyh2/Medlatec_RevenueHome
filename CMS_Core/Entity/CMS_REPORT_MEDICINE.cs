using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
   public class CMS_REPORT_MEDICINE
    {
        public int rownum { get; set; }
        public Int64 MEDICINE_ID { get; set; }
        public string MEDICINE_NAME { get; set; }
        public float Total_Price { get; set; }
       
        public int Count_MEDICIN { get; set; }
    }
}
