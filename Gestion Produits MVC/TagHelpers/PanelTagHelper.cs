using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Produits_MVC.TagHelpers
{
    [HtmlTargetElement("div",Attributes = "panel-type")]
    public class PanelTagHelper:TagHelper
    {
        public enum PanelTypesEnum
        {
            Default,
            Primary,
            Success,
            Info,
            Warning,
            Danger
        }
        [HtmlAttributeName("panel-type")]
        public PanelTypesEnum PanelType { get; set; }
        [HtmlAttributeName("header")]
        public string Header { get; set; }
        [HtmlAttributeName("body")]
        public string Body { get; set; }
        [HtmlAttributeName("footer")]
        public string Footer { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = $@"<div class='panel-heading'>{Header}</div>
                            <div class='panel-body'>{Body}</div>
                            <div class='panel-footer'>{Footer}</div>";
            output.Attributes.SetAttribute("class", $"panel panel-" + PanelType.ToString().ToLowerInvariant());
            output.Content.AppendHtml(content);
            base.Process(context, output);
        }
    }
}
