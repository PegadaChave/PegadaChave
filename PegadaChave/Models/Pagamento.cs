using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

[Table("Pagamento")]
public class Pagamento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPagamento { get; set; }

    [Required]
    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }

    [Required]
    public DateTime DataHoraPagamento { get; set; }

    [Required]
    public MetodoPagamento MetodoPagamento { get; set; }

    public virtual Pedido Pedido { get; set; }
}

public enum MetodoPagamento
{
    Debito,
    Credito,
    Pix,
    Boleto
}