using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PATIENT_IMAGES : IRepository<CMS_PATIENT_IMAGES>
    {
        /// <summary>
        /// Lấy các mẫu nhập dữ liệu theo nhóm dịch vụ
        /// </summary>      
        /// <param name="GROUP_SERVICEID">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_PATIENT_IMAGES> GetCMS_PATIENT_IMAGESBySID(int SID, int PARTNERID);


        /// <summary>
        /// Lấy các mẫu nhập dữ liệu theo  dịch vụ
        /// </summary>      
        /// <param name="SERVICEID">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_PATIENT_IMAGES> GetCMS_PATIENT_IMAGESByPID(int PID, int PARTNERID);


    }
}
