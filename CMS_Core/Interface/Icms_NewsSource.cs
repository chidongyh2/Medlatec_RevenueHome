using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_NewsSource
    {
        /// <summary>
        /// Danh sách nguồn tin
        /// </summary>      

        /// <returns></returns>        
        List<cms_NewsSource> GetAllcms_NewsSource();

        /// <summary>
        /// tìm danh sách nguồn tin theo ID
        /// </summary>      
        /// <param name="SourceId">SourceId nguồn tin </param>       
        /// <returns></returns>        
        List<cms_NewsSource> Getcms_NewsSourceByID(int SourceId);


        /// <summary>
        /// tìm danh sách nguồn tin theo trạng thái
        /// </summary>      
        /// <param name="SourceStatus">SourceStatus trạng thái </param>       
        /// <returns></returns>        
        List<cms_NewsSource> GetAllcms_NewsSourceByStatus(int SourceStatus);


        /// <summary>
        /// Chèn dữ liệu nguồn tin mới
        /// </summary>      
        /// <param name="_NewsSource">Input insert</param>
        /// <returns></returns>        
        string Insertcms_NewsSource(cms_NewsSource _NewsSource);

        /// <summary>
        /// Cập nhật dữ liệu cho nguồn tin
        /// </summary>      
        /// <param name="_NewsSource">Input update</param>
        /// <returns></returns>        
        string Updatecms_NewsSource(cms_NewsSource _NewsSource);


        /// <summary>
        /// xóa dữ liệu nguồn tin
        /// </summary>      
        /// <param name="_NewsSource">Input delete</param>
        /// <returns></returns>        
        string Deletecms_NewsSource(cms_NewsSource _NewsSource);

        /// <summary>
        /// Xóa dữ liệu nguồn tin
        /// </summary>      
        /// <param name="SourceId">ID chuyên mục</param>
        /// <returns></returns>        
        string Deletecms_NewsSource(int SourceId);

        /// <summary>
        /// Duyệt dữ liệu nguồn tin
        /// </summary>      
        /// <param name="SourceId">ID chuyên mục</param>
        /// <returns></returns>        
        string Publiccms_NewsSource(int SourceId);

    }
}
