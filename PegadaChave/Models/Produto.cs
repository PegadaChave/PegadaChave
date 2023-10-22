using System.ComponentModel.DataAnnotations;

namespace PegadaChave.Models
{
    public enum CategoriaProduto
    {
        Sapato,
        Camisa,
        Calca
    }

    public enum TamanhoProduto
    {
        P, M, G
    }

    public enum CondicaoProduto
    {
        Usado, Novo, Recondicionado
    }

    internal class Produto
    {
        [Key]
        [Required]
        public int id_produto { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(50)]
        public string nome_produto { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [StringLength(255)]
        public string descricao_produto { get; set; }

        [Required(ErrorMessage = "A categoria do produto é obrigatória.")]
        public CategoriaProduto categoria_produto { get; set; }

        [Required(ErrorMessage = "O tamanho do produto é obrigatório.")]
        public TamanhoProduto tamanho_produto { get; set; }

        [Required(ErrorMessage = "A condição do produto é obrigatória.")]
        public CondicaoProduto condicao_produto { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        public float preco_produto { get; set; }

        [Required(ErrorMessage = "O estoque do produto é obrigatório.")]
        public int estoque_produto { get; set; }
    }
}