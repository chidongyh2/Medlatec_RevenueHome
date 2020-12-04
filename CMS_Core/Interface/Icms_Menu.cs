using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Menu : IRepository<cms_Menu>
    {
       

        /// <summary>
        /// tìm menu theo ID
        /// </summary>      
        /// <param name="menId">ID menu</param>       
        /// <returns></returns>        
        List<cms_Menu> Getcms_MenuByID(int menId);

        /// <summary>
        /// lấy menu Parent
        /// </summary>      
        /// <returns></returns>        
        List<cms_Menu> GetAllcms_MenuParent();

        /// <summary>
        /// lấy menu Parent
        /// </summary>      

        /// <returns></returns>        
        List<cms_Menu> GetAllcms_MenuParentByGroupID(int GroupID, int GroupIDUser);


        /// <summary>
        /// lấy menu Parent by Userid
        /// </summary>      
        ///<param name = "UserID" > UserID </param>
        /// <returns></returns>        
        List<cms_Menu> GetAllcms_MenuParentByUserid(int UserID);


        /// <summary>
        /// lấy menu Child 
        /// </summary>      
        ///<param name = "ParentID" > ParentID menu</param>
        /// <returns></returns>        
        List<cms_Menu> GetAllcms_MenuChild(int ParentID);

        /// <summary>
        /// lấy menu Child 
        /// </summary>      
        ///<param name = "ParentID" > ParentID menu</param>
        ///<param name = "status" > status menu</param>
        /// <returns></returns>        
        List<cms_Menu> GetAllcms_MenuChild(int ParentID, int status);



        /// <summary>
        /// lấy menu Child 
        /// </summary>      
        ///<param name = "ParentID" > ParentID menu</param>
        /// <returns></returns>        
        List<cms_Menu> GetAllcms_MenuChildAndGroupID(int ParentID, int GroupID, int GroupIDUser);

        /// <summary>
        /// lấy menu Child 
        /// </summary>      
        ///<param name = "ParentID" > ParentID menu</param>
        ///<param name = "UserID" > UserID </param>
        /// <returns></returns>        
        List<cms_Menu> GetAllcms_MenuChildByUserid(int ParentID, int UserID);



       
 


    }
}
