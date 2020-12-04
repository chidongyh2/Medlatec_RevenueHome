using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_SICK : IRepository<CMS_SICK>
    {

        /// <summary>
        /// DANH SÁCH bệnh
        /// </summary>      

        /// <returns></returns>        
        List<CMS_SICK> GetAll_CMS_SICK_BYSTATUS(int STATUS, int typekeyword, string keyword, int PARTNERID);

        List<CMS_SICK> GetAll_CMS_SICK_BYNAME(string Name, int PARTNERID);
    }
}
