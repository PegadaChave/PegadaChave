using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Produto")]
public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID do Produto")]
    public int IdProduto { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(50, ErrorMessage = "O nome do produto não pode exceder 50 caracteres.")]
    [Display(Name = "Nome do Produto")]
    public string NomeProduto { get; set; }

    [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
    [StringLength(255, ErrorMessage = "A descrição do produto não pode exceder 255 caracteres.")]
    [Display(Name = "Descrição do Produto")]
    public string DescricaoProduto { get; set; }

    [Required(ErrorMessage = "A categoria do produto é obrigatória.")]
    [Display(Name = "Categoria do Produto")]
    public CategoriaProduto CategoriaProduto { get; set; }

    [Required(ErrorMessage = "O tamanho do produto é obrigatório.")]
    [Display(Name = "Tamanho do Produto")]
    public TamanhoProduto TamanhoProduto { get; set; }

    [Required(ErrorMessage = "A condição do produto é obrigatória.")]
    [Display(Name = "Condição do Produto")]
    public CondicaoProduto CondicaoProduto { get; set; }

    [Required(ErrorMessage = "O preço do produto é obrigatório.")]
    [Display(Name = "Preço do Produto")]
    public float PrecoProduto { get; set; }

    [Required(ErrorMessage = "A imagem do produto é obrigatória.")]
    [StringLength(255, ErrorMessage = "A imagem do produto não pode exceder 255 caracteres.")]
    [Display(Name = "Imagem do Produto")]
    public string ImagemProduto { get; set; }

    [Required(ErrorMessage = "O gênero do produto é obrigatório.")]
    [Display(Name = "Gênero do Produto")]
    public GeneroProduto GeneroProduto { get; set; }

    [Required(ErrorMessage = "O estoque do produto é obrigatório.")]
    [Display(Name = "Estoque do Produto")]
    public int EstoqueProduto { get; set; }
}

public enum CategoriaProduto
{
    Sapato,
    Camisa,
    Calça
}

public enum TamanhoProduto
{
    P,
    M,
    G
}

public enum CondicaoProduto
{
    Usado,
    Novo,
    Recondicionado
}

public enum GeneroProduto
{
    Masculino,
    Feminino
}