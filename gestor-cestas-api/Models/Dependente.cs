using System.ComponentModel.DataAnnotations;

namespace gestor_cestas_api.Models
{
    public class Dependente
    {
        [Key]
        public int Id { get; set; }
        public int IdBeneficiario { get; set; }
        public string Nome { get; set; }
        public string Parentesco { get; set; }
        public string CPF { get; set; }
    }
}
