using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PegadaChave.Models
{
    public enum UF
    {
        AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO
    }
    internal class Endereco
    {
        [Key]
        [Required]
        public int id_endereco { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public int id_cliente { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter 8 caracteres.")]
        public string cep_endereco { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        [StringLength(50)]
        public string logradouro_endereco { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        public int numero_endereco { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(50)]
        public string bairro_endereco { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(50)]
        public string cidade_endereco { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório.")]
        public UF uf_endereco { get; set; }

        [ForeignKey("id_cliente")]
        public Cliente Cliente { get; set; }
    }
}