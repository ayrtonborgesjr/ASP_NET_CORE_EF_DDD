using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Categoria : EntidadeBase
    {
        public string Descricao { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
