using System.Web;
using System.Web.Optimization;

namespace InventoryManager
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

            bundles.Add(new Bundle("~/bundles/Cuba").Include(
                "~/assets/js/jquery-3.5.1.min.js",
                "~/assets/js/bootstrap/bootstrap.bundle.min.js",
                "~/assets/js/icons/feather-icon/feather.min.js",
                "~/assets/js/icons/feather-icon/feather-icon.js",
                "~/assets/js/scrollbar/simplebar.js",
                "~/assets/js/scrollbar/custom.js",
                "~/assets/js/config.js",
                "~/assets/js/sidebar-menu.js",
                "~/assets/js/datatable/datatables/jquery.dataTables.min.js",
                "~/assets/js/datatable/datatables/datatable.custom.js",
                "~/assets/js/tooltip-init.js",
                "~/assets/js/tooltip-init.js",
                "~/assets/js/script.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Cuba/css").Include(
                "~/assets/css/font-awesome.css",
                "~/assets/css/vendors/icofont.css",
                "~/assets/css/vendors/themify.css",
                "~/assets/css/vendors/flag-icon.css",
                "~/assets/css/vendors/feather-icon.css",
                "~/assets/css/vendors/scrollbar.css",
                "~/assets/css/vendors/bootstrap.css",
                "~/assets/css/style.css",
                "~/assets/css/color-1.css",
                "~/assets/css/responsive.css",
                "~/assets/css/vendors/datatables.css",
                "~/Content/site.css"));
        }
    }
}
