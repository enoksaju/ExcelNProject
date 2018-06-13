using System.Web;
using System.Web.Optimization;

namespace ExcelNoblezaWebApp
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            "~/node_modules/core-js/client/shim.min.js",
            "~/node_modules/zone.js/dist/zone.js",
            "~/node_modules/systemjs/dist/system.src.js",
            "~/systemjs.config.js",
            "~/node_modules/rxjs/bundles/Rx.js"
            ));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
