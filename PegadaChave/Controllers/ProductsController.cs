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
        // Chamada do ProdutoCRUD via construtor
        private ProdutoCRUD produtoCRUD = new ProdutoCRUD();

        // GET: Products
        // Existe uma variável interna para dizer como devem ser ordenados os itens (string sortOrder)
        public ActionResult Index(string sortOrder)
        {
            // Chamando o método Read do ProdutoCRUD para retornar uma lista de todos os produtos
            var produtos = produtoCRUD.Read();

            // Usamos a string sortOrder para definir que tipo de ordenação o botão efetuará
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

            return View(produtos);
        }
    }
}