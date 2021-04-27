using Chapter14.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter14.TagHelpers
{
    public class TimersTagHelper:TagHelper
    {
        ITimeService timeService;
        public TimersTagHelper(ITimeService timeServ)
        {
            timeService = timeServ;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent($"Текущее время: {timeService.GetTime()}");
        }
    }
}
