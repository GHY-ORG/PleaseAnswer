using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace pleaseAnswer
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //shared
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/Reset.css",
                "~/Content/bootstrap.min.css",
                "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/bootstrap.min.js"));

            //answer css
            bundles.Add(new StyleBundle("~/bundles/answer_styles").Include(
                "~/Content/Answer.css"));
        }
    }
}