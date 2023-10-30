using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        //crie uma função que preencha a palavra "Placidusax" em um array de char
        public ActionResult Teste()
        {
            char[] palavra = new char[10];
            palavra[0] = 'P';
            palavra[1] = 'l';
            palavra[2] = 'a';
            palavra[3] = 'c';
            palavra[4] = 'i';
            palavra[5] = 'd';
            palavra[6] = 'u';
            palavra[7] = 's';
            palavra[8] = 'a';
            palavra[9] = 'x';

            ViewBag.Palavra = palavra;

            return View();
        }
    }
}