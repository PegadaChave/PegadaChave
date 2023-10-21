using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PegadaChave.Models
{
    internal class Carrinho
    {
        [Key]
        [Required]
        public int id_carrinho { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public int id_cliente { get; set; }

        [Required(ErrorMessage = "O total do carrinho é obrigatório.")]
        public float total_carrinho { get; set; }

        [ForeignKey("id_cliente")]
        public Cliente Cliente { get; set; }
    }
}