using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PATIENTINFO
    {
        /// <summary>
        /// DANH SÁCH bệnh nhân
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PATIENTINFO> GetAllCMS_PATIENTINFO(int partnerid);



        /// <summary>
        /// DANH SÁCH bệnh nhân theo
        /// </summary>      
        /// <param name="viewModel"> thông tin tìm kiếm bệnh nhân</param>       
        /// <returns></returns>        
        List<CMS_PATIENTINFO> GetCMS_PATIENTINFO_ByALL(DateTime start, DateTime end, string keyword, int typeKeyword, int partnerid);


        /// <summary>
        /// Danh sách bệnh nhân theo tên
        /// </summary>      
        /// <param name="PATIENTNAME">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_PATIENTINFO> GetCMS_PARTNERByName(string PATIENTNAME, int partnerid);

        /// <summary>
        /// Danh sách bệnh nhân theo mã bệnh nhân
        /// </summary>      
        /// <param name="PID">Tên account</param>        
        /// <returns></returns>        
        List<CMS_PATIENTINFO> GetCMS_PATIENTINFO_BYID(string PID, int partnerid);


        /// <summary>
        /// Chèn dữ liệu thông tin bệnh nhân
        /// </summary>      
        /// <param name="_PATIENTINFO">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_PATIENTINFO(CMS_PATIENTINFO _PATIENTINFO );




        /// <summary>
        /// Cập nhật dữ liệu cho thông tin bệnh nhân
        /// </summary>      
        /// <param name="_PATIENTINFO">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_PATIENTINFO(CMS_PATIENTINFO _PATIENTINFO);



    }
}
