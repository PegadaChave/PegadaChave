using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Look")]
public class Look
{
    [Key]
    [Required(ErrorMessage = "O campo id_look é obrigatório.")]
    [Display(Name = "ID do Look")]
    public int IdLook{ get; set; }

    [Required(ErrorMessage = "O campo nome_look é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo nome_look deve ter no máximo 50 caracteres.")]
    [Display(Name = "Nome do Look")]
    public string NomeLook { get; set; }

    [Required(ErrorMessage = "O campo categoria_look é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo categoria_look deve ter no máximo 50 caracteres.")]
    [Display(Name = "Categoria do Look")]
    public string CategoriaLook { get; set; }
}