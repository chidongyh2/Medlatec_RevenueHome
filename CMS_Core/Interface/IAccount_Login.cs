using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface IAccount_Login : IRepository<Account_Login>
    {

        /// <summary>
        /// lấy thông tin login
        /// </summary>      

        /// <returns></returns>        
        List<Account_Login> GetAllAccount_Login();

        /// <summary>
        /// lấy thông tin login account
        /// </summary>      
        /// <param name="Username">Tên account</param>        
        /// <returns></returns>        
        List<Account_Login> GetAccount_LoginByUserName(string Username);

        /// <summary>
        /// lấy thông tin login account
        /// </summary>      
        /// <param name="Username">Tên account</param>        
        /// <returns></returns>        
        List<Account_Login> GetAccount_LoginByUserID(int userid);


        /// <summary>
        /// lấy thông tin login account
        /// </summary>      
        /// <param name="Username">Tên account</param>        
        /// <returns></returns>        
        List<Account_Login> GetAccount_LoginNOKByUserID(int userid);

        /// <summary>
        /// Chèn dữ liệu thông tin login
        /// </summary>      
        /// <param name="account_Login">Input insert</param>
        /// <returns></returns>        
        string InsertAccount_Login(Account_Login account_Login);
 

    }
}
