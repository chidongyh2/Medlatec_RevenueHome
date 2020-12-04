using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Permission
    {
        /// <summary>
        /// Login
        /// </summary>      

        /// <returns></returns>        
        List<cms_Permission> GetAllcms_Permission();
    }
}
