﻿using System.Web;
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

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/site.css")
                .Include("~/Content/css/util.css")
                .Include("~/Content/css/main.css", new CssRewriteUrlTransform()));
            //layout need
            bundles.Add(new StyleBundle("~/bundles/vendor")
                .Include("~/Content/vendor/bootstrap/css/bootstrap.min.css")
                .Include("~/Content/vendor/animate/animate.css")
                .Include("~/Content/vendor/css-hamburgers/hamburgers.min.css")
                .Include("~/Content/vendor/animsition/css/animsition.min.css")
                .Include("~/Content/vendor/select2/select2.min.css")
                .Include("~/Content/vendor/daterangepicker/daterangepicker.css")
                .Include("~/Content/vendor/slick/slick.css")
                .Include("~/Content/vendor/lightbox2/css/lightbox.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/vendor/noui/nouislider.min.css"));
            bundles.Add(new StyleBundle("~/bundles/fonts")
                .Include("~/Content/fonts/themify/themify-icons.css", new CssRewriteUrlTransform())
                .Include("~/Content/fonts/Linearicons-Free-v1.0.0/icon-font.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/fonts/elegant-font/html-css/style.css", new CssRewriteUrlTransform())
                .Include("~/Content/fonts/font-awesome-4.7.0/css/font-awesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new ScriptBundle("~/Content/vendors").Include(
                    "~/Content/vendor/jquery/jquery-3.2.1.min.js",
                    "~/Content/vendor/animsition/js/animsition.min.js",
                    "~/Content/vendor/bootstrap/js/popper.js",
                    "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                    "~/Content/vendor/select2/select2.min.js",
                    "~/Content/vendor/slick/slick.min.js",
                    "~/Content/vendor/countdowntime/countdowntime.js",
                    "~/Content/vendor/lightbox2/js/lightbox.min.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/vendors1").Include(
                    "~/Content/vendor/sweetalert/sweetalert.min.js",
                    "~/Content/vendor/parallax100/parallax100.js",
                    "~/Content/vendor/noui/nouislider.min.js",
                    "~/Content/vendor/daterangepicker/daterangepicker.js",
                    "~/Content/vendor/daterangepicker/moment.min.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                    "~/Content/js/slick-custom.js",
                    "~/Content/js/main.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/backJs").Include(
                    "~/Content/js/jquery.min.js",
                    "~/Content/js/bootstrap.min.js",
                    "~/Content/js/metisMenu.min.js",
                    "~/Content/js/raphael.mim.js",
                    "~/Content/js/morris.min.js",
                    "~/Content/js/morris-data.js.mim.js",
                    "~/Content/js/sb-admin-2.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/backCss").Include(
                    "~/Content/css/bootstrap.min.css",
                    "~/Content/css/metisMenu.min.css",
                    "~/Content/css/sb-admin-2.min.css",
                    "~/Content/css/morris.css"
                    ).Include("~/Content/css/font-awesome.css", new CssRewriteUrlTransform()
                ));
        }   
    }
}
