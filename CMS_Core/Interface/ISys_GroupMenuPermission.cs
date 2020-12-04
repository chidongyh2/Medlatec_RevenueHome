using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ISys_GroupMenuPermission
    {

        /// <summary>
        /// Chèn dữ liệu phân quyền menu và nhóm
        /// </summary>      
        /// <param name="_GroupMenuPermission">Input insert</param>
        /// <returns></returns>        
        string InsertSys_GroupMenuPermission(Sys_GroupMenuPermission _GroupMenuPermission);

        
        /// <summary>
        /// xóa dữ liệu phân quyền menu và nhóm
        /// </summary>      
        /// <param name="_GroupMenuPermission">Input delete</param>
        /// <returns></returns>        
        string DeleteSys_GroupMenuPermission(Sys_GroupMenuPermission _GroupMenuPermission);

        

    }
}
