using System.Web;
using System.Web.Optimization;

namespace Beautifuls
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            // add glamour css bundles
            bundles.Add(new StyleBundle("~/Content/glamour_css").Include(
                "~/Content/glamour_css/bootstrap.min.css",
                "~/Content/glamour_css/font-awesome.min.css",
                "~/Content/glamour_css/owl.carousel.min.css",
                "~/Content/glamour_css/flaticon.css",
                "~/Content/glamour_css/magnific-popup.css",
                "~/Content/glamour_css/style.css"
            ));
            // add glamour js bundles
            bundles.Add(new ScriptBundle("~/Bundles/glamour_js").Include(
                "~/Scripts/glamour_js/jquery-3.2.1.min.js",
                "~/Scripts/glamour_js/bootstrap.min.js",
                "~/Scripts/glamour_js/jquery.magnific-popup.min.js",
                "~/Scripts/glamour_js/owl.carousel.min.js",
                "~/Scripts/glamour_js/isotope.pkgd.min.js",
                "~/Scripts/glamour_js/circle-progress.min.js",
                "~/Scripts/glamour_js/main.js"
            ));
        }
    }
}
