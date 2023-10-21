using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PegadaChave.Models
{
    public enum MetodoPagamento
    {
        Debito,
        Credito,
        Pix,
        Boleto
    }

    internal class Pagamento
    {
        [Key]
        [Required]
        public int id_pagamento { get; set; }

        [Required(ErrorMessage = "O ID do pedido é obrigatório.")]
        public int id_pedido { get; set; }

        [Required(ErrorMessage = "A data e hora do pagamento são obrigatórias.")]
        public DateTime data_hora_pagamento { get; set; }

        [Required(ErrorMessage = "O método de pagamento é obrigatório.")]
        public MetodoPagamento metodo_pagamento { get; set; }

        [ForeignKey("id_pedido")]
        public Pedido Pedido { get; set; }
    }
}