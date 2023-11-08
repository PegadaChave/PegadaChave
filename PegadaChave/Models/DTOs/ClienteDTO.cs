using System;
using System.ComponentModel.DataAnnotations;

namespace PegadaChave.Models.DTOs
{
    public class ClienteDTO
    {
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "O nome do usu�rio � obrigat�rio.")]
        [StringLength(100, ErrorMessage = "o nome do usu�rio n�o pode exceder 100 caracteres.")]
        [Display(Name = "nome do usu�rio")]
        public string nomeUsuario { get; set; }

        [Required(ErrorMessage = "O email do usu�rio � obrigat�rio.")]
        [StringLength(100, ErrorMessage = "o email do usu�rio n�o pode exceder 100 caracteres.")]
        [EmailAddress(ErrorMessage = "o email do usu�rio n�o � um endere�o de email v�lido.")]
        [Display(Name = "email do usu�rio")]
        public string emailUsuario { get; set; }

        [Required(ErrorMessage = "A senha do usu�rio � obrigat�ria.")]
        [StringLength(255, ErrorMessage = "a senha do usu�rio n�o pode exceder 255 caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "senha do usu�rio")]
        public string senhaUsuario { get; set; }

        [Required(ErrorMessage = "O cpf do cliente � obrigat�rio.")]
        [StringLength(11, ErrorMessage = "o cpf do cliente deve ter 11 caracteres.")]
        [Display(Name = "cpf do cliente")]
        public string cpfCliente { get; set; }

        [Required(ErrorMessage = "A data de nascimento do cliente � obrigat�ria.")]
        [DataType(DataType.Date)]
        [Display(Name = "data de nascimento do cliente")]
        public DateTime dataNascimentoCliente { get; set; }

        [Required(ErrorMessage = "O sexo do cliente � obrigat�rio.")]
        [EnumDataType(typeof(Sexocliente), ErrorMessage = "o sexo do cliente n�o � v�lido.")]
        [Display(Name = "sexo do cliente")]
        public Sexocliente sexoCliente { get; set; }

        [Required(ErrorMessage = "O celular do cliente � obrigat�rio.")]
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