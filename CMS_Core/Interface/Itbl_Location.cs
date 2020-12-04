using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Itbl_Location : IRepository<tbl_Location>
    {
        /// <summary>
        /// Gettbl_ResultByUserid
        /// </summary>      
        /// <param name="UserID">danh sách tiền cán bộ tại nhà</param>
        

        /// <returns></returns>        
        List<tbl_Location> Gettbl_LocationByGroupID(string GroupID );
    }
}
