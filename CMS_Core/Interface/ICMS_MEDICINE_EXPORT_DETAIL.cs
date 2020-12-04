using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_MEDICINE_EXPORT_DETAIL
    {
        /// <summary>
        /// danh sách phiếu xuất kho
        /// </summary>      

        /// <returns></returns>        
        List<CMS_MEDICINE_EXPORT_DETAIL> GetCMS_MEDICINE_EXPORT_DETAIL(int partnerid);

        /// <summary>
        /// tìm danh sách phiếu xuất kho theo ID
        /// </summary>      
        /// <param name="Id">ID chuyen muc</param>       
        /// <returns></returns>        
        List<CMS_MEDICINE_EXPORT_DETAIL> GetCMS_MEDICINE_EXPORT_DETAILByID(int Id, int partnerid);

        /// <summary>
        /// lấy danh sách phiếu xuất kho theo mã 
        /// </summary>      
        /// <returns></returns>        
        List<CMS_MEDICINE_EXPORT_DETAIL> GetCMS_MEDICINE_EXPORT_DETAILBySTORE_CODE(string code, int partnerid);





        /// <summary>
        /// Chèn dữ liệu phiếu xuất
        /// </summary>      
        /// <param name="_MEDICINE_EXPORT_DETAIL">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_MEDICINE_EXPORT_DETAIL(CMS_MEDICINE_EXPORT_DETAIL _MEDICINE_EXPORT_DETAIL );


        /// <summary>
        /// Cập nhật dữ liệu cho xuất
        /// </summary>      
        /// <param name="_MEDICINE_EXPORT_DETAIL">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_MEDICINE_RECEIPT_DETAIL(CMS_MEDICINE_EXPORT_DETAIL _MEDICINE_EXPORT_DETAIL);


        /// <summary>
        /// Xóa dữ liệu phiếu xuất thuốc
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string DeleteCMS_MEDICINE_EXPORT_DETAIL(int Id, int partnerid);

        /// <summary>
        /// Xóa dữ liệu phiếu xuất thuốc
        /// </summary>      
        /// <param name="code">ID chuyên mục</param>
        /// <returns></returns>        
        string DeleteCMS_MEDICINE_EXPORT_DETAILBYCODE(string code, int CMS_MEDICINE_EXPORT_STORE_ID, int partnerid);


        /// <summary>
        /// Duyệt dữ liệu phiếu xuất thuốc
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string PUBLICCMS_MEDICINE_RECEIPT_DETAIL(int Id, int partnerid);


    }
}
