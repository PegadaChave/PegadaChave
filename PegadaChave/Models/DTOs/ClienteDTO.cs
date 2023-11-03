using System;
using System.ComponentModel.DataAnnotations;

namespace PegadaChave.Models.DTOs
{
    public class ClienteDTO
    {
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "o nome do usuário não pode exceder 100 caracteres.")]
        [Display(Name = "nome do usuário")]
        public string nomeUsuario { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "o email do usuário não pode exceder 100 caracteres.")]
        [EmailAddress(ErrorMessage = "o email do usuário não é um endereço de email válido.")]
        [Display(Name = "email do usuário")]
        public string emailUsuario { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
        [StringLength(255, ErrorMessage = "a senha do usuário não pode exceder 255 caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "senha do usuário")]
        public string senhaUsuario { get; set; }

        [Required(ErrorMessage = "O cpf do cliente é obrigatório.")]
        [StringLength(11, ErrorMessage = "o cpf do cliente deve ter 11 caracteres.")]
        [Display(Name = "cpf do cliente")]
        public string cpfCliente { get; set; }

        [Required(ErrorMessage = "A data de nascimento do cliente é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "data de nascimento do cliente")]
        public DateTime dataNascimentoCliente { get; set; }

        [Required(ErrorMessage = "O sexo do cliente é obrigatório.")]
        [EnumDataType(typeof(Sexocliente), ErrorMessage = "o sexo do cliente não é válido.")]
        [Display(Name = "sexo do cliente")]
        public Sexocliente sexoCliente { get; set; }

        [Required(ErrorMessage = "O celular do cliente é obrigatório.")]
        [StringLength(11, ErrorMessage = "o celular do cliente deve ter 11 caracteres.")]
        [Display(Name = "celular do cliente")]
        public string celularCliente { get; set; }
    }
    public enum Sexocliente
    {
        Masculino,
        Feminino
    }

}