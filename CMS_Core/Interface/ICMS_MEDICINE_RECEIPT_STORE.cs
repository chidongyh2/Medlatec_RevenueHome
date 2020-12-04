using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_MEDICINE_RECEIPT_STORE
    {
        /// <summary>
        /// danh sách phiếu nhập kho
        /// </summary>      

        /// <returns></returns>        
        List<CMS_MEDICINE_RECEIPT_STORE> GetCMS_MEDICINE_RECEIPT_STORE(int partnerid);

        /// <summary>
        /// tìm danh sách phiếu nhập kho theo ID
        /// </summary>      
        /// <param name="Id">ID chuyen muc</param>       
        /// <returns></returns>        
        List<CMS_MEDICINE_RECEIPT_STORE> GetCMS_MEDICINE_RECEIPT_STOREByID(int Id, int partnerid);

        /// <summary>
        /// lấy danh sách phiếu nhập kho thoe mã 
        /// </summary>      
        /// <returns></returns>        
        List<CMS_MEDICINE_RECEIPT_STORE> GetCMS_MEDICINE_RECEIPT_STOREByCODE(DateTime startdate, DateTime enddate, string code, int partnerid);





        /// <summary>
        /// Chèn dữ liệu phiếu nhập
        /// </summary>      
        /// <param name="_MEDICINE_RECEIPT_STORE">Input insert</param>
        /// <returns></returns>        
        string InsertCMS_MEDICINE_RECEIPT_STORE(CMS_MEDICINE_RECEIPT_STORE _MEDICINE_RECEIPT_STORE );


        /// <summary>
        /// Cập nhật dữ liệu cho nhóm thuốc
        /// </summary>      
        /// <param name="_MEDICINE_RECEIPT_STORE">Input update</param>
        /// <returns></returns>        
        string UpdateCMS_MEDICINE_RECEIPT_STORE(CMS_MEDICINE_RECEIPT_STORE _MEDICINE_RECEIPT_STORE);





        /// <summary>
        /// Xóa dữ liệu phiếu nhập
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string DeleteCMS_MEDICINE_RECEIPT_STORE(int Id, int partnerid);

        /// <summary>
        /// Xóa dữ liệu phiếu nhập
        /// </summary>      
        /// <param name="code">ID chuyên mục</param>
        /// <returns></returns>        
        string DeleteCMS_MEDICINE_RECEIPT_STORE(string code, int partnerid);


        /// <summary>
        /// Duyệt dữ liệu phiếu nhập thuốc
        /// </summary>      
        /// <param name="Id">ID chuyên mục</param>
        /// <returns></returns>        
        string PUBLICCMS_MEDICINE_RECEIPT_STORE(int Id, int partnerid);

    }
}
