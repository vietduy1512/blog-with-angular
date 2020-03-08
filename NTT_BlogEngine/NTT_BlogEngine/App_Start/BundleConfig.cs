using System.Web;
using System.Web.Optimization;

namespace NTT_BlogEngine
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            */

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Custom.css",
                      "~/Content/css/PagedList.css",
                      //"~/Content/vendor/bootstrap/css/bootstrap-grid.min.css",
                      //"~/Content/vendor/bootstrap/css/bootstrap-reboot.min.css",
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/css/blog-home.css",
                      "~/Content/css/blog-post.css"));


            bundles.Add(new ScriptBundle("~/Content/js").Include(
                      "~/Content/ckeditor/ckeditor.js",
                      "~/Content/vendor/jquery/jquery.min.js",
                      "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Content/Custom.js"));
        }
    }
}
