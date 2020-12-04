using CMS_Core.Entity;
using CMS_Core.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CMS_Core.Common
{
    public static class HtmlHelperExtensions
    {
        private static ILog logError = log4net.LogManager.GetLogger("CMSLISLogError");

        public static IHtmlString TextBoxNew(this HtmlHelper<CategoryDynamicAddViewModel> htmlHelper, CategoryDynamicAddViewModel viewModel, int index)
        {
            try
            {
                var inputName = "CMSLIS_" + Common.getRandom();

                var outerDiv = new TagBuilder("div");
                outerDiv.AddCssClass("form-group");
                var label = new TagBuilder("label");
                label.AddCssClass("control-label col-xs-2 text-bold");
                label.Attributes.Add("for", inputName);

                MvcHtmlString textboxValue;
                //<input class="form-control" data-val="true" data-val-required="The Từ ngày field is required." id="date" name="tungay" placeholder="Từ ngày" type="SingleLine" value="05/04/2019">
                if (string.IsNullOrEmpty(viewModel.SETTUPS[index].TEXTBOX_TYPE))
                {
                    textboxValue = InputExtensions.TextBoxFor(htmlHelper, m => m.SETTUPS[index].FIELD_VALUE, new { @class = viewModel.SETTUPS[index].CLASS, placeholder = viewModel.SETTUPS[index].PLACEHOLDER, type = "SingleLine" });
                }
                else
                {
                    if (viewModel.SETTUPS[index].TEXTBOX_TYPE.ToLower().Equals("datetime"))
                    {
                        textboxValue = InputExtensions.TextBoxFor(htmlHelper, m => m.SETTUPS[index].FIELD_VALUE, new { @class = viewModel.SETTUPS[index].CLASS, placeholder = viewModel.SETTUPS[index].PLACEHOLDER, type = "text", id = "date" });
                    }
                    else
                    {
                        textboxValue = InputExtensions.TextBoxFor(htmlHelper, m => m.SETTUPS[index].FIELD_VALUE, new { @class = viewModel.SETTUPS[index].CLASS, placeholder = viewModel.SETTUPS[index].PLACEHOLDER, type = viewModel.SETTUPS[index].TEXTBOX_TYPE });
                    }
                }


                var textboxName = InputExtensions.TextBoxFor(htmlHelper, m => m.SETTUPS[index].FIELD_NAME, new { @class = "checkbox-inline", type = "hidden" });

                StringBuilder htmlBuilder = new StringBuilder();
                if (viewModel.SETTUPS[index].REQUIREDVALUE == true)
                {
                    var span = new TagBuilder("span");
                    span.Attributes.Add("class", "required");
                    span.SetInnerText("*");
                    label.InnerHtml = htmlHelper.Encode(viewModel.SETTUPS[index].LABEL_NAME) + ":" + span.ToString(TagRenderMode.Normal);
                }
                else
                {
                    label.SetInnerText(viewModel.SETTUPS[index].LABEL_NAME +":");
                }

                htmlBuilder.Append(label.ToString(TagRenderMode.Normal));
                if (viewModel.SETTUPS[index].COLS_LENGTH > 0)
                {
                    if (viewModel.SETTUPS[index].TEXTBOX_TYPE.ToLower().Equals("datetime"))
                    {


                        htmlBuilder.Append("<div class=\"col-xs-" + viewModel.SETTUPS[index].COLS_LENGTH + "\"><div class=\"input-group date\"> <div class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></div>" + textboxValue.ToHtmlString() + "</div>");
                    }
                    else
                    {
                        htmlBuilder.Append("<div class=\"col-xs-" + viewModel.SETTUPS[index].COLS_LENGTH + "\">" + textboxValue.ToHtmlString() + "</div>");
                    }
                }
                else
                {
                    if (viewModel.SETTUPS[index].TEXTBOX_TYPE.ToLower().Equals("datetime"))
                    {
                        htmlBuilder.Append("<div class=\"col-xs-6\"><div class=\"input-group\"> <span class=\"input-group-addon\"><i class=\"la la-calendar\"></i></span>" + textboxValue.ToHtmlString() + "</div></div>");
                        htmlBuilder.Append("<div class=\"col-xs-6\">" + textboxValue.ToHtmlString() + "</div>");
                    }
                    else
                    {
                        htmlBuilder.Append("<div class=\"col-xs-6\">" + textboxValue.ToHtmlString() + "</div>");
                    }
                }

                htmlBuilder.Append(textboxName.ToHtmlString());

                outerDiv.InnerHtml = htmlBuilder.ToString();
                var html = outerDiv.ToString(TagRenderMode.Normal);

                return MvcHtmlString.Create(html);
            }
            catch (Exception ex)
            {
                logError.Info("CheckBoxNew: " + ex.ToString());
                return MvcHtmlString.Create(string.Empty);
            }
        }

        public static IHtmlString TextAreaNew(this HtmlHelper<CategoryDynamicAddViewModel> htmlHelper, CategoryDynamicAddViewModel viewModel, int index)
        {
            try
            {
                var inputName = "CMSLIS_" + Common.getRandom();

                var outerDiv = new TagBuilder("div");
                outerDiv.AddCssClass("form-group");
                var label = new TagBuilder("label");
                label.AddCssClass("control-label col-xs-2 text-bold");
                label.Attributes.Add("for", inputName);

                MvcHtmlString TextAreaValue;

                TextAreaValue = TextAreaExtensions.TextAreaFor(htmlHelper, m => m.SETTUPS[index].FIELD_VALUE, viewModel.SETTUPS[index].ROWS_LENGTH, viewModel.SETTUPS[index].COLS_LENGTH, new { @class = viewModel.SETTUPS[index].CLASS, placeholder = viewModel.SETTUPS[index].PLACEHOLDER });
                var textboxName = InputExtensions.TextBoxFor(htmlHelper, m => m.SETTUPS[index].FIELD_NAME, new { @class = "checkbox-inline", type = "hidden" });

                StringBuilder htmlBuilder = new StringBuilder();
                if (viewModel.SETTUPS[index].REQUIREDVALUE == true)
                {
                    var span = new TagBuilder("span");
                    span.Attributes.Add("class", "required");
                    span.SetInnerText("*");
                    label.InnerHtml = htmlHelper.Encode(viewModel.SETTUPS[index].LABEL_NAME) + ":" + span.ToString(TagRenderMode.Normal);
                }
                else
                {
                    label.SetInnerText(viewModel.SETTUPS[index].LABEL_NAME + ":");
                }

                htmlBuilder.Append(label.ToString(TagRenderMode.Normal));
                if (viewModel.SETTUPS[index].COLS_LENGTH > 0)
                {
                    htmlBuilder.Append("<div class=\"col-xs-" + viewModel.SETTUPS[index].COLS_LENGTH + "\">" + TextAreaValue.ToHtmlString() + "</div>");
                }
                else
                {
                    htmlBuilder.Append("<div class=\"col-xs-8\">" + TextAreaValue.ToHtmlString() + "</div>");
                }

                htmlBuilder.Append(textboxName.ToHtmlString());

                outerDiv.InnerHtml = htmlBuilder.ToString();
                var html = outerDiv.ToString(TagRenderMode.Normal);

                return MvcHtmlString.Create(html);
            }
            catch (Exception ex)
            {
                logError.Info("TextAreaNew: " + ex.ToString());
                return MvcHtmlString.Create(string.Empty);
            }
        }

        public static IHtmlString CheckBoxNew(this HtmlHelper<CategoryDynamicAddViewModel> htmlHelper, CategoryDynamicAddViewModel viewModel, int index)
        {
            try
            {
                var outerDiv = new TagBuilder("div");
                var inputName = "CMSLIS_" + Common.getRandom();
                outerDiv.AddCssClass("form-group");
                var label = new TagBuilder("label");
                label.AddCssClass("control-label col-xs-2 text-bold");
                label.Attributes.Add("for", inputName);

                var CheckBoxValue = InputExtensions.CheckBoxFor(htmlHelper, m => m.SETTUPS[index].FIELD_VALUE_BOOL, new { type = "checkbox" });

                var CheckBoxName = InputExtensions.TextBoxFor(htmlHelper, m => m.SETTUPS[index].FIELD_NAME, new { @class = "checkbox-inline", type = "hidden" });
                StringBuilder htmlBuilder = new StringBuilder();
                label.SetInnerText(viewModel.SETTUPS[index].LABEL_NAME + ":");


                htmlBuilder.Append(label.ToString(TagRenderMode.Normal));
                htmlBuilder.Append("<div class=\"col-xs-6\">" + CheckBoxValue.ToHtmlString() + "</div>");
                htmlBuilder.Append(CheckBoxName.ToHtmlString());

                outerDiv.InnerHtml = htmlBuilder.ToString();
                var html = outerDiv.ToString(TagRenderMode.Normal);

                return MvcHtmlString.Create(html);
            }
            catch (Exception ex)
            {
                logError.Info("CheckBoxNew: " + ex.ToString());
                return MvcHtmlString.Create(string.Empty);
            }
        }

      
        public static IHtmlString DropDownListNew(this HtmlHelper<CategoryDynamicAddViewModel> htmlHelper, CategoryDynamicAddViewModel viewModel, int index)
        {
            try
            {
                var outerDiv = new TagBuilder("div");
                var inputName = "CMSLIS_" + Common.getRandom();
                outerDiv.AddCssClass("form-group");
                var label = new TagBuilder("label");
                label.AddCssClass("control-label col-xs-2 text-bold");
                label.Attributes.Add("for", inputName);
               
                ComboBoxFinal<ClassComboBox> comboBoxFinal = new ComboBoxFinal<ClassComboBox>();
                List<SelectListItem> list = null;
                if (!string.IsNullOrEmpty(viewModel.SETTUPS[index].FIELD_VALUE))
                {
                    list = comboBoxFinal.GetComboBoxBySelected(viewModel.SETTUPS[index].SQL, "idfield", "namefield", viewModel.SETTUPS[index].FIELD_VALUE, true);
                }
                else
                {
                    list = comboBoxFinal.GetComboBox(viewModel.SETTUPS[index].SQL, "idfield", "namefield", true);
                }
                // set load data child
                string sql = string.Empty;
                string KeyDecrypt = AES.CreateKey(9);
                if (!string.IsNullOrEmpty(viewModel.SETTUPS[index].SQLCHILD))
                {                   
                    sql = AES.EncryptString(viewModel.SETTUPS[index].SQLCHILD, KeyDecrypt);
                }


                MvcHtmlString DropDownList ;
                if (!string.IsNullOrEmpty(sql) && !string.IsNullOrEmpty(viewModel.SETTUPS[index].CHILDID))
                {
                    DropDownList = SelectExtensions.DropDownListFor(htmlHelper, m => m.SETTUPS[index].FIELD_VALUE, list, new { @class = viewModel.SETTUPS[index].CLASS, id = viewModel.SETTUPS[index].FIELD_NAME, onchange = "SelectedValue(this,'" + sql +"','" + viewModel.SETTUPS[index].CHILDID+"','"+ KeyDecrypt.Substring(14)  + "')" });
                } else
                {
                    DropDownList = SelectExtensions.DropDownListFor(htmlHelper, m => m.SETTUPS[index].FIELD_VALUE, list, new { @class = viewModel.SETTUPS[index].CLASS, id = viewModel.SETTUPS[index].FIELD_NAME });
                }

                var CheckBoxName = InputExtensions.TextBoxFor(htmlHelper, m => m.SETTUPS[index].FIELD_NAME, new { @class = "checkbox-inline", type = "hidden" });
                StringBuilder htmlBuilder = new StringBuilder();
                label.SetInnerText(viewModel.SETTUPS[index].LABEL_NAME +":");


                htmlBuilder.Append(label.ToString(TagRenderMode.Normal));
                if (viewModel.SETTUPS[index].COLS_LENGTH > 0)
                {
                    htmlBuilder.Append("<div class=\"col-xs-" + viewModel.SETTUPS[index].COLS_LENGTH + "\">" + DropDownList.ToHtmlString() + "</div>");
                }
                else
                {
                    htmlBuilder.Append("<div class=\"col-xs-4\">" + DropDownList.ToHtmlString() + "</div>");
                }


                htmlBuilder.Append(CheckBoxName.ToHtmlString());

                outerDiv.InnerHtml = htmlBuilder.ToString();
                var html = outerDiv.ToString(TagRenderMode.Normal);

                return MvcHtmlString.Create(html);
            }
            catch (Exception ex)
            {
                logError.Info("DropDownListNew: " + ex.ToString());
                return MvcHtmlString.Create(string.Empty);
            }
        }


        //public static IHtmlString CheckBoxListNew(this HtmlHelper<CATEGORYSAddViewModel> htmlHelper, CATEGORYSAddViewModel viewModel, int index)
        //{
        //    try
        //    {
        //        var outerDiv = new TagBuilder("div");
        //        var inputName = "CMSLIS_" + Common.getRandom();
        //        outerDiv.AddCssClass("form-group row d-flex align-items-center mb-5");
        //        var label = new TagBuilder("label");
        //        label.AddCssClass("col-xs-2 form-control-label d-flex justify-content-lg-end");
        //        label.Attributes.Add("for", inputName);

        //        ComboBoxFinal<ClassComboBox> comboBoxFinal = new ComboBoxFinal<ClassComboBox>();
        //        List<SelectListItem> list = null;
        //        if (!string.IsNullOrEmpty(viewModel.SETTUPS[index].FIELD_VALUE))
        //        {
        //            list = comboBoxFinal.GetComboBoxBySelected(viewModel.SETTUPS[index].SQL, "idfield", "namefield", viewModel.SETTUPS[index].FIELD_VALUE, true);
        //        }
        //        else
        //        {
        //            list = comboBoxFinal.GetComboBox(viewModel.SETTUPS[index].SQL, "idfield", "namefield", true);
        //        }


        //        var DropDownList =   SelectExtensions.DropDownListFor(htmlHelper, m => m.SETTUPS[index].FIELD_VALUE, list, new { @class = viewModel.SETTUPS[index].CLASS });
                

        //        var CheckBoxName = InputExtensions.TextBoxFor(htmlHelper, m => m.SETTUPS[index].FIELD_NAME, new { @class = "checkbox-inline", type = "hidden" });
        //        StringBuilder htmlBuilder = new StringBuilder();
        //        label.SetInnerText(viewModel.SETTUPS[index].LABEL_NAME);


        //        htmlBuilder.Append(label.ToString(TagRenderMode.Normal));
        //        htmlBuilder.Append("<div class=\"col-xs-6\">" + DropDownList.ToHtmlString() + "</div>");
        //        htmlBuilder.Append(CheckBoxName.ToHtmlString());

        //        outerDiv.InnerHtml = htmlBuilder.ToString();
        //        var html = outerDiv.ToString(TagRenderMode.Normal);

        //        return MvcHtmlString.Create(html);
        //    }
        //    catch (Exception ex)
        //    {
        //        logError.Info("DropDownListNew: " + ex.ToString());
        //        return MvcHtmlString.Create(string.Empty);
        //    }
        //}




    }
}
