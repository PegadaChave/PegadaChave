using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Carrinho")]
public class Carrinho
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCarrinho { get; set; }

    [Required]
    [ForeignKey("Cliente")]
    public int IdCliente { get; set; }

    [Required]
    public float TotalCarrinho { get; set; }

    public virtual Cliente Cliente { get; set; }
}