using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Material : IRepository<cms_Material>
    {
        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_Material> Getcms_MaterialByStatus(string startdate, string enddate, int MaterialCateID,int MaterialUnit, int ProducerID, int status, int typeKeyword, string keyword);

        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="CateItem">Tên nhóm sản phẩm</param>

        /// <returns></returns>        
        cms_Material Getcms_MaterialByName(string MaterialName, int ProducerID);

    }
}
