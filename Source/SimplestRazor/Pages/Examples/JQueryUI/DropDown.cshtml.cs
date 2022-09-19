using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages.Examples.Bootstrap
{
    public partial class DropDown : Module
    {
        public DropDown()
        {
            Title = "Bootstrap - DropDown";
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
