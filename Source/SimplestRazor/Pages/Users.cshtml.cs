using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages
{
    public class Users : Module
    {
        public string Name { get; set; } = "";

        public Users()
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
