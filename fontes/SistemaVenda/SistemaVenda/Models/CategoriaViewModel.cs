using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class CategoriaViewModel
    {
        public int? Codigo { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public string Descricao { get; set; }
    }
}
