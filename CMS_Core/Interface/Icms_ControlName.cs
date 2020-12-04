using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_ControlName
    {
        /// <summary>
        /// Danh sách nguồn tin
        /// </summary>      

        /// <returns></returns>        
        List<cms_ControlName> GetAllcms_ControlName();

        /// <summary>
        /// tìm danh sách nguồn tin theo ID
        /// </summary>      
        /// <param name="ControlID">SourceId nguồn tin </param>       
        /// <returns></returns>        
        List<cms_ControlName> Getcms_ControlNameByID(string ControlID);


        /// <summary>
        /// tìm danh sách nguồn tin theo trạng thái
        /// </summary>      
        /// <param name="ControlStatus">ControlStatus trạng thái </param>       
        /// <returns></returns>        
        List<cms_ControlName> GetAllcms_ControlNameByStatus(int ControlStatus);


        /// <summary>
        /// tìm danh sách nguồn tin theo trạng thái
        /// </summary>      
        /// <param name="ControlStatus">ControlStatus trạng thái </param>   
        /// <param name="menID">ID url </param> 
        /// <returns></returns>        
        List<cms_ControlName> GetAllcms_ControlNameByUrl(int ControlStatus, int menID);


        /// <summary>
        /// Chèn dữ liệu control mới
        /// </summary>      
        /// <param name="_ControlName">Input insert</param>
        /// <returns></returns>        
        string Insertcms_ControlName(cms_ControlName _ControlName);

        /// <summary>
        /// Cập nhật dữ liệu cho control
        /// </summary>      
        /// <param name="_ControlName">Input update</param>
        /// <returns></returns>        
        string Updatecms_ControlName(cms_ControlName _ControlName);


        /// <summary>
        /// xóa dữ liệu control
        /// </summary>      
        /// <param name="_ControlName">Input delete</param>
        /// <returns></returns>        
        string Deletecms_ControlName(cms_ControlName _ControlName);

        /// <summary>
        /// Xóa dữ liệu control
        /// </summary>      
        /// <param name="ControlID">Mã controid</param>
        /// <returns></returns>        
        string Deletecms_ControlName(string ControlID);

        /// <summary>
        /// Duyệt dữ liệu nguồn tin
        /// </summary>      
        /// <param name="ControlID">ID chuyên mục</param>
        /// <returns></returns>        
        string Publiccms_ControlName(int ControlID);

    }
}
