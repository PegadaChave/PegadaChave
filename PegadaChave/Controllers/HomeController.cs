﻿using System;
using System.Web.Mvc;

namespace PegadaChave.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Console.WriteLine("Teste");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}