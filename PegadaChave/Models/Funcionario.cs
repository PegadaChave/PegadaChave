using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PegadaChave.Models
{
    internal class Funcionario
    {
        [Key]
        [Required]
        public int id_funcionario { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public int id_usuario { get; set; }

        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
    }
}