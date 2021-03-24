using Dominio.DTO;
using System.Collections.Generic;

namespace Dominio.Repositorio
{
    public interface IRepositorioVendaProdutos
    {
        IEnumerable<GraficoDTO> ListaGrafico();
    }
}
