// Documentation articles: https://docs.sitefinity.com/administration-enable-asp-net-bundling-and-minification

using System.Web.Optimization;

namespace SitefinityWebApp.BundlingAndMinification
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}