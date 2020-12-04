using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_TEMPLATEPRINT
    {
        /// <summary>
        /// DANH SÁCH mẫu in
        /// </summary>      

        /// <returns></returns>        
        List<CMS_TEMPLATEPRINT> GetAllCMS_TEMPLATEPRINT(int partnerid);

        /// <summary>
        /// Danh sách mẫu in theo tên
        /// </summary>      
        /// <param name="NAME">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_TEMPLATEPRINT> GetCMS_TEMPLATEPRINTByName(string NAME, int partnerid);

        /// <summary>
        /// Danh sách mẫu in theo id
        /// </summary>      
        /// <param name="ID">Tên account</param>        
        /// <returns></returns>        
        List<CMS_TEMPLATEPRINT> GetCMS_TEMPLATEPRINT_BYID(string ID, int partnerid);


        /// <summary>
        /// Chèn dữ liệu thông tin mẫu in
        /// </summary>      
        /// <param name="_TEMPLATEPRINT">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_TEMPLATEPRINT(CMS_TEMPLATEPRINT _TEMPLATEPRINT);




        /// <summary>
        /// Cập nhật dữ liệu cho thông tin mẫu in
        /// </summary>      
        /// <param name="_TEMPLATEPRINT">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_TEMPLATEPRINT(CMS_TEMPLATEPRINT _TEMPLATEPRINT);
    }
}
