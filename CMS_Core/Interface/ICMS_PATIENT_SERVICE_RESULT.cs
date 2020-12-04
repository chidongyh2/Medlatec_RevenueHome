using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    
    interface ICMS_PATIENT_SERVICE_RESULT : IRepository<CMS_PATIENT_SERVICE_RESULT>
    {
        /// <summary>
        /// Lấy danh sách kết quả dịch vụ theo SID (ID khám bệnh nhân)
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PATIENT_SERVICE_RESULT> GetCMS_PATIENT_SERVICE_BYSID(Int64 sid, int partnerid);

        /// <summary>
        /// Lấy danh sách kết quả dịch vụ theo ID CMS_PATIENT_SERVICE (ID khám bệnh nhân)
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PATIENT_SERVICE_RESULT> GetCMS_PATIENT_SERVICE_BYCPS_ID(Int64 CPS_ID, int partnerid);


    }
}
