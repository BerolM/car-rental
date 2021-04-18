using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace WebApp.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("message-box")]
    public class MessageTagHelper : TagHelper
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "message-box";
            output.TagMode = TagMode.StartTagAndEndTag;

            StringBuilder messageContent = new StringBuilder();
            messageContent.AppendFormat($"<div class='alert alert-{(IsSuccess ? "success":"danger")} alert-dismissible fade show' role='alert'>");
            messageContent.AppendFormat(Message);
            messageContent.AppendFormat("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            messageContent.AppendFormat("</div>");

            output.PreContent.SetHtmlContent(messageContent.ToString());
        }
        /*
        <div class="alert alert-@(response.IsSuccess ? "success":"danger") alert-dismissible fade show" role="alert">
           @response.Message
           <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>
        </div>
        */
    }
}
