using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface IDashboard_Index
    {
        /// <summary>
        /// danh sách menu
        /// </summary>      

        /// <returns></returns>        
        ListDashboard_Index GetDashboard_Index(int PARTNERID);

    }
}
