using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public decimal Valor { get; set; }

        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<VendaProdutos> Vendas { get; set; }
    }
}
