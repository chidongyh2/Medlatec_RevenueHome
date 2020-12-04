using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class TYPEDATAINPUT
    {
        public int ID { get; set; }
        public String NAME { get; set; }
        public String TYPEDATAINPUT_DESC { get; set; }
        public DateTime DATE_CREATE { get; set; }
        public int STATUS { get; set; }


    }
}
