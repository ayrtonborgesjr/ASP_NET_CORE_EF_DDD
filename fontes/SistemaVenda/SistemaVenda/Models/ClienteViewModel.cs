using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class ClienteViewModel
    {
        public int? Codigo { get; set; }
        
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public string Nome { get; set; }
        
        [DisplayName("CPF/CNPJ")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public string CNPJ_CPF { get; set; }
        
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Informe a {0}!")]
        
        public string Email { get; set; }
        [DisplayName("Celular")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public string Celular { get; set; }
    }
}
