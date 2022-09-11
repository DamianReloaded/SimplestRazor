using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reload.Razor.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlContent Menu(this IHtmlHelper htmlHelper)
        {
            return new HtmlString($@"
                                    <div class='page'>
                                      <nav aria-label='Main Menu'>
                                        <ul class='menubar-navigation' role='menubar' aria-label='Main Menu'>
                                          <li role='none'>
                                            <a role='menuitem'
                                               aria-haspopup='true'
                                               aria-expanded='false'
                                               href='#about'>
                                              About
                                            </a>
                                            <ul role='menu' aria-label='About'>
                                              <li role='none'>
                                                <a role='menuitem' href='#overview'>
                                                  Overview
                                                </a>
                                              </li>
                                              <li role='none'>
                                                <a role='menuitem' href='#administration'>
                                                  Administration
                                                </a>
                                              </li>
                                              <li role='none'>
                                                <a role='menuitem'
                                                   aria-haspopup='true'
                                                   aria-expanded='false'
                                                   href='#facts'>
                                                  Facts
                                                  <svg xmlns=''
                                                       class='right'
                                                       width='9'
                                                       height='12'
                                                       viewBox='0 0 9 12'>
                                                    <polygon points='0 1, 0 11, 8 6'></polygon>
                                                  </svg>
                                                </a>
                                                <ul role='menu' aria-label='Facts'>
                                                  <li role='none'>
                                                    <a role='menuitem' href='#history'>
                                                      History
                                                    </a>
                                                  </li>
                                                  <li role='none'>
                                                    <a role='menuitem' href='#current-statistics'>
                                                      Current Statistics
                                                    </a>
                                                  </li>
                                                  <li role='none'>
                                                    <a role='menuitem' href='#awards'>
                                                      Awards
                                                    </a>
                                                  </li>
                                                </ul>
                                              </li>
                                              <li role='none'>
                                                <a role='menuitem'
                                                   aria-haspopup='true'
                                                   aria-expanded='false'
                                                   href='#campus-tours'>
                                                  Campus Tours
                                                  <svg xmlns=''
                                                       class='right'
                                                       width='9'
                                                       height='12'
                                                       viewBox='0 0 9 12'>
                                                    <polygon points='0 1, 0 11, 8 6'></polygon>
                                                  </svg>
                                                </a>
                                                <ul role='menu' aria-label='Campus Tours'>
                                                  <li role='none'>
                                                    <a role='menuitem' href='#for-prospective-students'>
                                                      For prospective students
                                                    </a>
                                                  </li>
                                                  <li role='none'>
                                                    <a role='menuitem' href='#for-alumni'>
                                                      For alumni
                                                    </a>
                                                  </li>
                                                  <li role='none'>
                                                    <a role='menuitem' href='#for-visitors'>
                                                      For visitors
                                                    </a>
                                                  </li>
                                                </ul>
                                              </li>
                                            </ul>
                                          </li>
                                          <li role='none'>
                                            <a role='menuitem'
                                               aria-haspopup='true'
                                               aria-expanded='false'
                                               href='#admissions'>
                                              Admissions
                                            </a>
                                            <ul role='menu' aria-label='Admissions'>
                                              <li role='none'>
                                                <a role='menuitem' href='#apply'>
                                                  Apply
                                                </a>
                                              </li>
                                              <li role='none'>
                                                <a role='menuitem'
                                                   aria-haspopup='true'
                                                   aria-expanded='false'
                                                   href='#tuition'>
                                                  Tuition
                                                  <svg xmlns=''
                                                       class='right'
                                                       width='9'
                                                       height='12'
                                                       viewBox='0 0 9 12'>
                                                    <polygon points='0 1, 0 11, 8 6'></polygon>
                                                  </svg>
                                                </a>
                                                <ul role='menu' aria-label='Tuition'>
                                                  <li role='none'>
                                                    <a role='menuitem' href='#undergraduate'>
                                                      Undergraduate
                                                    </a>
                                                  </li>
                                                  <li role='none'>
                                                    <a role='menuitem' href='#graduate'>
                                                      Graduate
                                                    </a>
                                                  </li>
                                                  <li role='none'>
                                                    <a role='menuitem' href='#professional-schools'>
                                                      Professional Schools
                                                    </a>
                                                  </li>
                                                </ul>
                                              </li>
                                              <li role='none'>
                                                <a role='menuitem' href='#sign-up'>
                                                  Sign Up
                                                </a>
                                              </li>
                                              <li role='separator'></li>
                                              <li role='none'>
                                                <a role='menuitem' href='#visit'>
                                                  Visit
                                                </a>
                                              </li>
                                              <li role='none'>
                                                <a role='menuitem' href='#photo-tour'>
                                                  Photo Tour
                                                </a>
                                              </li>
                                              <li role='none'>
                                                <a role='menuitem' href='#connect'>
                                                  Connect
                                                </a>
                                              </li>
                                            </ul>
                                          </li>
     
                                        </ul>
                                      </nav>
                                    </div>
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
