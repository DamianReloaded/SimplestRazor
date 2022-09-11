using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reload.Razor;
using System.Data;


namespace SimplestRazor.Pages.Examples.DynamicGrid.Data
{
    public class Examples_DynamicGrid_Data_SelectAll : Module
    {
        public Examples_DynamicGrid_Data_SelectAll()
        {

        }
        public DataTable getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Rows.Add(1, "Satinder Singh", "Bsc Com Sci", "Mumbai");
            dt.Rows.Add(2, "Amit Sarna", "Mstr Com Sci", "Mumbai");
            dt.Rows.Add(3, "Andrea Ely", "Bsc Bio-Chemistry", "Queensland");
            dt.Rows.Add(4, "Leslie Mac", "MSC", "Town-ville");
            dt.Rows.Add(5, "Vaibhav Adhyapak", "MBA", "New Delhi");
            dt.Rows.Add(6, "Rabit Roger", "AFD", "Cartoon");

            return dt;
        }

        public HtmlString DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return new HtmlString(JSONString);
        }

        public HtmlString Output()
        {
            return DataTableToJSONWithJSONNet(getData());
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
