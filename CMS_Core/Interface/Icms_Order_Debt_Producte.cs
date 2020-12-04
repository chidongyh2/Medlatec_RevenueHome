using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Order_Debt_Producte : IRepository<cms_Order_Debt_Producte>
    {
        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_Order_Debt_Producte> Getcms_Order_Debt_ProducteByStatus(string startdate, string enddate, int ProducerID, int status, int typeKeyword, string keyword);

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="CateItem">Tên nhóm sản phẩm</param>

        /// <returns></returns>        
        List<cms_Order_Debt_Producte> Getcms_Order_Debt_ProducteByProducerID(int ProducerID);

         

    }
}
