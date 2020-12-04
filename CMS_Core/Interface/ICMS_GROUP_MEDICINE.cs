using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_GROUP_MEDICINE
    {
        /// <summary>
        /// danh sách nhóm thuốc
        /// </summary>      

        /// <returns></returns>        
        List<CMS_GROUP_MEDICINE> GetCMS_GROUP_MEDICINE(int partnerid);

        /// <summary>
        /// tìm danh sách nhóm thuốc theo ID
        /// </summary>      
        /// <param name="Id">ID chuyen muc</param>       
        /// <returns></returns>        
        List<CMS_GROUP_MEDICINE> GetCMS_GROUP_MEDICINEByID(int Id, int partnerid);

        /// <summary>
        /// lấy danh sách nhóm thuốc Parent
        /// </summary>      
        /// <returns></returns>        
        List<CMS_GROUP_MEDICINE> GetCMS_GROUP_MEDICINEParent(int partnerid);

        /// <summary>
        /// tìm danh sách tên nhóm thuốc theo tên
        /// </summary>      
        /// <param name="Name">Name Tên chyên mục</param>       
        /// <returns></returns>        
        List<CMS_GROUP_MEDICINE> GetCMS_GROUP_MEDICINEByName(string Name, int partnerid);


        /// <summary>
        /// Chèn dữ liệu nhóm thuốc
        /// </summary>      
        /// <param name="_GROUP_MEDICINE">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_GROUP_MEDICINE(CMS_GROUP_MEDICINE _GROUP_MEDICINE);


        /// <summary>
        /// Cập nhật dữ liệu cho nhóm thuốc
        /// </summary>      
        /// <param name="_GROUP_MEDICINE">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_GROUP_MEDICINE(CMS_GROUP_MEDICINE _GROUP_MEDICINE);



        /// <summary>
        /// xóa dữ liệu nhóm thuốc
        /// </summary>      
        /// <param name="_GROUP_MEDICINE">Input delete</param>
        /// <returns></returns>        
        string DeleteCMS_GROUP_MEDICINE(CMS_GROUP_MEDICINE _GROUP_MEDICINE, int partnerid);

        /// <summary>
        /// Xóa dữ liệu nhóm thuốc
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string DeleteCMS_GROUP_MEDICINE(int Id, int partnerid);

        /// <summary>
        /// Duyệt dữ liệu nhóm thuốc
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string PUBLICCMS_GROUP_MEDICINE(int Id, int partnerid);


    }
}
