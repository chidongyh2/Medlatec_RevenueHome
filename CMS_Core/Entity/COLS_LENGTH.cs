using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entity
{
    [Serializable]
    public class COLS_LENGTH
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public String COLS_LENGTH_DESC { get; set; }
        public DateTime DATE_CRATE { get; set; }
        public int STATUS { get; set; }
    }
}
