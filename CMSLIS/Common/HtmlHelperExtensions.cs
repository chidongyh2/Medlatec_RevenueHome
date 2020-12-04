using CMS_Core.Entity;
using CMSLIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CMSNEW.Common
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString TextBoxNew(this HtmlHelper<CATEGORYSAddViewModel> htmlHelper, CATEGORYSAddViewModel viewModel, int index)
        {
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("form-group row d-flex align-items-center mb-5");
            var label = new TagBuilder("label");
            label.AddCssClass("col-lg-2 form-control-label d-flex justify-content-lg-end");           
            label.Attributes.Add("for", "vudoan");                      
            var textboxValue = InputExtensions.TextBoxFor(htmlHelper, m => m.COMPLEMENTS[index].FIELD_VALUE, new { @class = "form-control", placeholder = viewModel.COMPLEMENTS[index].PLACEHOLDER, type = "SingleLine" });
            var textboxName = InputExtensions.TextBoxFor(htmlHelper, m => m.COMPLEMENTS[index].FIELD_NAME, new { @class = "checkbox-inline",   type = "hidden" });

            StringBuilder htmlBuilder = new StringBuilder();
            if (viewModel.COMPLEMENTS[index].REQUIREDVALUE == true)
            {
                var span = new TagBuilder("span");
                span.Attributes.Add("class", "required");
                span.SetInnerText("*");
                label.InnerHtml =  htmlHelper.Encode(viewModel.COMPLEMENTS[index].LABEL_NAME) + span.ToString(TagRenderMode.Normal) ;              
            } else
            {
                label.SetInnerText(viewModel.COMPLEMENTS[index].LABEL_NAME);              
            }

            htmlBuilder.Append(label.ToString(TagRenderMode.Normal));            
            htmlBuilder.Append("<div class=\"col-lg-6\">" + textboxValue.ToHtmlString() +"</div>");
            htmlBuilder.Append( textboxName.ToHtmlString()  );

            outerDiv.InnerHtml = htmlBuilder.ToString();
            var html = outerDiv.ToString(TagRenderMode.Normal);
           
            return MvcHtmlString.Create(html);
        }
    }
}