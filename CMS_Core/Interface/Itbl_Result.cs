using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Itbl_Result : IRepository<tbl_Result>
    {


        /// <summary>
        /// Gettbl_ResultByUserid
        /// </summary>      
        /// <param name="UserID">danh sách tiền cán bộ tại nhà</param>

        /// <returns></returns>        
        List<tbl_Result> Gettbl_ResultByUserid(string Userid, int typeKeyword, string keyword);

        /// <summary>
        /// Gettbl_ResultBySID
        /// </summary>      
        /// <param name="CateItem">danh sách tiền cán bộ tại nhà</param>

        /// <returns></returns>        
        List<VP> Gettbl_ResultBySID(string Userid, string sid, Int64 mabn, int typeKeyword, string keyword);

    }
}
