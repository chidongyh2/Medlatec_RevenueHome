using CMS_Core.Entity;
using CMS_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_SERVICE
    {
        /// <summary>
        /// danh sách dịch vụ
        /// </summary>      
        /// <param name="partnerid">ID đối tác</param>    
        /// <returns></returns>        
        List<CMS_SERVICE> GetAllCMS_SERVICE(int partnerid, int partnerUser);

        /// <summary>
        /// tìm danh dịch vụ theo ID
        /// </summary>      
        /// <param name="ID">ID menu</param>       
        /// <returns></returns>        
        List<CMS_SERVICE> GetCMS_SERVICEByID(int ID, int partnerid);


        /// <summary>
        /// tìm danh dịch vụ theo name
        /// </summary>      
        /// <param name="ServiceName">cateName Tên dịch vụ</param>       
        /// <returns></returns>        
        List<CMS_SERVICE> GetCMS_SERVICEByServiceName(string ServiceName, int partnerid);


        /// <summary>
        /// tìm danh dịch vụ theo điều kiện
        /// </summary>      
        /// <param name="SERVICEViewModel">Điều kiện tìm kiếm</param>       
        /// <returns></returns>        
        List<CMS_SERVICE> GetCMS_SERVICEByServiceName(CMS_SERVICEViewModel SERVICEViewModel);


        /// <summary>
        /// Chèn dữ liệu dịch vụ mới
        /// </summary>      
        /// <param name="_SERVICE">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_SERVICE(CMS_SERVICE _SERVICE);





        /// <summary>
        /// Cập nhật dữ liệu cho dịch vụ
        /// </summary>      
        /// <param name="_SERVICE">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_SERVICE(CMS_SERVICE _SERVICE);



        /// <summary>
        /// xóa dữ liệu dịch vụ
        /// </summary>      
        /// <param name="_SERVICE">Input delete</param>
        /// <returns></returns>        
        string DeleteCMS_SERVICE(CMS_SERVICE _SERVICE, int partnerid);

        /// <summary>
        /// Xóa dữ liệu dịch vụ
        /// </summary>      
        /// <param name="ID">ID dịch vụ</param>
        /// <returns></returns>        
        string DeleteCMS_SERVICE(int ID, int partnerid);

        /// <summary>
        /// Duyệt dữ liệu dịch vụ
        /// </summary>      
        /// <param name="ID">ID dịch vụ</param>
        /// <returns></returns>        
        string PublicCMS_SERVICE(int ID, int partnerid);

    }
}
