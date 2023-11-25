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

        [HttpPost]
        public ActionResult Login(string email, string senha)
        {
            int idUsuario = loginCRUD.ValidarLogin(email, senha);
            if (idUsuario > 0)
            {
                // Login bem sucedido, redirecionar para a página inicial
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Login falhou, mostrar mensagem de erro
                ViewBag.ErrorMessage = "Email ou senha incorretos.";
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            loginCRUD.DeslogarUsuario();
            return RedirectToAction("Index", "Home");
        }
    }
}