using Chapter14.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter14.TagHelpers
{
    public class TimerTagHelper : TagHelper
    {
        public StyleInfo Style { get; set; }
       

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            string style = $"color:{Style.Color};font-size:{Style.FontSize}px;font-family:{Style.FontFamily};";
            output.Attributes.SetAttribute("style", style);
            // элемент перед тегом
            output.PreElement.SetHtmlContent("<h4>Дата и время</h4>");
            // элемент после тега
            output.PostElement.SetHtmlContent($"<div>Дата: {DateTime.Now.ToString("dd/MM/yyyy")}</div>");

            output.Content.SetContent($"Время: {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }
    public class StyleInfo
    {
        public string Color { get; set; }
        public int FontSize { get; set; }
        public string FontFamily { get; set; }
    }
}

