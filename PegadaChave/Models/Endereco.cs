using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Endereco")]
public class Endereco
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "ID do Endereço")]
    public int IdEndereco { get; set; }

    [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
    [ForeignKey("Cliente")]
    [Display(Name = "ID do Cliente")]
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "O CEP do endereço é obrigatório.")]
    [StringLength(8, ErrorMessage = "O CEP do endereço deve ter 8 caracteres.")]
    [Display(Name = "CEP do Endereço")]
    public string CepEndereco { get; set; }

    [Required(ErrorMessage = "O logradouro do endereço é obrigatório.")]
    [StringLength(50, ErrorMessage = "O logradouro do endereço não pode exceder 50 caracteres.")]
    [Display(Name = "Logradouro do Endereço")]
    public string LogradouroEndereco { get; set; }

    [Required(ErrorMessage = "O número do endereço é obrigatório.")]
    [Display(Name = "Número do Endereço")]
    public int NumeroEndereco { get; set; }

    [Required(ErrorMessage = "O bairro do endereço é obrigatório.")]
    [StringLength(50, ErrorMessage = "O bairro do endereço não pode exceder 50 caracteres.")]
    [Display(Name = "Bairro do Endereço")]
    public string BairroEndereco { get; set; }

    [Required(ErrorMessage = "A cidade do endereço é obrigatória.")]
    [StringLength(50, ErrorMessage = "A cidade do endereço não pode exceder 50 caracteres.")]
    [Display(Name = "Cidade do Endereço")]
    public string CidadeEndereco { get; set; }

    [Required(ErrorMessage = "A UF do endereço é obrigatória.")]
    [EnumDataType(typeof(UfEndereco), ErrorMessage = "A UF do endereço não é válida.")]
    [Display(Name = "UF do Endereço")]
    public UfEndereco UfEndereco { get; set; }

    public virtual Cliente Cliente { get; set; }
}

public enum UfEndereco
{
    AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO
}