using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reload.Razor.Helpers
{
    public class AccordionParameters
    {
        public string DivId { get; set; } = "AccordionDiv" + System.Guid.NewGuid();
        public string FormAction { get; set; } = "";
        public string Width { get; set; } = "100%";
    }

    public static partial class HtmlHelpers
    {
        public static IHtmlContent DrawAccordion(this IHtmlHelper htmlHelper, DrawGridParameters parameters)
        {
            return new HtmlString(@"
                <div id=""" + parameters.DivId + @""" class=""accordion""/>
                    <div class='accordion-item'>
                        <h2 class='accordion-header' id='headingOne'>
                            <button class='accordion-button' type='button' data-bs-toggle='collapse' data-bs-target='#collapseOne' aria-expanded='true' aria-controls='collapseOne'>
                            Accordion Item #1
                            </button>
                        </h2>
                        <div id='collapseOne' class='accordion-collapse collapse show' aria-labelledby='headingOne' data-bs-parent='#accordionExample'>
                            <div class='accordion-body'>
                            <strong>This is the first item's accordion body.</strong> It is shown by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                            </div>
                        </div>
                    </div>
                    <div class='accordion-item'>
                        <h2 class='accordion-header' id='headingOne2'>
                            <button class='accordion-button' type='button' data-bs-toggle='collapse' data-bs-target='#collapseOne2' aria-expanded='true' aria-controls='collapseOne2'>
                            Accordion Item #1
                            </button>
                        </h2>
                        <div id='collapseOne2' class='accordion-collapse collapse show' aria-labelledby='headingOne' data-bs-parent='#accordionExample'>
                            <div class='accordion-body'>
                            <strong>This is the first item's accordion body.</strong> It is shown by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                            </div>
                        </div>
                    </div>
                </div>
            ");

        }
    }
}

/* 
    [HtmlTargetElement("myhelper")]
    public class MyHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var builder = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("strong");
            builder.InnerHtml.SetContent("Hello World");
            output.Content.SetContent(builder.ToString());
        }
    }

 async Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
        {
            //var content = output.GetChildContentAsync().Result.GetContent();
            var builder = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("strong");
            builder.InnerHtml.SetContent("Hello World");
            output.Content.SetContent(builder.ToString());
            await base.ProcessAsync(context, output);
        }
 */
