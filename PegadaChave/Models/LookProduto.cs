using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("LookProduto")]
public class LookProduto
{
    [Key, Column(Order = 0), ForeignKey("Look")]
    [Display(Name = "ID do Look")]
    public int IdLook { get; set; }

    [Key, Column(Order = 1), ForeignKey("Produto")]
    [Display(Name = "ID do Produto")]
    public int IdProduto { get; set; }

    public virtual Look Look { get; set; }
    public virtual Produto Produto { get; set; }
}
