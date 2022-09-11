﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reload.Razor;
using SimplestRazor.Pages.Examples.DynamicGrid;
using SimplestRazor.Pages.Examples.DynamicGrid.Data;

namespace SimplestRazor.Pages
{
    [ValidateAntiForgeryToken]
    public class Index : Reload.Razor.MasterModel
    {
        public override Module DetermineModule()
        {
            if (!User.Identity.IsAuthenticated) Response.Redirect("/Error");

            PagePath = Request.Query["r"].ToString() ?? "index";
            switch (PagePath.ToLower())
            {
                case "about": // nameof(About).ToLower()
                    {
                        Module = CreateModule<About>();
                    } break;

                case "examples_dynamicgrid_index":                
                    {
                        Module = CreateModule<Examples_DynamicGrid_Index>();                
                    }
                    break;

                case "examples_dynamicgrid_data_selectall":
                    {
                        Module = CreateModule<Examples_DynamicGrid_Data_SelectAll>();
                    }
                    break;

                default:
                    {
                        Module = CreateModule<Error>();
                    }
                    break;

            }
            return Module;
        }

        public void RenderHeader(IHtmlHelper<Index> html)
        {
            html.RenderPartialAsync("Header");
        }

        public void RenderFooter(IHtmlHelper<Index> html)
        {
            html.RenderPartialAsync("Footer");
        }
    }
}
//return Content("<form method='post'><input id='name' type='text'/><input type='submit'/></form>", "text/HTML", System.Text.Encoding.UTF8);