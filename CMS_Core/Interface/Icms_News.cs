using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_News
    {
        /// <summary>
        /// danh sách tin bài
        /// </summary>      

        /// <returns></returns>        
        List<cms_News> GetAllcms_News();

        /// <summary>
        /// danh sách tin bài theo thời gian
        /// </summary>      
        /// <param name="Tungay">Lấy từ ngày </param>
        /// <param name="Denngay">Lấy đên ngày</param>    
        /// <param name="SourceId">ID nguồn</param>   
        /// <param name="ParrenId">ID Chuyên mục</param>
        /// <param name="cateId">ID tiểu mục mục</param>
        /// <param name="newsTypeMessage">ID kiểu bài</param>
        /// <param name="userId">ID người tạo</param>
        /// <param name="status">trạng thái</param>
        /// <returns></returns>        
        List<cms_News> GetAllcms_News(DateTime Tungay, DateTime Denngay, int SourceId, int ParrenId, int cateId, int newsTypeMessage, int userId, int status,int type, string keyword);


        /// <summary>
        /// tìm tin bài  theo ID
        /// </summary>      
        /// <param name="newsId">ID menu</param>       
        /// <returns></returns>        
        List<cms_News> Getcms_NewsByID(int newsId);


        /// <summary>
        /// Chèn dữ liệu tin bài mới
        /// </summary>      
        /// <param name="_News">Input insert</param>
        /// <returns></returns>        
        string Insertcms_News(cms_News _News);

        /// <summary>
        /// Cập nhật dữ liệu cho tin bài
        /// </summary>      
        /// <param name="_News">Input update</param>
        /// <returns></returns>        
        string Updatecms_News(cms_News _News);


        /// <summary>
        /// xóa dữ liệu tin bài
        /// </summary>      
        /// <param name="_News">Input delete</param>
        /// <returns></returns>        
        string Deletecms_News(cms_News _News);

        /// <summary>
        /// Xóa dữ liệu tin bài
        /// </summary>      
        /// <param name="newsId">ID Menu</param>
        /// <returns></returns>        
        string Deletecms_News(int newsId);

        /// <summary>
        /// Duyệt dữ liệu tin bài
        /// </summary>      
        /// <param name="newsId">ID Menu</param>
        /// <returns></returns>        
        string Publiccms_News(int newsId);

    }
}
