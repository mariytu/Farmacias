using System.Web;
using System.Web.Optimization;

namespace FarmaciasWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Vendor scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-3.3.1.min.js"));

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia")
                .Include("~/Scripts/app/inspinia.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll")
                .Include("~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js"));

            // jQuery plugins
            bundles.Add(new ScriptBundle("~/plugins/metsiMenu")
                .Include("~/Scripts/plugins/metisMenu/jquery.metisMenu.js"));

            bundles.Add(new ScriptBundle("~/plugins/pace")
                .Include("~/Scripts/plugins/pace/pace.min.js"));

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.min.css",
                        "~/Content/style.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css")
                .Include("~/fonts/font-awesome/css/fontawesome-all.min.css", new CssRewriteUrlTransform()));

            // iCheck css styles
            bundles.Add(new StyleBundle("~/Content/plugins/iCheck/iCheckStyles")
                .Include("~/Content/plugins/iCheck/custom.css"));

            // iCheck
            bundles.Add(new ScriptBundle("~/plugins/iCheck")
                .Include("~/Scripts/plugins/iCheck/icheck.min.js"));

            // Select2 css styles
            bundles.Add(new StyleBundle("~/Content/plugins/select2Styles")
                .Include("~/Content/plugins/select2/select2.min.css"));

            // Select2
            bundles.Add(new ScriptBundle("~/plugins/select2")
                .Include("~/Scripts/plugins/select2/select2.min.js"));

            // Masonry
            bundles.Add(new ScriptBundle("~/plugins/masonry")
                .Include("~/Scripts/plugins/masonary/masonry.pkgd.min.js"));

            // ladda css style
            bundles.Add(new StyleBundle("~/Content/plugins/ladda")
                .Include("~/Content/plugins/ladda/ladda.min.css"));

            // ladda
            bundles.Add(new ScriptBundle("~/plugins/ladda")
                .Include("~/Scripts/plugins/ladda/*.js"));

            // sweetalert css style
            bundles.Add(new StyleBundle("~/Content/plugins/sweetalert")
                .Include("~/Content/plugins/sweetalert/sweetalert.css"));

            // sweetalert
            bundles.Add(new ScriptBundle("~/plugins/sweetalert")
                .Include("~/Scripts/plugins/sweetalert/sweetalert.min.js"));

            //dataTables css style
            bundles.Add(new StyleBundle("~/Content/plugins/dataTables")
                .Include("~/Content/plugins/dataTables/datatables.min.css"));

            // dataTables
            bundles.Add(new ScriptBundle("~/plugins/dataTables")
                .Include("~/Scripts/plugins/dataTables/datatables.min.js"));

            // pdfjs
            bundles.Add(new ScriptBundle("~/plugins/pdfjs")
                .Include("~/Scripts/plugins/pdfjs/pdf.js"));
        }
    }
}
