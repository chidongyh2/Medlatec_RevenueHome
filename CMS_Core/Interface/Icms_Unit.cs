using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Unit : IRepository<cms_Unit>
    {

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_Unit> GetByStatus(int status, int typeKeyword, string keyword);

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="UnitName">Tên đơn vị</param>

        /// <returns></returns>        
        cms_Unit GetByName(string UnitName);


    }
}
