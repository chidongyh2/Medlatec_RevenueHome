using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_DEPARTMENT : IRepository<CMS_DEPARTMENT>
    {
        CMS_DEPARTMENT GetName(string DepartmentName, int PARTNERID);
    }
}
