using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter14.Models;
namespace Chapter14.TagHelpers
{
    public class UserInfoTagHelper:TagHelper
    {
        public User User { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var content = $@"<p>Имя: <b>{User.Name}</b></p><p>Возраст: <b>{User.Age}</b></p>";
            output.Content.SetHtmlContent(content);
        }
    }
}
