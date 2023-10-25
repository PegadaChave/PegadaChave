using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

[Table("Pedido")]
public class Pedido
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPedido { get; set; }

    [Required]
    [ForeignKey("Carrinho")]
    public int IdCarrinho { get; set; }

    [Required]
    [ForeignKey("Cliente")]
    public int IdCliente { get; set; }

    [Required]
    public DateTime DataHoraPedido { get; set; }

    [Required]
    [ForeignKey("Endereco")]
    public int IdEndereco { get; set; }

    [Required]
    public StatusPedido StatusPedido { get; set; }

    public virtual Carrinho Carrinho { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual Endereco Endereco { get; set; }
}

public enum StatusPedido
{
    Pago,
    Cancelado,
    Pendente,
    Finalizado
}
