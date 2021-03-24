using Dominio.Entidades;
using Dominio.Repositorio;
using Repositorio.DAL;

namespace Repositorio.Entidades
{
    public class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(ApplicationDbContext dbContext): base(dbContext)
        {

        }
    }
}
