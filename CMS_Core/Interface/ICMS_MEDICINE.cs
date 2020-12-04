using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_MEDICINE
    {
        /// <summary>
        /// danh sách  thuốc
        /// </summary>      

        /// <returns></returns>        
        List<CMS_MEDICINE> GetCMS_MEDICINE(int partnerid);

        /// <summary>
        /// tìm danh sách  thuốc theo ID
        /// </summary>      
        /// <param name="Id">ID chuyen muc</param>       
        /// <returns></returns>        
        List<CMS_MEDICINE> GetCMS_MEDICINEByID(int Id, int partnerid);

        /// <summary>
        /// lấy danh sách nhóm thuốc theo Parent
        /// </summary>      
        /// <returns></returns>        
        List<CMS_MEDICINE> GetCMS_MEDICINEParent(int Parentid,  int partnerid);

        /// <summary>
        /// tìm danh sách tên  thuốc theo tên
        /// </summary>      
        /// <param name="Name">Name Tên chyên mục</param>       
        /// <returns></returns>        
        List<CMS_MEDICINE> GetCMS_MEDICINEByName(string Name, int partnerid);


        /// <summary>
        /// Chèn dữ liệu thuốc
        /// </summary>      
        /// <param name="_MEDICINE">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_MEDICINE(CMS_MEDICINE _MEDICINE);


        /// <summary>
        /// Cập nhật dữ liệu cho thuốc
        /// </summary>      
        /// <param name="_MEDICINE">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_MEDICINE(CMS_MEDICINE _MEDICINE);



        /// <summary>
        /// xóa dữ liệu nhóm thuốc
        /// </summary>      
        /// <param name="_MEDICINE">Input delete</param>
        /// <returns></returns>        
        string DeleteCMS_MEDICINE(CMS_MEDICINE _MEDICINE, int partnerid);

        /// <summary>
        /// Xóa dữ liệu  thuốc
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string DeleteCMS_MEDICINE(int Id, int partnerid);

        /// <summary>
        /// Duyệt dữ liệu  thuốc
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string PUBLICCMS_MEDICINE(int Id, int partnerid);

    }
}
