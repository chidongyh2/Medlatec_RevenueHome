using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_AccountType : IRepository<cms_AccountType>
    {

        ///// <summary>
        ///// Lấy danh sách loại account
        ///// </summary>      

        ///// <returns></returns>        
        //List<cms_AccountType> GetAllcms_AccountType();


        /// <summary>
        /// Lấy danh sách loại theo AccountTypeId
        /// </summary>      
        /// <param name="AccountTypeId">ID loại account</param>        
        /// <returns></returns>        
        List<cms_AccountType> Getcms_AccountTypeByID(int AccountTypeId);

        /// <summary>
        /// Lấy danh sách loại theo AccountTypeName
        /// </summary>      
        /// <param name="AccountTypeName">Tên loại account</param>        
        /// <returns></returns>        
        List<cms_AccountType> Getcms_AccountTypeByName(string AccountTypeName);

        ///// <summary>
        ///// Lấy danh sách nhóm account bởi  id đối tác
        ///// </summary>      
        ///// <param name="Partnerid">ID đối tác</param>        
        ///// <returns></returns>        
        //List<cms_AccountType> GetCms_AccountTypeByPartnerid(  int Partnerid, int ISADMIN, int created_by);


        ///// <summary>
        ///// Lấy danh sách loại nhóm account theo theo id đối tác
        ///// </summary>      
        ///// <param name="Partnerid">ID đối tác</param>        
        ///// <returns></returns>        
        //List<cms_AccountType> GetCms_AccountTypePartnerid(int Partnerid);


        ///// <summary>
        ///// Chèn dữ liệu loại account mới
        ///// </summary>      
        ///// <param name="_AccountType">Input insert</param>
        ///// <returns></returns>        
        //string Insertcms_AccountType(cms_AccountType _AccountType);

        ///// <summary>
        ///// Cập nhật dữ liệu cho loại account
        ///// </summary>      
        ///// <param name="_AccountType">Input update</param>
        ///// <returns></returns>        
        //string Updatecms_AccountType(cms_AccountType _AccountType);


        ///// <summary>
        ///// xóa dữ liệu loại account
        ///// </summary>      
        ///// <param name="_AccountType">Input delete</param>
        ///// <returns></returns>        
        //string Deletecms_AccountType(cms_AccountType _AccountType);

        ///// <summary>
        ///// Xóa dữ liệu loại account
        ///// </summary>      
        ///// <param name="AccountTypeId">ID loại account</param>
        ///// <returns></returns>        
        //string Deletecms_AccountType(int AccountTypeId);


    }
}
