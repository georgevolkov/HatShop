﻿using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HeaderController : Controller
    {
        //
        // GET: /Header/

        public ActionResult Index(int? productId)
        {
            return View();
        }
    }
}
