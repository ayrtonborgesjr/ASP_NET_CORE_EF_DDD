using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IServicoCRUD<TEntidade>
        where TEntidade : class
    {
        IEnumerable<TEntidade> Listagem();
        void Cadastrar(TEntidade entidade);
        TEntidade CarregarRegistro(int id);
        void Excluir(int id);
    }
}
