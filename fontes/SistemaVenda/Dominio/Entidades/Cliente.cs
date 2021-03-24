using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string CNPJ_CPF { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public ICollection<Venda> Vendas { get; set; }
    }
}
