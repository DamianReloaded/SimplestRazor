using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages.Examples.Bootstrap
{
    public partial class Tabs : Module
    {
        public Tabs()
        {
            Title = "Bootstrap - Tabs";
        }

        public override PartialViewResult OnGet()
        {
            return View(this);
        }
        public override PartialViewResult OnPost()
        {
            return View(this);
        }
    }

}
