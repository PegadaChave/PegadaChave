using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PegadaChave.Models
{
    internal class CarrinhoProduto
    {
        [Key]
        [Required]
        public int id_carrinho { get; set; }

        [Key]
        [Required]
        public int id_produto { get; set; }

        [Required(ErrorMessage = "A quantidade no carrinho é obrigatória.")]
        public int quantidade_carrinho_produto { get; set; }

        [Required(ErrorMessage = "O preço unitário no carrinho é obrigatório.")]
        public float preco_unidade_carrinho_produto { get; set; }

        [ForeignKey("id_carrinho")]
        public Carrinho Carrinho { get; set; }

        [ForeignKey("id_produto")]
        public Produto Produto { get; set; }
    }
}