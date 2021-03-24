using Dominio.DTO;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioVendaProdutos : DbContext, IRepositorioVendaProdutos
    {
        protected ApplicationDbContext DbSetContext;

        public RepositorioVendaProdutos(ApplicationDbContext mContext)
        {
            DbSetContext = mContext;
        }

        public IEnumerable<GraficoDTO> ListaGrafico()
        {
            var lista = DbSetContext.VendaProdutos.GroupBy(y => y.Produto.Descricao).Select(x => new GraficoDTO
                            {
                                Descricao = x.Key.ToString(),
                                TotalVendido = x.Sum(p => p.Quantidade)
                            }).ToList();

            return lista;
        }
    }
}
