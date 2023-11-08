using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PegadaChave.Models.DTOs
{
    public class FuncionarioDTO
    {
        [Display(Name = "ID do Funcionário")]
        public int IdFuncionario { get; set; }

        [Display(Name = "ID do Usuário")]
        public int IdUsuario { get; set; }

        [Display(Name = "Nome do Usuário")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do usuário não pode exceder 100 caracteres.")]
        public string NomeUsuario { get; set; }

        [Display(Name = "Email do Usuário")]
        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O email do usuário não pode exceder 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O email do usuário não é um endereço de email válido.")]
        public string EmailUsuario { get; set; }

        [Display(Name = "Senha do Usuário")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
        [StringLength(255, ErrorMessage = "A senha do usuário não pode exceder 255 caracteres.")]
        [DataType(DataType.Password)]
        public string SenhaUsuario { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "A data de cadastro é obrigatória.")]
        public DateTime DataCadastro { get; set; }
    }
}