using System.Web;
using System.Web.Optimization;

namespace FinalProject
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

            bundles.Add(new StyleBundle("~/login/css").Include(
                      "~/bootstrap/css/bootstrap.min.css",
                      "~/dist/css/AdminLTE.min.css",
                      "~/plugins/iCheck/square/blue.css",
                      "~/bootstrapcdn/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/login/js").Include(
                      "~/plugins/jQuery/jQuery-2.1.3.min.js",
                      "~/bootstrap/js/bootstrap.min.js",
                      "~/plugins/iCheck/icheck.min.js"));
        }
    }
}
