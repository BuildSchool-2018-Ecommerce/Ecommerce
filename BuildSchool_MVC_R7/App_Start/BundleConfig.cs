using System.Web;
using System.Web.Optimization;

namespace BuildSchool_MVC_R7
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/css/util.css",
                      "~/Content/css/main.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/vendor").Include(
                "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/vendor/animate/animate.css",
                "~/Content/vendor/css-hamburgers/hamburgers.min.css",
                "~/Content/vendor/animsition/css/animsition.min.css",
                "~/Content/vendor/select2/select2.min.css",
                "~/Content/vendor/daterangepicker/daterangepicker.css",
                "~/Content/vendor/slick/slick.css",
                "~/Content/vendor/lightbox2/css/lightbox.min.css"
                ));
            bundles.Add(new StyleBundle("~/Content/fonts").Include(
                "~/Content/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Content/fonts/themify/themify-icons.css",
                "~/Content/fonts/Linearicons-Free-v1.0.0/icon-font.min.css",
                "~/Content/fonts/elegant-font/html-css/style.css"
                ));
        }
    }
}
