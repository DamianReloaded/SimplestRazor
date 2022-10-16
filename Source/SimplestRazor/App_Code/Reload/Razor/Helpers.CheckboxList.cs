using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reload.Razor.Helpers
{
    namespace CheckboxList
    {
        public class Parameters
        {
            public string Id { get; set; } = "";
            public string ColumnNameId { get; set; } = "Id";
            public string JsonURL { get; set; } = "";
            public string JsonData { get; set; } = "[]";
            public string JsonCheckedData { get; set; } = "[]";
            public string JsonCheckedURL { get; set; } = "";
            public string Width { get; set; } = "100%";
            public string Height { get; set; } = "100%";
            public bool ShowCheckboxes { get; set; } = true;
            public bool ShowHeader { get; set; } = true;
            public string TextboxSearchId { get; set; } = "";
            public string HiddenColumns { get; set; } = "[]";
            public string BorderStyle { get; set; } = "border:solid;border-width:1px;";
        }
    }

    public static partial class HtmlHelpers
    {
        public static IHtmlContent DrawCheckboxList(this IHtmlHelper htmlHelper, CheckboxList.Parameters p)
        {
            return new HtmlString(@"
                                    <script>
                                        let " + p.Id + @"Obj = null;
                                            jQuery(document).ready(function () {
                                            " + p.Id + @"Obj = new CheckboxList('" + p.Id + @"');
                                            " + p.Id + @"Obj.ColumnNameId = '" + p.ColumnNameId + @"';
                                            " + p.Id + @"Obj.JsonURL = '" + p.JsonURL + @"';
                                            " + p.Id + @"Obj.JsonData = '" + p.JsonData + @"';
                                            " + p.Id + @"Obj.JsonCheckedData = '" + p.JsonCheckedData + @"';
                                            " + p.Id + @"Obj.JsonCheckedURL = '" + p.JsonCheckedURL + @"';
                                            " + p.Id + @"Obj.ShowCheckboxes = " + p.ShowCheckboxes.ToString().ToLower() + @";
                                            " + p.Id + @"Obj.ShowHeader = " + p.ShowHeader.ToString().ToLower() + @";
                                            " + p.Id + @"Obj.HiddenColumns = '" + p.HiddenColumns + @"';
                                            " + p.Id + @"Obj.TextboxSearchId = '" + p.TextboxSearchId + @"';
                                            " + p.Id + @"Obj.applyParameters();
                                        });
                                    </script>
                                    <div style=""width: calc(" + p.Width + @" + 2px);"+p.BorderStyle+ @""">
                                        <div id=""" + p.Id + @"_Rectangle"" class=""gridfix-rectangle"" style=""top:1px;left:1px;height:1px;width: calc(" + p.Width + @" - 2px)"">&nbsp</div>
                                        <div id=""" + p.Id + @"_Div1"" class=""gridfix gridfix-excel-mode"" data-name="""" data-id=""0"" style=""width:" + p.Width + @";"">
                                            <div id=""" + p.Id + @"_Div2"" class=""gridfix-table"" style=""height:" + p.Height + @";"">
                                                <table id=""" + p.Id + @"_Table"" style="""">
                                                    <thead id=""" + p.Id + @"_THead"" style=""position: sticky; top:0px;"">
                                                    </thead>
                                                    <tbody id=""" + p.Id + @"_TBody"">
                                                    </tbody>
                                                    <tfoot id=""" + p.Id + @"_TFoot"">
                                                    </tfoot>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
            ");
        }
    }
}
