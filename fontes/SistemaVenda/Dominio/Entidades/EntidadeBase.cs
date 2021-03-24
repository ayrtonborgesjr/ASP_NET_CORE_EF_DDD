using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class EntidadeBase
    {
        [Key]
        public int? Codigo { get; set; }
    }
}
