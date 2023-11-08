using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PegadaChave.Models.DTOs
{
    public class CarrinhoProdutoDTO
    {
        public int IdProduto { get; set; }

        public int QuantidadeCarrinhoProduto { get; set; }

        public float PrecoUnidadeCarrinhoProduto { get; set; }
    }
}
