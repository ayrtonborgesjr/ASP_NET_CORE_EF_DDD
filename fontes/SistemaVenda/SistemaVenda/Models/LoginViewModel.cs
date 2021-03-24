using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class LoginViewModel
    {
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Informe o {0}!")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public string Senha { get; set; }
    }
}
