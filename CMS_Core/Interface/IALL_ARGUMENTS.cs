using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface IALL_ARGUMENTS
    {
        /// <summary>
        /// Lấy danh sách các biến trong procedure
        /// </summary>      
        /// <param name="ProcedureName">Tên procedure</param>        
        /// <returns></returns>        
        List<ALL_ARGUMENTS> GetALL_ARGUMENTSByProcedure(string ProcedureName);

    }
}
