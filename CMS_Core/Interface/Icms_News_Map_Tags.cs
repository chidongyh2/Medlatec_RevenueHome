using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_News_Map_Tags
    {
        /// <summary>
        /// Danh sách tag
        /// </summary>      

        /// <returns></returns>        
        List<cms_News_Map_Tags> GetAllcms_NewsTags();

        /// <summary>
        /// tìm danh sách tag theo ID
        /// </summary>      
        /// <param name="Id">Id  </param>       
        /// <returns></returns>        
        List<cms_News_Map_Tags> Getcms_NewsTagsByID(int Id);

        /// <summary>
        /// Chèn dữ liệu tag
        /// </summary>      
        /// <param name="_News_Map_Tags">Input insert</param>
        /// <returns></returns>        
        string Insertcms_News_Map_Tags(cms_News_Map_Tags _News_Map_Tags);

        /// <summary>
        /// Cập nhật dữ liệu cho tag
        /// </summary>      
        /// <param name="_News_Map_Tags">Input update</param>
        /// <returns></returns>        
        string Updatecms_News_Map_Tags(cms_News_Map_Tags _News_Map_Tags);


        /// <summary>
        /// xóa dữ liệu tag
        /// </summary>      
        /// <param name="_News_Map_Tags">Input delete</param>
        /// <returns></returns>        
        string Deletecms_News_Map_Tags(cms_News_Map_Tags _News_Map_Tags);

        /// <summary>
        /// Xóa dữ liệu tag
        /// </summary>      
        /// <param name="Id">ID map</param>
        /// <returns></returns>        
        string Deletecms_News_Map_Tags(int Id);

    }
}
