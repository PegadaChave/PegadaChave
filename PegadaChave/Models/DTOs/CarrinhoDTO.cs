using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PegadaChave.Models.DTOs
{
    public class CarrinhoDTO
    {
        public int IdCarrinho { get; set; }

        public int IdCliente { get; set; }

        public float TotalCarrinho { get; set; }

        public List<CarrinhoProdutoDTO> Produtos { get; set; }
    }
}