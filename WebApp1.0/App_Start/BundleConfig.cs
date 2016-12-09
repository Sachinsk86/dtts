using System.Web;
using System.Web.Optimization;

namespace WebApp1._0
{
  public class BundleConfig
  {
    // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Content/assets/js/jquery-2.0.3.min.js",
                  "~/Content/assets/js/skins.min.js",
                  "~/Scripts/jquery.elevatezoom.js"
                  ));

      //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
      //            "~/Scripts/jquery.validate*"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
      //            "~/Scripts/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Content/assets/js/bootstrap.min.js",
                "~/Content/assets/js/datetime/bootstrap-datepicker.js",
                "~/Content/assets/js/beyond.min.js",
                "~/Content/assets/js/select2/select2.js",
                "~/Content/assets/js/datatable/jquery.dataTables.min.js",
                "~/Content/assets/js/datatable/ZeroClipboard.js",
                "~/Content/assets/js/datatable/dataTables.tableTools.min.js",
                "~/Content/assets/js/datatable/dataTables.bootstrap.min.js",
                "~/Content/assets/js/datatable/datatables-init.js"
                ));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/assets/css/bootstrap.min.css",
                "~/Content/assets/css/font-awesome.min.css",
                "~/Content/assets/css/weather-icons.min.css",
                "~/Content/assets/css/beyond.min.css",
                "~/Content/assets/css/demo.min.css",
                "~/Content/assets/css/typicons.min.css",
                "~/Content/assets/css/animate.min.css",
                "~/Content/assets/css/dataTables.bootstrap.css"
                ));
    }
  }
}
