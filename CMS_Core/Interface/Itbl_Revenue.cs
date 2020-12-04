using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Itbl_Revenue : IRepository<tbl_Revenue>
    {
        /// <summary>
        /// Gettbl_ResultByUserid
        /// </summary>      
        /// <param name="UserID">danh sách tiền cán bộ tại nhà</param>

        /// <returns></returns>        
        List<tbl_Revenue> Gettbl_RevenueByUserid(string Userid);

        /// <summary>
        /// Gettbl_ResultByUserid
        /// </summary>      
        /// <param name="UserID">danh sách tiền cán bộ tại nhà</param>

        /// <returns></returns>        
        List<tbl_Revenue> Gettbl_RevenueBySID(string SID);

    }
}
