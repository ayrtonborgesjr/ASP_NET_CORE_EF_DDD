using Dominio.Entidades;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Produto> Read()
        {
            return DbSetContext.Include(x => x.Categoria).AsNoTracking().ToList();
        }
    }
}
