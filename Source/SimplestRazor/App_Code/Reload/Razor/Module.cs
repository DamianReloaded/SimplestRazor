using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Reload.Razor
{
    public class Module
    {
        public PageModel Page { get; set; }
        public string Title { get; set; }
        public PartialViewResult View<T>(T module)
        {
            var viewName = module.GetType().Name;
            var pvr = Page.Partial(viewName, Page);
            return pvr;
        }
        public PartialViewResult View(string viewName)
        {
            var pvr = new PartialViewResult();
            pvr.ViewName = viewName;
            pvr.ViewData = Page.ViewData;
            pvr.ViewData.Add("Title", Title);
            return pvr;
        }

        public virtual PartialViewResult OnGet() { return View(""); }
        public virtual PartialViewResult OnPost() { return View(""); }
    }
}
