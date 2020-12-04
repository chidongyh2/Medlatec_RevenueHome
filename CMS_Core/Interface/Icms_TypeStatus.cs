using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_TypeStatus :  IRepository<cms_TypeStatus>
    {
        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_TypeStatus> Getcms_TypeStatusByStatus(int ItemCateItemID, int status, int typeKeyword, string keyword);

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="CateItem">Tên nhóm sản phẩm</param>

        /// <returns></returns>        
        cms_TypeStatus Getcms_TypeStatusByName(string ColorName);

    }
}
