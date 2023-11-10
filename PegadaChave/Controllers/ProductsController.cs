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

        public ActionResult Index(string sortOrder, string genero)
        {
            var produtos = produtoCRUD.Read();

            if (!string.IsNullOrEmpty(genero))
            {
                produtos = produtos.Where(p => p.GeneroProduto.ToString().ToLower() == genero.ToLower()).ToList();
            }

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

            // Passamos o resultado da escolha para a view
            ViewBag.SortOrder = sortOrder;
            ViewBag.Genero = genero;
            return View(produtos);
        }
    }
}