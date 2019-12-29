using System.Web;
using System.Web.Optimization;

namespace HahaFrame.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery-1.11.1.min.js",
                        "~/js/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.cycle.js",
                        "~/Scripts/jquery.pngFix.js",
                        "~/Scripts/jquery.smoothanchors2.js",
                        "~/Scripts/jquery.watermark.js",
                        "~/Scripts/curvycorners.js",
                        "~/Scripts/shadowbox.js",
                        "~/Scripts/jquery.fancybox.js",
                        "~/Scripts/common.js",
                        "~/Scripts/jquery.stylish-select.js",
                        "~/Scripts/iphone-style-checkboxes.js",
                        "~/Scripts/main.js",
                        "~/Scripts/common.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                        "~/Scripts/jquery.colorbox.js",
                        "~/Scripts/jquery.lazyload.js",
                        "~/Scripts/home.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/js/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/css/style.css",

                      "~/css/bootstrap.css",
                      "~/Content/css/shadowbox.css",
                      "~/Content/css/jquery.fancybox.css",
                      "~/Content/css/facebox.css",
                      "~/Content/css/jquery.checkbox.css",
                      "~/Content/css/jquery.safari-checkbox.css",
                      "~/Content/css/jquery.stylish-select.css",
                      "~/Content/css/iphone-style-checkboxes.css",
                      "~/Content/css/colorbox.css"));
        }
    }
}
