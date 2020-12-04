using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_SERVICE_GROUP
    {
        /// <summary>
        /// danh sách nhóm dịch vụ
        /// </summary>      
        /// <param name="partnerid">ID đối tác</param>    
        /// <returns></returns>        
        List<CMS_SERVICE_GROUP> GetAllCMS_SERVICE_GROUP(int partnerid, int partnerUser);

        /// <summary>
        /// tìm nhóm dịch vụ theo ID
        /// </summary>      
        /// <param name="ID">ID menu</param>       
        /// <returns></returns>        
        List<CMS_SERVICE_GROUP> GetCMS_SERVICE_GROUPByID(int ID, int partnerid);


        /// <summary>
        /// tìm nhóm dịch vụ theo name
        /// </summary>      
        /// <param name="SERVICE_GROUP_NAME">cateName Tên dịch vụ</param>       
        /// <returns></returns>        
        List<CMS_SERVICE_GROUP> GetCMS_SERVICE_GROUPBySERVICE_GROUP_NAME(string SERVICE_GROUP_NAME, int partnerid);

        /// <summary>
        /// Chèn dữ liệu nhóm dịch vụ mới
        /// </summary>      
        /// <param name="_SERVICE">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_SERVICE_GROUP(CMS_SERVICE_GROUP _SERVICE_GROUP );

        /// <summary>
        /// Cập nhật dữ liệu cho nhóm dịch vụ
        /// </summary>      
        /// <param name="_SERVICE">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_SERVICE_GROUP(CMS_SERVICE_GROUP _SERVICE_GROUP);


        /// <summary>
        /// xóa dữ liệu nhóm dịch vụ
        /// </summary>      
        /// <param name="_SERVICE">Input delete</param>
        /// <returns></returns>        
        string DeleteCMS_SERVICE_GROUP(CMS_SERVICE_GROUP _SERVICE_GROUP, int partnerid);

        /// <summary>
        /// Xóa dữ liệu nhóm dịch vụ
        /// </summary>      
        /// <param name="ID">ID dịch vụ</param>
        /// <returns></returns>        
        string DeleteCMS_SERVICE_GROUP(int ID, int partnerid);

        /// <summary>
        /// Duyệt dữ liệu nhóm dịch vụ
        /// </summary>      
        /// <param name="ID">ID dịch vụ</param>
        /// <returns></returns>        
        string PublicCMS_SERVICE_GROUP(int ID, int partnerid);

    }
}
