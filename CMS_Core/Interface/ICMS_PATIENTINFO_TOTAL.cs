using CMS_Core.Entity;
using CMS_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface ICMS_PATIENTINFO_TOTAL
    {
        /// <summary>
        /// tìm thông tin bệnh nhân theo ID
        /// </summary>      
        /// <param name="Id">ID ID bệnh nhân</param>       
        /// <returns></returns>        
        List<CMS_PATIENTINFO_TOTAL> GetCMS_PATIENTINFO_TOTALByID(int Id, int partnerid);


        /// <summary>
        /// tìm thông tin bệnh nhân theo
        /// </summary>      
        /// <param name="viewModel"> thông tin tìm kiếm bệnh nhân</param>       
        /// <returns></returns>        
        List<CMS_PATIENTINFO_TOTAL> GetCMS_PATIENTINFO_TOTALByALL(DateTime start, DateTime end, string keyword, int typeKeyword, int partnerid);


    }
}
