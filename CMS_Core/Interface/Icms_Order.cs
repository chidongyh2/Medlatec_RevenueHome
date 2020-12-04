using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Order : IRepository<cms_Order>
    {
        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_Order> Getcms_OrderByStatus(string startdate, string enddate,int   CustomerType, int userid, int typeKeyword, string keyword);

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="CateItem">Tên nhóm sản phẩm</param>

        /// <returns></returns>        
        cms_Order Getcms_OrderByName(string CustomerName, string CustomerMobile, string CustomerEmail);

    }
}
