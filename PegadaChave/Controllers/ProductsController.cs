using PegadaChave.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PegadaChave.Controllers
{
    public class ProductsController : Controller
    {
        private ProdutoCRUD produtoCRUD = new ProdutoCRUD();

        // GET: Products
        public ActionResult Index()
        {
            var produtos = produtoCRUD.Read();
            return View(produtos);
        }
    }
}