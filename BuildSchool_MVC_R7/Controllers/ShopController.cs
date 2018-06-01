﻿using BuildSchool_MVC_R7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildSchool_MVC_R7.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Shop()
        {
            var shopService = new ShopService();
            var shop = shopService.Shop();
            return View(shop);
        }
        public ActionResult AllProduct()
        {
            var shopService = new ShopService();
            var shop = shopService.AllShop();
            return PartialView(shop);
        }
        public ActionResult CategoryProduct(int categoryid)
        {
            var shopService = new ShopService();
            var shop = shopService.CategoryShop(categoryid);
            return PartialView(shop);
        }
        public ActionResult Product()
        {
            return View();
        }
    }
}