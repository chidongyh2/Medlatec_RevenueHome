using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICOMPLEMENT_SETTUP
    {
        /// <summary>
        /// Danh sách COMPLEMENT_SETTUP
        /// </summary>      

        /// <returns></returns>        
        List<COMPLEMENT_SETTUP> GetAllCOMPLEMENT_SETTUP();

        /// <summary>
        /// Danh sách COMPLEMENT_SETTUP theo cateid
        /// </summary>      

        /// <returns></returns>        
        List<COMPLEMENT_SETTUP> GetAllCOMPLEMENT_SETTUP_BYCATEID( int cateid);


        /// <summary>
        /// tìm danh sách bổ xung theo ID
        /// </summary>      
        /// <param name="ID">ID complement </param>       
        /// <returns></returns>        
        List<COMPLEMENT_SETTUP> GetAllCOMPLEMENT_SETTUP_ByID(int  ID);


        /// <summary>
        /// tìm danh sách bổ xung theo ID
        /// </summary>      
        /// <param name="FIELD_NAME">Tên complement </param>   
        ///  <param name="CATEGORYS_ID">ID chuyên mục </param>   
        /// <returns></returns>        
        List<COMPLEMENT_SETTUP> GetAllCOMPLEMENT_SETTUP_ByFIELD_NAME(string FIELD_NAME, int CATEGORYS_ID);

        /// <summary>
        /// Chèn dữ liệu COMPLEMENT_SETTUP mới
        /// </summary>      
        /// <param name="_SETTUP">Input insert</param>
        /// <returns></returns>        
        string InsertCOMPLEMENT_SETTUP(COMPLEMENT_SETTUP _SETTUP );

        /// <summary>
        /// Cập nhật dữ liệu cho COMPLEMENT_SETTUP
        /// </summary>      
        /// <param name="_SETTUP">Input update</param>
        /// <returns></returns>        
        string UpdateCOMPLEMENT_SETTUP(COMPLEMENT_SETTUP _SETTUP);


        /// <summary>
        /// xóa dữ liệu COMPLEMENT_SETTUP
        /// </summary>      
        /// <param name="_SETTUP">Input delete</param>
        /// <returns></returns>        
        string DeleteCOMPLEMENT_SETTUP(COMPLEMENT_SETTUP _SETTUP);

        /// <summary>
        /// Xóa dữ liệu COMPLEMENT_SETTUP
        /// </summary>      
        /// <param name="id">ID</param>
        /// <returns></returns>        
        string DeleteCOMPLEMENT_SETTUP(string id);

        /// <summary>
        /// Duyệt dữ liệu nguồn tin
        /// </summary>      
        /// <param name="ControlID">ID chuyên mục</param>
        /// <returns></returns>        
        string PublicCOMPLEMENT_SETTUP(int id);

    }
}
