using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PATIENT_PRESCRIPTION : IRepository<CMS_PATIENT_PRESCRIPTION>
    {
        /// <summary>
        /// Lấy danh sách thuốc theo SID (ID khám bệnh nhân)
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PATIENT_PRESCRIPTION> GetCMS_PATIENT_PRESCRIPTION_BYSID(Int64 sid, int partnerid);

        /// <summary>
        /// Lấy danh sách thuốc theo ID CMS_PATIENT_SERVICE (ID khám bệnh nhân)
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PATIENT_PRESCRIPTION> GetCMS_PATIENT_PRESCRIPTION_BYCPS_ID(Int64 CPS_ID, int partnerid);


    }
}
