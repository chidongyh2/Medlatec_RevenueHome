using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_News_Images
    {
        /// <summary>
        /// Chèn dữ ảnh 
        /// </summary>      
        /// <param name="_News_Images">Input insert</param>
        /// <returns></returns>        
        string Insertcms_News_Images(cms_News_Images _News_Images );

    }
}
