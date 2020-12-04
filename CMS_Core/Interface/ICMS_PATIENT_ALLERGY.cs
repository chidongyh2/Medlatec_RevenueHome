using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PATIENT_ALLERGY
    {
        /// <summary>
        /// danh sách dị ứng
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PATIENT_ALLERGY> GetCMS_PATIENT_ALLERGY(int partnerid);

        /// <summary>
        /// tìm danh sách dị ứng theo ID
        /// </summary>      
        /// <param name="Id">ID chuyen muc</param>       
        /// <returns></returns>        
        List<CMS_PATIENT_ALLERGY> GetCMS_PATIENT_ALLERGYByID(int Id, int partnerid);


        /// <summary>
        /// tìm danh sách dị ứng theo tên
        /// </summary>      
        /// <param name="Name">Name Tên chyên mục</param>       
        /// <returns></returns>        
        List<CMS_PATIENT_ALLERGY> GetCMS_PATIENT_ALLERGYByName(string Name, int partnerid);


        /// <summary>
        /// tìm danh sách dị ứng theo pid (id bệnh nhân)
        /// </summary>      
        /// <param name="pid">ID bệnh nhân</param>    
        /// <param name="partnerid">ID đối tác</param> 
        /// <returns></returns>        
        List<CMS_PATIENT_ALLERGY> GetCMS_PATIENT_ALLERGYByPID(Int64 pid, int partnerid);


        /// <summary>
        /// Chèn dữ liệu dị ứng mới
        /// </summary>      
        /// <param name="_PATIENT_ALLERGY">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_PATIENT_ALLERGY(CMS_PATIENT_ALLERGY _PATIENT_ALLERGY );


        /// <summary>
        /// Cập nhật dữ liệu cho dị ứng
        /// </summary>      
        /// <param name="_PATIENT_ALLERGY">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_PATIENT_ALLERGY(CMS_PATIENT_ALLERGY _PATIENT_ALLERGY);

        /// <summary>
        /// Xóa dữ liệu dị ứng
        /// </summary>      
        /// <param name="id">ID dị ứng</param>
        /// <returns></returns>        
        string DeleteCMS_PATIENT_ALLERGY(int id, int partnerid);


    }
}
