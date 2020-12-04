using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PARTNER
    {
        /// <summary>
        /// DANH SÁCH ĐỐI TÁC
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PARTNER> GetAllMS_PARTNER();


        /// <summary>
        /// DANH SÁCH ĐỐI TÁC
        /// </summary>      

        /// <returns></returns>        
        List<CMS_PARTNER> GetAllMS_PARTNER_BYSTATUS( int STATUS);


        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="PARTNER_NAME">Tên ĐỐI TÁC</param>        
        /// <returns></returns>        
        List<CMS_PARTNER> GetCMS_PARTNERByName(string PARTNER_NAME);

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="ID">Tên account</param>        
        /// <returns></returns>        
        List<CMS_PARTNER> GetCMS_PARTNER_BYID(string ID);


        /// <summary>
        /// Chèn dữ liệu user mới
        /// </summary>      
        /// <param name="_PARTNER">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_PARTNER(CMS_PARTNER _PARTNER);




        /// <summary>
        /// Cập nhật dữ liệu cho user
        /// </summary>      
        /// <param name="_PARTNER">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_PARTNER(CMS_PARTNER _PARTNER);

        /// <summary>
        /// xóa dữ liệu user
        /// </summary>      
        /// <param name="_PARTNER">Input delete</param>
        /// <returns></returns>        
        string DeleteCMS_PARTNER(CMS_PARTNER _PARTNER);

        /// <summary>
        /// Xóa dữ liệu user
        /// </summary>      
        /// <param name="ID">ID PARTNER</param>
        /// <returns></returns>        
        string DeleteCMS_PARTNER(int ID);

        /// <summary>
        /// Xóa dữ liệu user
        /// </summary>      
        /// <param name="ID">ID PARTNER</param>
        /// <returns></returns>        
        string PUBLILC_CMS_PARTNER(int ID);


    }
}
