﻿using CMS_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface Icms_debt_Customer : IRepository<cms_debt_Customer>
    {
        /// <summary>
        /// Login
        /// </summary>      
        /// <param name="Username">Tên account</param>
        /// <param name="Password">Tên account</param>
        /// <returns></returns>        
        List<cms_debt_Customer> Getcms_debt_CustomerByStatus(string startdate, string enddate,  int status, int typeKeyword, string keyword);

       

    }
}