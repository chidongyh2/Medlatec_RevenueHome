using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface IClassComboBox
    {
        /// <summary>
        /// tìm danh sách dữ liệu cha
        /// </summary>      
        /// <param name="SQL">Câu lệnh</param>       
        /// <returns></returns>        
        List<ClassComboBox> Getcms_CategoryByParent(string SQL, int Parrent, string key);

    }
}
