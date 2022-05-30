using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reload.Razor;
namespace SimplestRazor.Pages
{
    [ValidateAntiForgeryToken]
    public class Index : Reload.Razor.MasterModel
    {
        public override Module DetermineModule()
        {
            if (!User.Identity.IsAuthenticated) Response.Redirect("/Error");

            PagePath = Request.Query["page"].ToString() ?? "index";
            if (PagePath.ToLower() == nameof(About).ToLower())
            {
                Module = CreateModule<About>();
            }
            else
            {
                Module = CreateModule<Users>();
            }
            return Module;
        }

        public void RenderHeader(IHtmlHelper<Index> html)
        {
            html.RenderPartialAsync("Header");
        }

        public void RenderFooter(IHtmlHelper<Index> html)
        {
            html.RenderPartialAsync("Footer");
        }
    }
}
//return Content("<form method='post'><input id='name' type='text'/><input type='submit'/></form>", "text/HTML", System.Text.Encoding.UTF8);