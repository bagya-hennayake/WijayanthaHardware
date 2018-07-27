using System.Web;
using System.Web.Optimization;
using WijayanthaHardware.Common;

namespace WijayanthaHardware
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/powertool-css").Include(CSS.SingleSelectDropDown));
            bundles.Add(new ScriptBundle("~/powertool-js").Include(Plugin.SingleSelectDropDown, Plugin.SingleSelectDropDownFn, "~/Scripts/PowerTools.js"));

            bundles.Add(new StyleBundle("~/paint-css").Include(CSS.SingleSelectDropDown,CSS.TypeAhead));
            bundles.Add(new ScriptBundle("~/paint-js").Include(Plugin.SingleSelectDropDown, Plugin.SingleSelectDropDownFn,
                Plugin.TypeAhead, "~/Scripts/Paint.js"));


            bundles.Add(new StyleBundle("~/add-paint-css").Include(CSS.SingleSelectDropDown,CSS.TypeAhead ));
            bundles.Add(new ScriptBundle("~/add-paint-js").Include(Plugin.SingleSelectDropDown, Plugin.SingleSelectDropDownFn,Plugin.TypeAhead
               ));
            
        }
    }
}
