using Dominio.Entidades;
using Dominio.Repositorio;
using Repositorio.DAL;

namespace Repositorio.Entidades
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(ApplicationDbContext dbContext): base(dbContext)
        {
        }
    }
}
