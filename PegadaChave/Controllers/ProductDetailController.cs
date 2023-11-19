using PegadaChave.Data;
using PegadaChave.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PegadaChave.Controllers
{
    public class ProductDetailController : Controller
    {
        private ProdutoCRUD produtoCRUD = new ProdutoCRUD();
        public ActionResult Index(int id)
        {
            ProdutoDTO produtoEspecifico = produtoCRUD.ProdutoPorId(id);
            List<ProdutoDTO> listaProdutos = produtoCRUD.Read();

            return View(new Tuple<ProdutoDTO, List<ProdutoDTO>>(produtoEspecifico, listaProdutos));
        }
    }
}