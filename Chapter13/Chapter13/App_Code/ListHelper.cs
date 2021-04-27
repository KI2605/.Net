using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Chapter13.App_Code
{
    public static class ListHelper
    {
        //public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        //{
        //    string result = "<ul>";
        //    foreach (string item in items)
        //    {
        //        result = $"{result}<li>{item}</li>";
        //    }
        //    result = $"{result}</ul>";
        //    return new HtmlString(result);
        //}
        public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (string item in items)
            {
                //В конструктор TagBuilder передается элемент, для которого создается те
                TagBuilder li = new TagBuilder("li");
                // добавляем текст в li
                li.InnerHtml.Append(item); //Свойство InnerHtml позволяет установить или получить содержимое тега в виде строки.
                // добавляем li в ul
                ul.InnerHtml.AppendHtml(li);
            }
            //Свойство Attributes позволяет управлять атрибутами элемента
            ul.Attributes.Add("class", "itemsList");
            var writer = new System.IO.StringWriter();
            ul.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
    public enum TimeOfDay
    {
        [Display(Name = "Утро")]
        Morning,
        [Display(Name = "День")]
        Afternoon,
        [Display(Name = "Вечер")]
        Evening,
        [Display(Name = "Ночь")]
        Night
    }
}
