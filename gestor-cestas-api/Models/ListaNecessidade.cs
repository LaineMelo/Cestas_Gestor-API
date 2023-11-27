using System.ComponentModel.DataAnnotations;

namespace gestor_cestas_api.Models
{
    public class ListaNecessidade
    {
        [Key]
        public int Id { get; set; }
        public int IdBeneficiario { get; set; }
        public string ListaNecessidades { get; set; }

    }
}
