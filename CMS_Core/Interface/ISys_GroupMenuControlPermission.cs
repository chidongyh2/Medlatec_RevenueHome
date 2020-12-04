using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ISys_GroupMenuControlPermission
    {
        /// <summary>
        /// Chèn dữ liệu phân quyền menu và nhóm và control
        /// </summary>      
        /// <param name="_GroupMenuControlPermission">Input insert</param>
        /// <returns></returns>        
        string InsertSys_GroupMenuControlPermission(Sys_GroupMenuControlPermission _GroupMenuControlPermission );


        /// <summary>
        /// xóa dữ liệu phân quyền menu và nhóm
        /// </summary>      
        /// <param name="_GroupMenuControlPermission">Input delete</param>
        /// <returns></returns>        
        string DeleteSys_GroupMenuControlPermission(int id, int PARTNERID);

        /// <summary>
        /// tìm danh sách phân quyền theo button
        /// </summary>      
        /// <param name="GroupID">ID nhóm </param>   
        /// <param name="MenLink">Linh menu </param>
        /// <returns></returns>        
        List<Sys_GroupMenuControlPermission> GetSys_GroupMenuControlPermissionByGroupID(int GroupID, string MenLink);

        /// <summary>
        /// tìm danh sách phân quyền theo button
        /// </summary>            
        /// <returns></returns>        
        List<Sys_GroupMenuControlPermission> GetSys_GroupMenuControlPermissionAll();

    }
}
