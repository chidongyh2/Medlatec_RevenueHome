using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
   public class ImportMaterial
    {

    
            public string OrderCode { get; set; }
            public string MaterialName { get; set; }
            public Double Amount { get; set; }
          
    }

    public class ImportBill
    {


        public string OrderCode { get; set; }
        public string BillNote { get; set; }
        public Double BillTotal { get; set; }

    }

}
