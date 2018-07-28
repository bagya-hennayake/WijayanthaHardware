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

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/powertool-css").Include(CSS.SingleSelectDropDown));
            bundles.Add(new ScriptBundle("~/powertool-js").Include(Plugin.SingleSelectDropDown, Plugin.SingleSelectDropDownFn, "~/Scripts/PowerTools.js"));

            bundles.Add(new StyleBundle("~/paint-css").Include(CSS.SingleSelectDropDown, CSS.DataTable));
            bundles.Add(new ScriptBundle("~/paint-js").Include(Plugin.SingleSelectDropDown, Plugin.SingleSelectDropDownFn, Plugin.DataTable, Plugin.DatableBootStrap, "~/Scripts/Paint.js"));


            bundles.Add(new StyleBundle("~/add-paint-css").Include(CSS.SingleSelectDropDown, CSS.TypeAhead));
            bundles.Add(new ScriptBundle("~/add-paint-js").Include(Plugin.SingleSelectDropDown, Plugin.SingleSelectDropDownFn, Plugin.TypeAhead, "~/Scripts/NewPaint.js"));

        }
    }
}
