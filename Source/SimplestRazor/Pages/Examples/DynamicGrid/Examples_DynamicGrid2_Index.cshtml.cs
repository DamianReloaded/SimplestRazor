using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages.Examples.DynamicGrid
{
    public partial class Examples_DynamicGrid2_Index : Module
    {
        public Examples_DynamicGrid2_Index()
        {
            Title = "Dynamic Grid 2";
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
