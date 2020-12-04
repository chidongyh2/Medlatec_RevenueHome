using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
   public class PublicCalandar
    {
        public int Sr { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string url { get; set; }
    }
}
