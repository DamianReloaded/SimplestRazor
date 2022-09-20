using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reload.Razor.Helpers
{
    namespace Selector
    {
        public class Parameters
        {
            public string Id { get; set; } = "";
            public string ColumnNameId { get; set; } = "Id";
            public string ColumnNameText { get; set; } = "Descripcion";
            public string Title { get; set; } = "Seleccionar";
            public string SearchText { get; set; } = "Buscar...";
            public string CancelText { get; set; } = "Cancelar";
            public string AcceptText { get; set; } = "Seleccionar";
            public string StyleContent { get; set; } = "padding:5px 5px 5px 5px;";
            public string StyleHeader { get; set; } = "margin:0px 0px 2px 0px; padding:0px;font-weight:bold;";
            public string StyleItemList { get; set; } = "height:200px; margin:0px 0px 0px 0px; padding:0px;";
            public string StyleSearch { get; set; } = "margin:0px 0px 3px 0px; width:100%;";
            public string ModalEffect { get; set; } = "fade";
            public string ModalSize { get; set; } = "";
        }
    }

    public static partial class HtmlHelpers
    {
        public static IHtmlContent DrawSelector(this IHtmlHelper htmlHelper, Selector.Parameters p)
        {
            return new HtmlString(@"
                                    <style>
                                        #" + p.Id + @"_olItems .ui-selecting {
                                            background: #FECA40;
                                        }
                                        #" + p.Id + @"_olItems .ui-selected {
                                            background: #F39814;
                                            color: white;
                                        }
                                        .SelectorSearch:focus {
                                            outline: none !important;
                                        }
                                    </style>
                                    <script>
                                        let " + p.Id + @"Obj = null;
                                        jQuery(document).ready(function () {
                                            " + p.Id + @"Obj = new Selector('" + p.Id + @"');
                                            " + p.Id + @"Obj.ColumnNameId = '" + p.ColumnNameId + @"';
                                            " + p.Id + @"Obj.ColumnNameText = '" + p.ColumnNameText + @"';
                                            " + p.Id + @"Obj.Title = '" + p.Title + @"';
                                            " + p.Id + @"Obj.SearchText = '" + p.SearchText + @"';
                                            " + p.Id + @"Obj.CancelText = '" + p.CancelText + @"';
                                            " + p.Id + @"Obj.AcceptText = '" + p.AcceptText + @"';
                                            " + p.Id + @"Obj.StyleContent = '" + p.StyleContent + @"';
                                            " + p.Id + @"Obj.StyleHeader = '" + p.StyleHeader + @"';
                                            " + p.Id + @"Obj.StyleSearch = '" + p.StyleSearch + @"';
                                            " + p.Id + @"Obj.StyleItemList = '" + p.StyleItemList + @"';
                                            " + p.Id + @"Obj.ModalEffect = '" + p.ModalEffect + @"';
                                            " + p.Id + @"Obj.ModalSize = '" + p.ModalSize + @"';
                                            " + p.Id + @"Obj.applyParameters();
                                        });
                                    </script>
                                    <input type='hidden' id='" + p.Id + @"' name='" + p.Id + @"' />
                                    <input type='text' id='" + p.Id + @"_SelectorText' name='" + p.Id + @"_SelectorText' onclick='" + p.Id + @"Obj.show()' readonly />
                                    <div class='modal' id='" + p.Id + @"_SelectorModal' tabindex='-1' role='dialog' aria-labelledby='SelectorModalLabel' aria-hidden='true'>
                                        <div class='modal-dialog' role='document'>
                                            <div id='" + p.Id + @"_Content' class='modal-content' >
                                                <div class='modal-header'>
                                                    <h4 id='" + p.Id + @"_Title' class='modal-title'></h4>
                                                </div>
                                                <div >
                                                    <input type='text' class='SelectorSearch' id='" + p.Id + @"_SearchText' placeholder='' />
                                                    <ol id='" + p.Id + @"_olHeader'></ol>
                                                    <ol id='" + p.Id + @"_olItems'></ol>
                                                    <div class='modal-footer'>
                                                        <button id='" + p.Id + @"_CancelButton' type='button' class='btn btn-secondary' onclick='" + p.Id + @"Obj.cancelSelector()'></button>
                                                        <button id='" + p.Id + @"_AcceptButton' type='button' class='btn btn-success' onclick='" + p.Id + @"Obj.acceptSelector()'></button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

            ");

        }
    }
}
