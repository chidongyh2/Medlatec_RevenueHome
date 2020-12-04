using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PATIENT_SERVICE : IRepository<CMS_PATIENT_SERVICE>
    {
        /// <summary>
        /// Lấy danh sách dịch vụ theo SID (ID khám bệnh nhân)
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PATIENT_SERVICE> GetCMS_PATIENT_SERVICE_BYSID(Int64 sid, int partnerid);

    }
}
