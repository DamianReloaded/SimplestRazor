using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages.Examples.DynamicGrid
{
    public partial class Examples_DynamicGrid_Index : Module
    {
        public string Name { get; set; } = "";

        public Examples_DynamicGrid_Index()
        {
            Title = "Users";
        }

        public override PartialViewResult OnGet()
        {
            return View(this);
        }
        public override PartialViewResult OnPost()
        {
            Name = Page.Request.Form["name"];
            return View(this);
        }
    }

}
