using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Usuario")]
public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID do Usuário")]
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do usuário não pode exceder 100 caracteres.")]
    [Display(Name = "Nome do Usuário")]
    public string NomeUsuario { get; set; }

    [Required(ErrorMessage = "O email do usuário é obrigatório.")]
    [StringLength(100, ErrorMessage = "O email do usuário não pode exceder 100 caracteres.")]
    [EmailAddress(ErrorMessage = "O email do usuário não é um endereço de email válido.")]
    [Display(Name = "Email do Usuário")]
    public string EmailUsuario { get; set; }

    [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
    [StringLength(255, ErrorMessage = "A senha do usuário não pode exceder 255 caracteres.")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha do Usuário")]
    public string SenhaUsuario { get; set; }

    [Required(ErrorMessage = "A data de cadastro é obrigatória.")]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }

    [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
    [EnumDataType(typeof(TipoUsuario), ErrorMessage = "O tipo de usuário não é válido.")]
    [Display(Name = "Tipo de Usuário")]
    public TipoUsuario TipoUsuario { get; set; }
}

public enum TipoUsuario
{
    Cliente,
    Funcionario
}
