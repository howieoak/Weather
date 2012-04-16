﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Weather.Models
{
    public static class MyHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static string ImageUrl(string var)
        {
            // mf/03n.83
            
            string fileName = "";

            if (var.StartsWith("mf"))
            {
                fileName = var.TrimStart("mf/".ToCharArray()).TrimEnd(".83".ToCharArray());
            }
            else
            {
                fileName = var;
            }
            
            return string.Format("/Content/images/yr-icons/icons_120x100/{0}.png", fileName);
        }
    }
}