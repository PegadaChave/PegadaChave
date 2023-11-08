using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PegadaChave.Models.DTOs
{
    public class ItemPedidoDTO
    {
        public int IdItemPedido { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public float PrecoUnitario { get; set; }
    }
}