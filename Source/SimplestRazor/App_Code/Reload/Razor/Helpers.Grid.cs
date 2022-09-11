using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reload.Razor.Helpers
{
    public class DrawGridParameters
    {
        public string FormAction { get; set; } = "";
        public string TableWidth { get; set; } = "100%";
        public string Width { get; set; } = "100%";
        public string ColumnDefs { get; set; } = ""; //"{ width : 20, targets : 0, visible : true }"
        public string RowFont { get; set; } = "14px";
        public string ColumnSearchWidths = "['1px']";
    }

    public static partial class HtmlHelpers
    {
        public static IHtmlContent DrawGridPlaceHolder(this IHtmlHelper htmlHelper, DrawGridParameters parameters)
        {
            return new HtmlString(@"<div id=""mainGridDiv"" class=""mainGridDiv""/>");
        }
        public static IHtmlContent DrawGrid(this IHtmlHelper htmlHelper, DrawGridParameters parameters)
        {
            return new HtmlString(@"
                <style>
                    .row
                    {
                        font-size:" + parameters.RowFont + @";
                    }

                    .mainGridDiv
                    {   
                        background: #FFFFFF!important;
                        max-width:" + parameters.Width + @"; margin: 0 auto;
                    }
    
                    .table-striped thead
                    {
                        background: #E8E8E8!important;
                    }

                    .table-striped tfoot
                    {
                        background: #FEFEFE!important;
                    }

                    .table-striped tbody tr:nth-of-type(even) {
                        background: #FEFEFE!important;
                    }

                    .table-striped tbody tr:nth-of-type(odd) {
                        background: #FFFFFF!important;
                    }

                    table.dataTable thead .sorting:after,
                    table.dataTable thead .sorting:before,
                    table.dataTable thead .sorting_asc:after,
                    table.dataTable thead .sorting_asc:before,
                    table.dataTable thead .sorting_asc_disabled:after,
                    table.dataTable thead .sorting_asc_disabled:before,
                    table.dataTable thead .sorting_desc:after,
                    table.dataTable thead .sorting_desc:before,
                    table.dataTable thead .sorting_desc_disabled:after,
                    table.dataTable thead .sorting_desc_disabled:before {
                      bottom: .5em;
                    }

                    .toolbar {
                        float: left;
                    }
                </style>

                <script>
                    function populateTable(data) { 
    
                        var mainGridDiv = document.getElementById('mainGridDiv')
                        if (mainGridDiv) {
                            mainGridDiv.innerHTML = '';
                        }

                        var table = document.createElement('table');
                        table.id = 'mainGridTable';
                        table.className = 'table table-striped table-bordered table-sm';
                        table.width = '" + parameters.TableWidth + @"';
                        mainGridDiv.appendChild(table);

                        var thead = document.createElement('thead');
                        table.appendChild(thead);

                        if (data.length > 0) {
                            var tr = document.createElement('tr');
                            thead.appendChild(tr);

                            // Commands column header
                            {
                                var text1 = document.createTextNode('');
                                var th1 = document.createElement('th');
                                tr.appendChild(th1);
                                th1.appendChild(text1);
                            }

                            var obj = data[0];
                            for (var key in obj) {
                                var text1 = document.createTextNode(key);
                                var th1 = document.createElement('th');
                                tr.appendChild(th1);
                                th1.appendChild(text1);
                            }

                            var tbody = document.createElement('tbody');
                            table.appendChild(tbody);

                            for (var i = 0; i < data.length; i++) {
                                var tr = document.createElement('tr');
                                var obj = data[i];
                                var idx = 0;
                                for (var key in obj) {
                                    var value = obj[key];
                                    if (idx==0)
                                    {
                                        // Commands column buttons
                                        {
                                            // Commands column header
                                            {
                                                var btnAdd = document.createElement('div');
                                                btnAdd.innerHTML = '<div style=""display: flex; margin: 0 auto;width:1px;"" class=""justify-content-center align-items-center""><button type=""button"" title=""Editar"" class=""btn btn-outline-dark d-flex justify-content-center align-items-center"" style=""width:22px;height:19px;margin:0px 1px 0px 0px;""><i class=""bi-pencil"" style=""font-size: 12px;""></i></button><button type=""button"" title=""Eliminar"" class=""btn btn-outline-dark d-flex justify-content-center align-items-center"" style=""width:22px;height:19px;margin:1px;""><i class=""bi-trash"" style=""font-size: 12px;""></i></button></div>';
                                                var th1 = document.createElement('th');
                                                tr.appendChild(th1);
                                                th1.appendChild(btnAdd);
                                            }
                                        }
                                    }
                                    
                                    var td1 = document.createElement('td');
                                    var text1 = document.createTextNode(value);
                                    td1.appendChild(text1);
                                    tr.appendChild(td1);
                                    idx++;
                                }
                                tbody.appendChild(tr);
                            }

                            var tfoot = document.createElement('tfoot');
                            table.appendChild(tfoot);

                            tr = document.createElement('tr');
                            tfoot.appendChild(tr);

                            // Commands column header
                            {
                                var th1 = document.createElement('th');
                                tr.appendChild(th1);
                            }
                            var obj = data[0];
                            for (var key in obj) {
                                var text1 = document.createTextNode(key);
                                var th1 = document.createElement('th');
                                tr.appendChild(th1);
                                th1.appendChild(text1);
                            }

                        } //if (data.length > 0)

                        {
                            var idx=0;
                            $('#mainGridTable tfoot th').each(function () {
                                if (idx>0) {
                                    var title = $(this).text();
                                    $(this).html('<input type=""text"" placeholder="""" style=""border:0;width:100%;"" />');
                                }
                                idx++;
                            });
                        }

                        if (" + parameters.ColumnSearchWidths+ @".length > 0)
                        {
                            var widths = "+ parameters.ColumnSearchWidths + @";
                            var ths = $('#mainGridTable tfoot th');
                            for (var i=0; i<" + parameters.ColumnSearchWidths + @".length; i++)
                            {
                                var title = $(ths[i]).innerText;
                                $(ths[i]).html('<input type=""text"" placeholder="""" style=""border:0;width:'+widths[i]+'"" />');
                            }
                        }

                        $('#mainGridTable').DataTable({
                            dom: '<""toolbar"">frtip',
                            fixedHeader:true,
                            ""scrollX"": true,
                            ""scrollY"": 100,
                            scrollCollapse:true,
                            lengthMenu: [5, 10, 25, 50, -1],
                            ""columnDefs"":[
                                " + parameters.ColumnDefs + @"
                            ],
                            initComplete: function () {
                                // Apply the search
                                this.api()
                                    .columns()
                                    .every(function () {
                                        var that = this;
 
                                        $('input', this.footer()).on('keyup change clear', function () {
                                            if (that.search() !== this.value) {
                                                that.search(this.value).draw();
                                            }
                                        });
                                    });
                            },
                            language: {
                            processing:     ""Procesando..."",
                            search:         ""Buscar:"",
                            lengthMenu:     ""Mostrar _MENU_ items"",
                            info:           ""Mostrando _START_ - _END_ de un total de _TOTAL_ registros"",
                            infoEmpty:      ""No se encontraron resultados"",
                            infoFiltered:   "" buscando entre un total de _MAX_"",
                            infoPostFix:    """",
                            loadingRecords: ""Cargando..."",
                            zeroRecords:    ""No hay items para mostrar"",
                            emptyTable:     ""No hay datos disponibles"",
                            paginate: {
                                first:      ""Primero"",
                                previous:   ""Anterior"",
                                next:       ""Siguiente"",
                                last:       ""Último""
                            },
                            aria: {
                                sortAscending:  "": ordenar de manera ascendente"",
                                sortDescending: "": ordenar de manera descendente""
                            }
                            }

                        });

                        $('.dataTables_length').addClass('bs-select');
                        $('div.toolbar').html('<button type=""button"" caption=""Nuevo"" title=""Crear Nuevo"" class=""btn btn-outline-dark d-flex justify-content-center align-items-center"" style=""margin:0;height:40px;"" ><span class=""bi-plus"" style=""font-size: 24px;margin:0;""></span>Crear Nuevo</button>');
                    }

                    function drawGrid() {
                        var token = $('input[name=""__RequestVerificationToken""]', form).val();
                        $.post(""" + parameters.FormAction + @""",
                            {
                                __RequestVerificationToken: token, 
                                name: ""Donald Duck"",
                                city: ""Duckburg""
                            },
                            function(data, status){
                                populateTable(JSON.parse(data)); //status
                            }
                        );
                    }

                    drawGrid();
                </script>
            ");

        }
    }
}

/* 
    [HtmlTargetElement("myhelper")]
    public class MyHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var builder = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("strong");
            builder.InnerHtml.SetContent("Hello World");
            output.Content.SetContent(builder.ToString());
        }
    }

 async Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
        {
            //var content = output.GetChildContentAsync().Result.GetContent();
            var builder = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("strong");
            builder.InnerHtml.SetContent("Hello World");
            output.Content.SetContent(builder.ToString());
            await base.ProcessAsync(context, output);
        }
 */
