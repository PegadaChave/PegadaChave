using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PegadaChave.Models
{
    internal class LookProduto
    {
        [Key]
        [Required]
        public int id_look { get; set; }

        [Key]
        [Required]
        public int id_produto { get; set; }

        [ForeignKey("id_look")]
        public Look Look { get; set; }

        [ForeignKey("id_produto")]
        public Produto Produto { get; set; }
    }
}