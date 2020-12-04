using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_NewsTypeMessage
    {
        /// <summary>
        /// Danh sách kiểu bài viết
        /// </summary>      

        /// <returns></returns>        
        List<cms_NewsTypeMessage> GetAllcms_NewsTypeMessage();

        /// <summary>
        /// tìm danh sách kiểu bài viết theo ID
        /// </summary>      
        /// <param name="TypeMessageId">TypeMessageId kiểu bài viết </param>       
        /// <returns></returns>        
        List<cms_NewsTypeMessage> Getcms_NewsTypeMessageByID(int TypeMessageId);


        /// <summary>
        /// tìm danh sách kiểu bài viết theo trạng thái
        /// </summary>      
        /// <param name="TypeMessageStatus">SourceStatus trạng thái </param>       
        /// <returns></returns>        
        List<cms_NewsTypeMessage> GetAllcms_NewsTypeMessage(int TypeMessageStatus);


        /// <summary>
        /// Chèn dữ liệu kiểu bài viết
        /// </summary>      
        /// <param name="_NewsTypeMessage">Input insert</param>
        /// <returns></returns>        
        string Insertcms_NewsTypeMessage(cms_NewsTypeMessage _NewsTypeMessage);

        /// <summary>
        /// Cập nhật dữ liệu cho kiểu bài viết
        /// </summary>      
        /// <param name="_NewsTypeMessage">Input update</param>
        /// <returns></returns>        
        string Updatecms_NewsTypeMessage(cms_NewsTypeMessage _NewsTypeMessage);


        /// <summary>
        /// xóa dữ liệu kiểu bài viết
        /// </summary>      
        /// <param name="_NewsTypeMessage">Input delete</param>
        /// <returns></returns>        
        string Deletecms_NewsTypeMessage(cms_NewsTypeMessage _NewsTypeMessage);

        /// <summary>
        /// Xóa dữ liệu kiểu bài viết
        /// </summary>      
        /// <param name="TypeMessageId">ID chuyên mục</param>
        /// <returns></returns>        
        string Deletecms_NewsTypeMessage(int TypeMessageId);

        /// <summary>
        /// Duyệt dữ liệu kiểu bài viết
        /// </summary>      
        /// <param name="TypeMessageId">ID kiểu bài viết</param>
        /// <returns></returns>        
        string Publiccms_NewsTypeMessage(int TypeMessageId);

    }
}
