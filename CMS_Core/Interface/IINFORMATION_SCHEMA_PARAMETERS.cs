using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface IINFORMATION_SCHEMA_PARAMETERS
    {
        /// <summary>
        /// Lấy danh sách các biến trong procedure
        /// </summary>      
        /// <param name="ProcedureName">Tên procedure</param>        
        /// <returns></returns>        
        List<INFORMATION_SCHEMA_PARAMETERS> GetINFORMATION_SCHEMA_PARAMETERSByProcedure(string ProcedureName);

    }
}
