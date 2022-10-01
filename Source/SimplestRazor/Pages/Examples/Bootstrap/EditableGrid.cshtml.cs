using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages.Examples.Bootstrap
{
    public partial class EditableGrid : Module
    {
        public EditableGrid()
        {
            Title = "Bootstrap - EditableGrid";
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
