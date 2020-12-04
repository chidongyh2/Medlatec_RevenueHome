using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ItblReportRevenue : IRepository<tblReportRevenue>
    {
        /// <summary>
        /// tblReportRevenueDelete
        /// </summary>      
        /// <param name="UserID">danh sách tiền cán bộ tại nhà</param>

        /// <returns></returns>        
        string tblReportRevenueDelete(Int64 MaBN, string S_ID, string useridAgree);
    }
}
