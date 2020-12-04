using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface IAccount_LogAction
    {
        /// <summary>
        /// lấy thông tin login
        /// </summary>      

        /// <returns></returns>        
        List<Account_LogAction> GetAllAccount_LogAction();

        /// <summary>
        /// lấy thông tin login account action
        /// </summary>      
        /// <param name="Username">Tên account</param>        
        /// <returns></returns>        
        List<Account_LogAction> GetAccount_LogAction(string Username);

        /// <summary>
        /// Chèn dữ liệu thông tin login
        /// </summary>      
        /// <param name="account_LogAction">Input insert</param>
        /// <returns></returns>        
        string InsertAccount_LogAction(Account_LogAction account_LogAction);

    }
}
