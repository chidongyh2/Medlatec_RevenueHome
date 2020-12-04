using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PATIENTINFO_APPOINTMENT :  IRepository<CMS_PATIENTINFO_APPOINTMENT>
    {
        /// <summary>
        /// DANH SÁCH bệnh nhân đăng ký khám theo điều kiện
        /// </summary>      
        /// <param name="viewModel"> thông tin tìm kiếm bệnh nhân</param>       
        /// <returns></returns>        
        List<CMS_PATIENTINFO_APPOINTMENT> GetCMS_PATIENTINFO_APPOINTMENT_ByALL(DateTime start, DateTime end, string keyword, int typeKeyword, int partnerid);


        /// <summary>
        /// Danh sách bệnh nhân đăng ký khám theo tên
        /// </summary>      
        /// <param name="PATIENTNAME">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_PATIENTINFO_APPOINTMENT> GetCMS_PATIENTINFO_APPOINTMENTByName(string PATIENTNAME, int partnerid);

        /// <summary>
        /// Danh sách bệnh nhân đăng ký khám theo mã bệnh nhân
        /// </summary>      
        /// <param name="PCODE">Tên account</param>        
        /// <returns></returns>        
        List<CMS_PATIENTINFO_APPOINTMENT> GetCMS_PATIENTINFO_APPOINTMENT_BYID(string PCODE, int partnerid);


    }
}
