using System.Web;
using System.Web.Optimization;

namespace Workflow_management_system
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/AppSript").Include("~/Scripts/Appscript.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrusive").Include(
                         "~/Scripts/jquery.unobtrusive-ajax.js"));
 
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
             bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                      "~/Content/admin/plugins/bower_components/jquery/dist/jquery.min.js",
                      "~/Content/admin/bootstrap/dist/js/tether.min.js",
                      "~/Content/admin/bootstrap/dist/js/bootstrap.min.js",
                      "~/Content/admin/plugins/bower_components/bootstrap-extension/js/bootstrap-extension.min.js",
                      "~/Content/admin/plugins/bower_components/sidebar-nav/dist/sidebar-nav.min.js",
                      "~/Scripts/adminjs/jquery.slimscroll.js",
                      "~/Scripts/adminjs/waves.js",
                      "~/Content/admin/plugins/bower_components/raphael/raphael-min.js",
                      "~/Content/admin/plugins/bower_components/morrisjs/morris.js",
                      "~/Content/admin/plugins/bower_components/jquery-sparkline/jquery.sparkline.min.js",
                      "~/Content/admin/plugins/bower_components/peity/jquery.peity.min.js",
                      "~/Content/admin/plugins/bower_components/peity/jquery.peity.init.js",
                      "~/Scripts/adminjs/custom.min.js",
                      "~/Scripts/adminjs/dashboard1.js",
                      "~/Content/admin/plugins/bower_components/styleswitcher/jQuery.style.switcher.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                         "~/Content/bootstrap.css",
                         "~/Content/site.css",
                         "~/Content/AppStyle.css"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                    "~/Content/admin/bootstrap/dist/css/bootstrap.min.css",
                    "~/Content/admin/plugins/bower_components/bootstrap-extension/css/bootstrap-extension.css",
                    "~/Content/admin/plugins/bower_components/sidebar-nav/dist/sidebar-nav.min.css",
                    "~/Content/admin/plugins/bower_components/morrisjs/morris.css",
                   "~/Content/admin/css/animate.css",
                   "~/Content/admin/css/style.css",
                   "~/Content/admin/css/colors/megna.css"));
        }
    }
}
