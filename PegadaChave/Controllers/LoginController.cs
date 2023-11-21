using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PegadaChave.Controllers
{
    public class LoginController : Controller
    {
        private LoginCRUD loginCRUD = new LoginCRUD();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            loginCRUD.DeslogarUsuario();
            return RedirectToAction("Index", "Home");
        }
    }
}