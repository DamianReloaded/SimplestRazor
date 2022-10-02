using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reload.Razor.Helpers
{
    namespace GridFix
    {
        public class Parameters
        {
            public string Id { get; set; } = "";
            public string JsonURL { get; set; } = "";
            public string JsonData { get; set; } = "";
            public string Width { get; set; } = "100%";
            public string Height { get; set; } = "100%";
            public string TextboxSearchId { get; set; } = "";
            public string CommandColumns { get; set; } = @"[
                {
                    ""cssClass"": ""table_button_edit"",
                        ""icon"": ""mdi-pencil"",
                            ""funcName"": ""alert"",
                                ""title"": ""Editar2""
                },
                {
                    ""cssClass"": ""table_button_delete"",
                        ""icon"": ""mdi-trash-can"",
                            ""funcName"": ""alert"",
                                ""title"": ""Eliminar2""
                }
            ]";
            public string HiddenColumns { get; set; } = "[]";
        }
    }

    public static partial class HtmlHelpers
    {
        public static IHtmlContent DrawGridFix(this IHtmlHelper htmlHelper, GridFix.Parameters p)
        {
            return new HtmlString(@"
                                    <script>
                                        let " + p.Id + @"Obj = null;
                                            jQuery(document).ready(function () {
                                            " + p.Id + @"Obj = new GridFix(""" + p.Id + @""");
                                            " + p.Id + @"Obj.JsonURL = """ + p.JsonURL + @""";
                                            " + p.Id + @"Obj.JsonData = '" + p.JsonData + @"';
                                            " + p.Id + @"Obj.HiddenColumns = '" + p.HiddenColumns + @"';
                                            " + p.Id + @"Obj.CommandColumns = `" + p.CommandColumns + @"`;
                                            " + p.Id + @"Obj.TextboxSearchId = '" + p.TextboxSearchId + @"';
                                            " + p.Id + @"Obj.applyParameters();
                                        });
                                    </script>

                                    <div id=""" + p.Id + @"_Rectangle"" class=""gridfix-rectangle"" style=""width:""+p.Width+@"";"">&nbsp</div>
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

                                        <div id=""" + p.Id + @"_DivPager"" class=""gridfix-pager"">
                                            <button id=""" + p.Id + @"_PagerFirst"" type=""button"" onclick=""" + p.Id + @"Obj.goToFirst(this);"">«</button>
                                            <button id=""" + p.Id + @"_PagerPrev"" type=""button"" onclick=""" + p.Id + @"Obj.goToPrev(this);"">‹</button>
                                            <span id=""" + p.Id + @"_PagerPages"">
                                            </span>
                                            <button id=""" + p.Id + @"_PagerNext"" type=""button"" data-page=""2"" onclick=""" + p.Id + @"Obj.goToNext(this);"">›</button>
                                            <button id=""" + p.Id + @"_PagerLast"" type=""button"" data-page=""2"" onclick=""" + p.Id + @"Obj.goToLast(this);"">»</button>
                                            <div class=""gridfix-page-sizes"">
                                                <select class=""gridfix-pager-rows"" onchange=""" + p.Id + @"Obj.setRowsPerPage(this.value);"">
                                                    <option value=""0"">All</option>
                                                    <option value=""2"">2</option>
                                                    <option value=""4"">4</option>
                                                    <option value=""10"">10</option>
                                                    <option value=""20"" selected="""">20</option>
                                                    <option value=""50"">50</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
            ");

        }
    }
}
