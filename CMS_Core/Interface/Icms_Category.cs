using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Category : IRepository<cms_Category>
    {
       
        /// <summary>
        /// lấy danh sách chuyên mục Parent
        /// </summary>      
        /// <returns></returns>        
        List<cms_Category> Getcms_CategoryParent();

        /// <summary>
        /// tìm danh sách chuyên mục theo ID
        /// </summary>      
        /// <param name="cateName">cateName Tên menu</param>       
        /// <returns></returns>        
        List<cms_Category> Getcms_CategoryByCateName(string cateName);



      
    }
}
