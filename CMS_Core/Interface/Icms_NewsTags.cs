using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_NewsTags
    {
        /// <summary>
        /// Danh sách tag
        /// </summary>      

        /// <returns></returns>        
        List<cms_NewsTags> GetAllcms_NewsTags();

        /// <summary>
        /// tìm danh sách tag theo ID
        /// </summary>      
        /// <param name="TagId">TagId  </param>       
        /// <returns></returns>        
        List<cms_NewsTags> Getcms_NewsTagsByID(int TagId);

        /// <summary>
        /// Chèn dữ liệu tag
        /// </summary>      
        /// <param name="_NewsTags">Input insert</param>
        /// <returns></returns>        
        string Insertcms_NewsTags(cms_NewsTags _NewsTags);

        /// <summary>
        /// Cập nhật dữ liệu cho tag
        /// </summary>      
        /// <param name="_NewsTags">Input update</param>
        /// <returns></returns>        
        string Updatecms_NewsTags(cms_NewsTags _NewsTags);


        /// <summary>
        /// xóa dữ liệu tag
        /// </summary>      
        /// <param name="_NewsTags">Input delete</param>
        /// <returns></returns>        
        string Deletecms_NewsTags(cms_NewsTags _NewsTags);

        /// <summary>
        /// Xóa dữ liệu tag
        /// </summary>      
        /// <param name="TagId">ID tag</param>
        /// <returns></returns>        
        string Deletecms_NewsTags(int TagId);

        

    }
}
