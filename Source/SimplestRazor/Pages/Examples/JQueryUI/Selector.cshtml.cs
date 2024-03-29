﻿using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages.Examples.Bootstrap
{
    public partial class Selector : Module
    {
        public string DD1 = "";
        public string DD2 = "";
        public string DD3 = "";

        public Selector()
        {
            Title = "Bootstrap - Selector";
        }

        public override PartialViewResult OnGet()
        {
            return View(this);
        }
        public override PartialViewResult OnPost()
        {
            DD1 = Page.Request.Form["DD1"];
            DD2 = Page.Request.Form["DD2"];
            DD3 = Page.Request.Form["DD3"];
            return View(this);
        }
    }

}
