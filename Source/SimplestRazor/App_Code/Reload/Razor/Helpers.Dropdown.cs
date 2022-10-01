using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Reload.Razor.Helpers
{
    namespace Dropdown
    {
        public class Parameters
        {
            public string Id { get; set; } = "";
            public string JsonURL { get; set; } = "/?r=Examples_DynamicGrid_Data_SelectAll";
            public string ColumnNameId { get; set; } = "Id";
            public string ColumnNameText { get; set; } = "Descripcion";
            public string PlaceholderText { get; set; } = "Seleccionar...";
            public string CssClass { get; set; } = "form-select";
            public string SelectedValue { get; set; } = "";
            public bool AddEmptyOption { get; set; } = true;
            public int Size { get; set; } = 1;
            public bool Multiple { get; set; } = false;
        }
    }

    public static partial class HtmlHelpers
    {
        public static IHtmlContent DrawDropdown(this IHtmlHelper htmlHelper, Dropdown.Parameters p)
        {
            string multiple = p.Multiple ? "multiple = 'multiple'" : "";
            return new HtmlString(@"
                                    <script>
                                        let " + p.Id + @"Obj = null;
                                        jQuery(document).ready(function () {
                                            " + p.Id + @"Obj = new ReloadDropdown('" + p.Id + @"');
                                            " + p.Id + @"Obj.JsonURL = '" + p.JsonURL + @"';
                                            " + p.Id + @"Obj.ColumnNameId = '" + p.ColumnNameId + @"';
                                            " + p.Id + @"Obj.ColumnNameText = '" + p.ColumnNameText + @"';
                                            " + p.Id + @"Obj.PlaceholderText = '" + p.PlaceholderText + @"';
                                            " + p.Id + @"Obj.SelectedValue = '" + p.SelectedValue + @"';
                                            " + p.Id + @"Obj.AddEmptyOption = " + p.AddEmptyOption.ToString().ToLower() + @";
                                            " + p.Id + @"Obj.applyParameters();
                                        });
                                    </script>
                                    <select id='" + p.Id + @"' name='" + p.Id + @"' class='"+ p.CssClass + @"' aria-label='form-select-lg example' size=" + p.Size + @" "+ multiple + @"></select>
            ");

        }
    }
}
