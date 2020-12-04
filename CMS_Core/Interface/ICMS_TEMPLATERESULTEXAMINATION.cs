using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_TEMPLATERESULTEXAMINATION :   IRepository<CMS_TEMPLATERESULTEXAMINATION>
    {


        /// <summary>
        /// Lấy các mẫu nhập dữ liệu theo nhóm dịch vụ
        /// </summary>      
        /// <param name="GROUP_SERVICEID">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_TEMPLATERESULTEXAMINATION> GetCMS_TEMPLATERESULTEXAMINATIONByGroupService(int GROUP_SERVICEID, int PARTNERID);


        /// <summary>
        /// Lấy các mẫu nhập dữ liệu theo  dịch vụ
        /// </summary>      
        /// <param name="SERVICEID">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_TEMPLATERESULTEXAMINATION> GetCMS_TEMPLATERESULTEXAMINATIONBySERVICEID(int SERVICEID, int PARTNERID);

    }
}
