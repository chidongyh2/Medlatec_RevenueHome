using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Itbl_Patient : IRepository<tbl_Patient>
    {


        /// <summary>
        /// Gettbl_PatientByAll
        /// </summary>      
        /// <param name="Username">Danh sách tiền cán bộ</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<tblReportRevenue> Gettbl_PatientByAll( string Groupid, string Locationid, string userid, int typeKeyword, string keyword);

        /// <summary>
        /// Gettbl_PatientByAll
        /// </summary>      
        /// <param name="Username">Danh sách tiền cán bộ nợ</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<tblReportRevenue> Gettbl_PatientByAllPay(string startdate, string enddate, int Payment, string userid, int typeKeyword, string keyword);


        /// <summary>
        /// Gettbl_PatientByUserid
        /// </summary>      
        /// <param name="CateItem">danh sách tiền cán bộ tại nhà</param>

        /// <returns></returns>        
        List<tblReportRevenue> Gettbl_PatientByUserid(string UserID, int typeKeyword, string keyword);

        /// <summary>
        /// Gettbl_PatientByUserid
        /// </summary>      
        /// <param name="CateItem">danh sách tiền cán bộ tại nhà</param>

        /// <returns></returns>        
        List<tblReportRevenue> Gettbl_PatientByUseridPay(string startdate, string enddate, int Payment, string UserID, int typeKeyword, string keyword);

    }
}
