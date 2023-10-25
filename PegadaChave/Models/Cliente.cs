using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Cliente")]
public class Cliente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID do Cliente")]
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
    [ForeignKey("Usuario")]
    [Display(Name = "ID do Usuário")]
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "O CPF do cliente é obrigatório.")]
    [StringLength(11, ErrorMessage = "O CPF do cliente deve ter 11 caracteres.")]
    [Display(Name = "CPF do Cliente")]
    public string CpfCliente { get; set; }

    [Required(ErrorMessage = "A data de nascimento do cliente é obrigatória.")]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento do Cliente")]
    public DateTime DataNascimentoCliente { get; set; }

    [Required(ErrorMessage = "O sexo do cliente é obrigatório.")]
    [EnumDataType(typeof(SexoCliente), ErrorMessage = "O sexo do cliente não é válido.")]
    [Display(Name = "Sexo do Cliente")]
    public SexoCliente SexoCliente { get; set; }

    [Required(ErrorMessage = "O celular do cliente é obrigatório.")]
    [StringLength(11, ErrorMessage = "O celular do cliente deve ter 11 caracteres.")]
    [Display(Name = "Celular do Cliente")]
    public string CelularCliente { get; set; }

    public virtual Usuario Usuario { get; set; }
}

public enum SexoCliente
{
    Masculino,
    Feminino
}