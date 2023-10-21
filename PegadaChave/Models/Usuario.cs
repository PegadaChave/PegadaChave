using System;
using System.ComponentModel.DataAnnotations;

namespace PegadaChave.Models
{
    internal class Usuario
    {
        [Key]
        [Required]
        public int id_usuario { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100)]
        public string nome_usuario { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "O email do usuário não é válido.")]
        public string email_usuario { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string senha_usuario { get; set; }

        [Required(ErrorMessage = "A data de cadastro é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        public DateTime data_cadastro { get; set; }
    }
}