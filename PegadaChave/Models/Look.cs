using System.ComponentModel.DataAnnotations;

namespace PegadaChave.Models
{
    internal class Look
    {
        [Key]
        [Required]
        public int id_look { get; set; }

        [Required(ErrorMessage = "O nome do look é obrigatório.")]
        [StringLength(50)]
        public string nome_look { get; set; }

        [Required(ErrorMessage = "A categoria do look é obrigatória.")]
        [StringLength(50)]
        public string categoria_look { get; set; }
    }
}