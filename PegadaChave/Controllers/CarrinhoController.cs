using PegadaChave.Data;
using PegadaChave.Models.DTOs;
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
        private ClienteCRUD clienteCRUD = new ClienteCRUD();
        private ProdutoCRUD produtoCRUD = new ProdutoCRUD();

        public ActionResult Index(int IdClienteLogado)
        {
            CarrinhoDTO carrinho = carrinhoCRUD.ObterCarrinho(IdClienteLogado);
            ClienteDTO cliente = clienteCRUD.ClientePorId(IdClienteLogado);
            List<CarrinhoProdutoDTO> produtosCarrinho = carrinho.Produtos;
            List<int> idsProdutos = produtosCarrinho.ConvertAll(p => p.IdProduto);
            List<ProdutoDTO> produtos = produtoCRUD.ProdutosPorIds(idsProdutos);

            return View(new Tuple<CarrinhoDTO, ClienteDTO, List<ProdutoDTO>>(carrinho, cliente, produtos));
        }

        [HttpPost]
        public ActionResult AdicionarAoCarrinho(int IdClienteLogado, int IdProduto)
        {
            if (IdClienteLogado == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                carrinhoCRUD.AdicionarProduto(IdClienteLogado, IdProduto, 1);
                return RedirectToAction("Index", "Carrinho", new { IdClienteLogado = IdClienteLogado });
            }
        }
    }
}