using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PegadaChave.Models
{
    public enum Sexo
    {
        Masculino,
        Feminino
    }

    internal class Cliente
    {
        [Key]
        [Required]
        public int id_cliente { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public int id_usuario { get; set; }

        [Required(ErrorMessage = "O CPF do cliente é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string cpf_cliente { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        public DateTime data_nascimento_cliente { get; set; }

        [Required(ErrorMessage = "O sexo do cliente é obrigatório.")]
        public Sexo sexo_cliente { get; set; }

        [Required(ErrorMessage = "O número de celular do cliente é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O número de celular deve ter 11 caracteres.")]
        public string celular_cliente { get; set; }

        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
    }
}