using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Funcionario")]
public class Funcionario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID do Funcionário")]
    public int IdFuncionario { get; set; }

    [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
    [ForeignKey("Usuario")]
    [Display(Name = "ID do Usuário")]
    public int IdUsuario { get; set; }

    public virtual Usuario Usuario { get; set; }
}