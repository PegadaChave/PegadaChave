using PegadaChave.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PegadaChave.Controllers
{
    public class ProductsController : Controller
    {
        private ProdutoCRUD produtoCRUD = new ProdutoCRUD();

        // GET: Products
        public ActionResult Index(string sortOrder)
        {
            var produtos = produtoCRUD.Read();

            switch (sortOrder)
            {
                case "preco_asc":
                    produtos = produtos.OrderByDescending(p => p.PrecoProduto).ToList();
                    sortOrder = "preco_desc";
                    break;
                case "preco_desc":
                    produtos = produtos.OrderBy(p => p.PrecoProduto).ToList();
                    sortOrder = "preco_asc";
                    break;
                default:
                    produtos = produtos.OrderBy(p => p.NomeProduto).ToList();
                    sortOrder = "preco_asc";
                    break;
            }

            ViewBag.SortOrder = sortOrder;

            return View(produtos);
        }
    }
}