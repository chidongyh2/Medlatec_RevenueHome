using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Account : IRepository<cms_Account>
    {
       


        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_Account> Getcms_Account(string Username, string Password);


        ///// <summary>
        ///// Login
        ///// </summary>      
        ///// <param name="Username">Tên account</param>
        ///// <param name="Password">Tên account</param>
        ///// <returns></returns>        
        //List<Sys_User> Getcms_Account(string Username, string Password);


        /// <summary>
        /// Changer Password
        /// </summary>      
        /// <param name="uid">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_Account> ChangePasswordCms_Account(int uid, string Password);


        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>        
        /// <returns></returns>        
        List<cms_Account> Getcms_AccountByUserName(string Username);


    }
}
