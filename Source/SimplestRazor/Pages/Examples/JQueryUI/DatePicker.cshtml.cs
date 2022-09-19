using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages.Examples.Bootstrap
{
    public partial class DatePicker : Module
    {
        public DatePicker()
        {
            Title = "Bootstrap - DatePicker";
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
