using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class Location
    {
        public int id { get; set; }

        public string text { get; set; }

        public long? population { get; set; }

        public string flagUrl { get; set; }

        public bool @checked { get; set; }

        public bool hasChildren { get; set; }

        public virtual List<Location> children { get; set; }
    }
}
