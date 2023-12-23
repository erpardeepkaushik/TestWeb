﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Session["PageName"] = "Updated from About Page";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            Session["PageName"] = "Updated from Contact Page";

            return View();
        }
    }
}