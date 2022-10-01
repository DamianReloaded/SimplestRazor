using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Reload.Razor.Helpers
{
    public static partial class HtmlHelpers
    {
        public static string BuildHtmlMenu(MasterModel model, DataTable data)
        {
            Dictionary<int, List<DataRow>> menues = new();
            foreach (DataRow row in data.Rows)
            {
                int padreId = Convert.ToInt32(row["PadreId"]);
                if (!menues.ContainsKey(padreId)) menues.Add(padreId, new List<DataRow>());
                menues[padreId].Add(row);
            }

            if (!menues.ContainsKey(0)) return "";

            string strMenu = $@"
                                    <div class='page'>
                                      <nav aria-label='Main Menu'>
                                        <ul class='menubar-navigation' role='menubar' aria-label='Main Menu'>
                                            <li role='none'>LOGO</li>";

            Func <int, int>? addMenuItems = null;
            addMenuItems = (int parentId) => 
            {
                var menuesX = menues[parentId];
                foreach (var row in menuesX)
                {
                    bool isGroup = Convert.ToInt32(row["EsGrupo"]) > 0;
                    if (isGroup)
                    {
                        strMenu += $@"      <li role='none'>
			                                    <a role='menuitem' aria-haspopup='true' aria-expanded='false' href='#" + row["Codigo"] + @"'>
                                                    <i class='fa fa-window-restore'></i>&nbsp;&nbsp;
				                                    " + row["Descripcion"] + @"
				                                    <svg xmlns='' class='right' width='9' height='12' viewBox='0 0 9 12'> <polygon points='0 1, 0 11, 8 6'></polygon> </svg>
			                                    </a>
                                                <ul role='menu' aria-label='Facts'>
                                            ";

                        addMenuItems!(Convert.ToInt32(row["Id"]));

                        strMenu += $@"          </ul>
                                            </li>
                                            ";
                    }
                    else
                    {
                        strMenu += $@"      <li role='none'>
			                                    <a role='menulink' onclick='alert(\'hello\')'  href='/?page=" + row["Codigo"] + @"'><i class='fa fa-window-maximize'></i>&nbsp;&nbsp;
				                                    " + row["Descripcion"] + @"
			                                    </a>
		                                    </li>
                                            ";
                    }
                }
                return 0;
            };

            {
                var menues0 = menues[0];
                foreach(var row in menues0)
                {
                    strMenu += $@"          <li role='none'>  
	                                            <a role='menuitem' aria-haspopup='true' aria-expanded='false' href='#" + row["Codigo"] + @"'>" + row["Descripcion"] + @"</a>
	                                            <ul role='menu' aria-label='Principal'>
                                            ";

                    addMenuItems(Convert.ToInt32(row["Id"]));

                    strMenu += $@"              </ul>
                                            </li>
                                            ";
                }
            }

            strMenu += $@"             </ ul >
                                      </ nav >
                                    </ div >";

            return strMenu;
        }

        public static IHtmlContent Menu(this IHtmlHelper htmlHelper, MasterModel model)
        {
            return new HtmlString(model.HttpContext.Session.GetString("menuHtmlCode"));
        }
    }
}
