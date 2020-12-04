using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_MEDICINE_EXPORT_STORE
    {
        /// <summary>
        /// danh sách phiếu xuất kho
        /// </summary>      

        /// <returns></returns>        
        List<CMS_MEDICINE_EXPORT_STORE> GetCMS_MEDICINE_EXPORT_STORE(int partnerid);

        /// <summary>
        /// tìm danh sách phiếu xuất kho theo ID
        /// </summary>      
        /// <param name="Id">ID chuyen muc</param>       
        /// <returns></returns>        
        List<CMS_MEDICINE_EXPORT_STORE> GetCMS_MEDICINE_EXPORT_STOREByID(int Id, int partnerid);

        /// <summary>
        /// lấy danh sách phiếu xuất kho thoe mã 
        /// </summary>      
        /// <returns></returns>        
        List<CMS_MEDICINE_EXPORT_STORE> GetCMS_MEDICINE_EXPORT_STOREByCODE(DateTime startdate, DateTime enddate, string code, int partnerid);





        /// <summary>
        /// Chèn dữ liệu phiếu xuất
        /// </summary>      
        /// <param name="_MEDICINE_RECEIPT_STORE">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_MEDICINE_EXPORT_STORE(CMS_MEDICINE_EXPORT_STORE _MEDICINE_EXPORT_STORE );


        /// <summary>
        /// Cập nhật dữ liệu cho xuất kho
        /// </summary>      
        /// <param name="_MEDICINE_RECEIPT_STORE">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_MEDICINE_EXPORT_STORE(CMS_MEDICINE_EXPORT_STORE _MEDICINE_EXPORT_STORE);


        /// <summary>
        /// Xóa dữ liệu phiếu xuất kho
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string DeleteCMS_MEDICINE_EXPORT_STORE(int Id, int partnerid);

        /// <summary>
        /// Xóa dữ liệu phiếu xuất kho
        /// </summary>      
        /// <param name="code">ID chuyên mục</param>
        /// <returns></returns>        
        string DeleteCMS_MEDICINE_EXPORT_STORE(string code, int partnerid);


        /// <summary>
        /// Duyệt dữ liệu phiếu xuất kho
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string PUBLICCMS_MEDICINE_EXPORT_STORE(int Id, int partnerid);

    }
}
