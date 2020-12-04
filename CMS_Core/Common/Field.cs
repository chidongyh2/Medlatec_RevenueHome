using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS_Core.Common
{
   public class Field
    {
        protected string _key = Guid.NewGuid().ToString().Replace("-", "");
        private const string HTMLID = @"^[a-zA-Z][-_\da-zA-Z]*$";

        public  string GetHtmlId()
        {
            string id = "CMSLIS_" + _key;

            if (!Regex.IsMatch(id, HTMLID))
                throw new Exception(
                    "The combination of Form.FieldPrefix + Field.Key does not produce a valid id attribute value for an HTML element. It must begin with a letter and can only contain letters, digits, hyphens, and underscores.");

            return id;
        }
    }
}
