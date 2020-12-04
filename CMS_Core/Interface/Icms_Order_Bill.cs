using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Order_Bill : IRepository<cms_Order_Bill>
    {
        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_Order_Bill> Getcms_Order_BillByStatus(string startdate, string enddate, int Orderid, int status, int typeKeyword, string keyword);

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="CateItem">Tên nhóm sản phẩm</param>

        /// <returns></returns>        
        List<cms_Order_Bill> Getcms_Order_BillByOrderID(int OrderID);

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="CateItem">Tên nhóm sản phẩm</param>

        /// <returns></returns>        
        List<cms_Order_Bill> Getcms_Order_BillByOrderCode(string OrderCode);

        List<cms_Order_Bill> Getcms_Order_BillByCustomerID(int CustomerID);

    }
     
}
