using System.Web.Optimization;

namespace EC.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/styles")
                .Include("~/Content/bootstrap.min.css",
                         "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/form")
                .Include("~/Content/bootstrap.min.css",
                         "~/Content/formStyle.css"));

            bundles.Add(new StyleBundle("~/Content/select2")
                .Include("~/Content/dashboard.css",
                         "~/Content/select2.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-3.0.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2")
                .Include("~/Scripts/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive")
                .Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate.min.js",
                         "~/Scripts/jquery.validate.unobtrusive.min.js"));
        }
    }
}