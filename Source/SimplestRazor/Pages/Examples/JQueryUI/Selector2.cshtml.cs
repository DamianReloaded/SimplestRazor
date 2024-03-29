﻿
using Microsoft.AspNetCore.Mvc;
using Reload.Razor;

namespace SimplestRazor.Pages.Examples.Bootstrap
{
    public partial class Selector2 : Module
    {
        public Selector2()
        {
            Title = "Bootstrap - Selector";
        }

        public override PartialViewResult OnGet()
        {
            return View(this);
        }
        public override PartialViewResult OnPost()
        {
            var test = Page.Request.Form["check"];
            return View(this);
        }
    }

}
