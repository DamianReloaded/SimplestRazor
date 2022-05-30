using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Reload.Razor
{
    public class MasterModel : PageModel
    {
        public string PagePath { get; set; } = "";
        public Module? Module { get; set; }

        public IActionResult OnPost()
        {
            return DetermineModule().OnPost();
        }

        public IActionResult OnGet()
        {
            return DetermineModule().OnGet();
        }

        public virtual T CreateModule<T>() where T : Module, new()
        {
            T module = new T();
            module.Page = this;
            return module;
        }

        public virtual Module DetermineModule()
        {
            PagePath = Request.Query["page"].ToString() ?? "index";
            return null;
        }

        public virtual T GetModule<T>() where T : Module
        {
            return Module as T;
        }
    }
}
