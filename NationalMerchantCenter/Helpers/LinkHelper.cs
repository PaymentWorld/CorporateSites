using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Codebase.Website.Helpers
{
    public static class LinkHelper
    {
        public static MvcHtmlString MenuActionLink(this HtmlHelper helper, string actionName, string controllerName)
        {            
            var linkBuilder = new TagBuilder("a");

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);

            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, controllerName));            

            var text = linkBuilder.ToString(TagRenderMode.StartTag);            
            text += linkBuilder.ToString(TagRenderMode.EndTag);

            return MvcHtmlString.Create(text);
        }

        public static MvcHtmlString ActionLinkImage(this HtmlHelper helper, string actionName, string controllerName, string imgSrc, string altText, object routeValues)
        {
            
            string theme = "5E1A2906-F51C-4915-84D1-5FD49ED9C18B";
            string path = Path.Combine("~/Content/" + theme + "/", imgSrc);
         
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            string imgUrl = urlHelper.Content(path);

            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            imgTagBuilder.MergeAttribute("style", "border:0px");

            if (!string.IsNullOrEmpty(altText))
                imgTagBuilder.MergeAttribute("alt", altText);

            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            string url = urlHelper.Action(actionName, controllerName, routeValues);

            TagBuilder tagBuilder = new TagBuilder("a");
            tagBuilder.InnerHtml = img;
            tagBuilder.MergeAttribute("href", url);
            tagBuilder.MergeAttribute("style", "border:0px");

            return MvcHtmlString.Create(tagBuilder.ToString());
        }

        public static MvcHtmlString SubmitButtonImage(this HtmlHelper helper, string id, string imgSrc, string htmlAttributes)
        {
            //string theme = "5E1A2906-F51C-4915-84D1-5FD49ED9C18B";
            //string path = Path.Combine("~/Content/" + theme + "/", imgSrc);

            TagBuilder inputTagBuilder = new TagBuilder("input");            
            inputTagBuilder.MergeAttribute("name", id);
            inputTagBuilder.MergeAttribute("id", id);
            inputTagBuilder.MergeAttribute("type", "submit");
            inputTagBuilder.MergeAttribute("value", "");
            //inputTagBuilder.MergeAttribute("type", "image");
            //inputTagBuilder.MergeAttribute("src", imgSrc);

            if (!string.IsNullOrEmpty(htmlAttributes))
                inputTagBuilder.MergeAttribute("style", htmlAttributes);

            return MvcHtmlString.Create(inputTagBuilder.ToString());
        }
    }
}