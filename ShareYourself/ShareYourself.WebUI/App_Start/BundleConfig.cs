using System.Web.Optimization;

namespace ShareYourself.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"                      
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/PostScripts").Include(
                    "~/Scripts/PostScripts.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Bootstrap.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/RegisterLogin").Include(
                    "~/Content/RegisterLogin.css"
                ));
            bundles.Add(new StyleBundle("~/Content/BodyContent").Include(
                    "~/Content/BodyContent.css"
                ));

            bundles.Add(new StyleBundle("~/Content/Posts").Include(
                    "~/Content/Posts.css"
                ));
        }
    }
}
