using System.Web;
using System.Web.Optimization;

namespace aspnet_mvc4_angular_boilerplate
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // ------------------------------
            // CSS Bundles
            // ------------------------------

            bundles.Add(new StyleBundle("~/Content/app").Include(
                        "~/Content/app/styles.css"));

            bundles.Add(new StyleBundle("~/Content/vendor").Include(
                        "~/Content/vendor/bootstrap.css"));

            // ------------------------------
            // JS Bundles
            // ------------------------------

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app/app.js"));
            
        }
    }
}