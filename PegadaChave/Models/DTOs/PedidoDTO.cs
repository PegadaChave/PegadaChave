using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PegadaChave.Models.DTOs
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public int IdCarrinho { get; set; }
        public int IdCliente { get; set; }
        public int IdEndereco { get; set; }
        public string NomeCliente { get; set; }
        public string LogradouroEndereco { get; set; }
        public int NumeroEndereco { get; set; }
        public string CidadeEndereco { get; set; }
        public string UfEndereco { get; set; }
        public DateTime DataHoraPedido { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public decimal TotalPedido { get; set; }
        public List<ItemPedidoDTO> ItensPedido { get; set; }
    }
}