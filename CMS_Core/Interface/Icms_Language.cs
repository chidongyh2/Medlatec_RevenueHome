using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_Language
    {
        /// <summary>
        /// lấy danh sách ngôn ngữ
        /// </summary>    
        /// <param name="LanguageStatus">Trạng thái </param> 
        /// <returns></returns>        
        List<cms_Language> Getcms_LanguageAll(int LanguageStatus);


    }
}
