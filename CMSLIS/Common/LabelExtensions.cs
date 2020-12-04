using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSNEW.Common
{
    public static class LabelExtensions
    {
        public static string LabelNew(this HtmlHelper helper, string target, string text)
        {
            return String.Format("<label for='{0}'>{1}</label>", target, text);
        }
    }
}