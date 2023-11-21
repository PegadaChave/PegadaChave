using PegadaChave.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PegadaChave.Controllers
{
    public class CarrinhoController : Controller
    {
        private CarrinhoCRUD carrinhoCRUD = new CarrinhoCRUD();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarAoCarrinho(int IdUsuarioLogado, int IdProduto)
        {
            if (IdUsuarioLogado == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                carrinhoCRUD.AdicionarProduto(IdUsuarioLogado, IdProduto, 1);
                return RedirectToAction("Index", "Carrinho", new { id = IdUsuarioLogado });
            }
        }
    }
}