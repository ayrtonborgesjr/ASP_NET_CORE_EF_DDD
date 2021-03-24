using Dominio.Entidades;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace Dominio.Repositorio
{
    public interface IRepositorioVenda : IRepositorio<Venda>
    {
        new IEnumerable<Venda> Read();

        new Venda Read(int id);

        new void Delete(int id);
    }
}
