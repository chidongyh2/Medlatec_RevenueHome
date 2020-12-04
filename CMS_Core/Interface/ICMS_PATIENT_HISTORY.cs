using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PATIENT_HISTORY
    {
        /// <summary>
        /// danh sách tiền sử bệnh
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PATIENT_HISTORY> GetCMS_PATIENT_HISTORY(int partnerid);

        /// <summary>
        /// tìm danh sách tiền sử bệnh theo ID
        /// </summary>      
        /// <param name="Id">ID chuyen muc</param>       
        /// <returns></returns>        
        List<CMS_PATIENT_HISTORY> GetCMS_PATIENT_HISTORYByID(int Id, int partnerid);


        /// <summary>
        /// tìm danh sách tiền sử bệnh theo tên
        /// </summary>      
        /// <param name="Name">Name Tên chyên mục</param>       
        /// <returns></returns>        
        List<CMS_PATIENT_HISTORY> GetCMS_PATIENT_HISTORYByName(string Name, int partnerid);


        /// <summary>
        /// tìm danh sách tiền sử bệnh theo pid (id bệnh nhân)
        /// </summary>      
        /// <param name="pid">ID bệnh nhân</param>    
        /// <param name="partnerid">ID đối tác</param> 
        /// <returns></returns>        
        List<CMS_PATIENT_HISTORY> GetCMS_PATIENT_HISTORYByPID(Int64 pid, int partnerid);


        /// <summary>
        /// Chèn dữ liệu tiền sử bệnh mới
        /// </summary>      
        /// <param name="_PATIENT_ALLERGY">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_PATIENT_HISTORY(CMS_PATIENT_HISTORY _PATIENT_HISTORY);


        /// <summary>
        /// Cập nhật dữ liệu cho tiền sử bệnh
        /// </summary>      
        /// <param name="_PATIENT_ALLERGY">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_PATIENT_HISTORY(CMS_PATIENT_HISTORY _PATIENT_HISTORY);

        /// <summary>
        /// Xóa dữ liệu tiền sử bệnh
        /// </summary>      
        /// <param name="id">ID dị ứng</param>
        /// <returns></returns>        
        string DeleteCMS_PATIENT_HISTORY(int id, int partnerid);


    }
}
