using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("ItemPedido")]
public class ItemPedido
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdItemPedido { get; set; }

    [Required]
    [ForeignKey("Pedido")]
    public int IdPedido { get; set; }

    [Required]
    [ForeignKey("Produto")]
    public int IdProduto { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    public float PrecoUnitario { get; set; }

    public virtual Pedido Pedido { get; set; }
    public virtual Produto Produto { get; set; }
}