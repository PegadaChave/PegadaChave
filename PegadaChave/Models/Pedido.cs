using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PegadaChave.Models
{
    public enum StatusPedido
    {
        Pago,
        Cancelado,
        Pendente
    }

    internal class Pedido
    {
        [Key]
        [Required]
        public int id_pedido { get; set; }

        [Required(ErrorMessage = "O ID do carrinho é obrigatório.")]
        public int id_carrinho { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public int id_cliente { get; set; }

        [Required(ErrorMessage = "A data e hora do pedido são obrigatórias.")]
        public DateTime data_hora_pedido { get; set; }

        [Required(ErrorMessage = "O status do pedido é obrigatório.")]
        public StatusPedido status_pedido { get; set; }

        [ForeignKey("id_carrinho")]
        public Carrinho Carrinho { get; set; }

        [ForeignKey("id_cliente")]
        public Cliente Cliente { get; set; }
    }
}