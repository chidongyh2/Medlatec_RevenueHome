using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Customer : IRepository<cms_Customer>
    {
        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_Customer> Getcms_CustomerByStatus(string startdate, string enddate,    int status, int typeKeyword, string keyword);

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="CateItem">Tên nhóm sản phẩm</param>

        /// <returns></returns>        
        cms_Customer Getcms_CustomerByName(string CustomerName, string CustomerMobile, string CustomerEmail);

    }
}
