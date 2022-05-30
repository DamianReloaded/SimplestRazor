using Microsoft.AspNetCore.Mvc;
using Reload.Razor;
namespace SimplestRazor.Pages
{
    public class About : Module
    {
        public About()
        {
            Title = "About";
        }
        public string Caca { get; set; } = "";

        public override PartialViewResult OnGet()
        {
            return View(this);
        }
        public override PartialViewResult OnPost()
        {
            Caca = Page.Request.Form[nameof(Caca)];
            return View(this);
        }
    }
}
