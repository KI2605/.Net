using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter14.TagHelpers
{
    public class ListTagHelper:TagHelper
    {
        public List<string> Elements { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            string listContent = "";
            foreach(var i in Elements)
            {
                listContent += "<li>" + i + "</li>";
                output.Content.SetHtmlContent(listContent);
            }
        }
    }
}
