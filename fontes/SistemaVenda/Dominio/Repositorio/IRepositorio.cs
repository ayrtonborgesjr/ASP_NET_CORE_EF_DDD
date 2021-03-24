using System.Collections.Generic;

namespace Dominio.Repositorio
{
    public interface IRepositorio<TEntidade> where TEntidade : class
    {
        void Create(TEntidade Entity);
        IEnumerable<TEntidade> Read();
        TEntidade Read(int id);
        void Delete(int id);
    }
}
