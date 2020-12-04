using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
   public class CMS_PATIENTINFO_QUEUE
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public int SID { get; set; }
        public String PATIENTINFO_NAME { get; set; }
        public int PATIENTINFO_AGE { get; set; }
        public int LOCATIONID { get; set; }
        public int PATIENTINFO_NUMBER { get; set; }
        public int STATUS { get; set; }
        public int PARTNERID { get; set; }
        public int PATIENTINFO_SEX { get; set; }
        
    }
}
