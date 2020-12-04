using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_News_Cate
    {
        /// <summary>
        /// tìm danh sách chuyên mục
        /// </summary>      
        /// <param name="newsId">ID tin bài</param>       
        /// <returns></returns>        
        List<cms_News_Cate> Getcms_CategoryByID(int newsId);

    }
}
