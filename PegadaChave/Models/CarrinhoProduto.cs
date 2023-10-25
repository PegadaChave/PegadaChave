using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("CarrinhoProduto")]
public class CarrinhoProduto
{
    [Key, Column(Order = 0)]
    [ForeignKey("Carrinho")]
    public int IdCarrinho { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("Produto")]
    public int IdProduto { get; set; }

    [Required]
    public int QuantidadeCarrinhoProduto { get; set; }

    [Required]
    public float PrecoUnidadeCarrinhoProduto { get; set; }

    public virtual Carrinho Carrinho { get; set; }
    public virtual Produto Produto { get; set; }
}