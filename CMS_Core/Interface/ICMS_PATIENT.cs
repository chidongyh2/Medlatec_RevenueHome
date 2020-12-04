using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PATIENT
    {
        /// <summary>
        /// DANH SÁCH lịch sử khám bệnh nhân
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PATIENT> GetAllCMS_PATIENT(int partnerid);





        /// <summary>
        /// Danh sách bệnh nhân theo tên
        /// </summary>      
        /// <param name="PID">ID bệnh nhân</param>        
        /// <returns></returns>        
        List<CMS_PATIENT> GetCMS_PATIENTByPID(string PID, int partnerid);

        /// <summary>
        /// Tìm lịch sử khám bệnh nhân theo ID
        /// </summary>      
        /// <param name="SID">Tên account</param>        
        /// <returns></returns>        
        List<CMS_PATIENT> GetCMS_PATIENT_BYSID(string SID, int partnerid);


        /// <summary>
        /// Chèn dữ liệu thông tin khám bệnh nhân
        /// </summary>      
        /// <param name="_PATIENT">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_PATIENT(CMS_PATIENT _PATIENT );




        /// <summary>
        /// Cập nhật dữ liệu cho thông tin khám bệnh nhân
        /// </summary>      
        /// <param name="_PATIENT">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_PATIENT(CMS_PATIENT _PATIENT);

    }
}
