using BamazonBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BamazonBooks.Infrastructure
{
    
    [HtmlTargetElement("div", Attributes = "page-model")] //applies to divs and is called page-model
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper (IUrlHelperFactory hp) //instance of this class
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; } //using an internal class
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")] //adding a key-value pair
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>(); //adding to the page url values to build our link

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } //attributes in the cshtml
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //overriding
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div"); //result is the div element 

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); //building the tag

                PageUrlValues["pageNum"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, 
                    PageUrlValues); //building the page url value, stores the category or page in the dictionary object to build our endpoint
                
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal); //so that the one that gets selected gets highlighted
                }
                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag); //append the tag to the result
            }

            output.Content.AppendHtml(result.InnerHtml); // at the end of the view, 
        }


    }
}
