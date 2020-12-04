using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_REPORT_SERVICE
    {
        /// <summary>
        /// tìm danh dịch vụ theo ID
        /// </summary>      
        /// <param name="ID">ID menu</param>       
        /// <returns></returns>        
        List<CMS_REPORT_SERVICE> GetREPORT_SERVICE(DateTime start, DateTime end,int DOCTOR_ID, int partnerid);

    }
}
