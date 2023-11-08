using System.ComponentModel.DataAnnotations;

namespace PegadaChave.Models.DTOs
{
    public class EnderecoDTO
    {
        [Display(Name = "ID do Endereço")]
        public int IdEndereco { get; set; }

        [Display(Name = "ID do Cliente")]
        public int IdCliente { get; set; }

        [Display(Name = "CEP do Endereço")]
        [Required(ErrorMessage = "O CEP do endereço é obrigatório.")]
        [StringLength(8, ErrorMessage = "O CEP do endereço deve ter 8 caracteres.")]
        public string CepEndereco { get; set; }

        [Display(Name = "Logradouro do Endereço")]
        [Required(ErrorMessage = "O logradouro do endereço é obrigatório.")]
        [StringLength(50, ErrorMessage = "O logradouro do endereço não pode exceder 50 caracteres.")]
        public string LogradouroEndereco { get; set; }

        [Display(Name = "Número do Endereço")]
        [Required(ErrorMessage = "O número do endereço é obrigatório.")]
        public int NumeroEndereco { get; set; }

        [Display(Name = "Bairro do Endereço")]
        [Required(ErrorMessage = "O bairro do endereço é obrigatório.")]
        [StringLength(50, ErrorMessage = "O bairro do endereço não pode exceder 50 caracteres.")]
        public string BairroEndereco { get; set; }

        [Display(Name = "Cidade do Endereço")]
        [Required(ErrorMessage = "A cidade do endereço é obrigatória.")]
        [StringLength(50, ErrorMessage = "A cidade do endereço não pode exceder 50 caracteres.")]
        public string CidadeEndereco { get; set; }

        [Display(Name = "UF do Endereço")]
        [Required(ErrorMessage = "A UF do endereço é obrigatória.")]
        [EnumDataType(typeof(UfEndereco), ErrorMessage = "A UF do endereço não é válida.")]
        public UfEndereco UfEndereco { get; set; }
    }
}