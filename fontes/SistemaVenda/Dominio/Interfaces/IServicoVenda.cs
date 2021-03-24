using Dominio.DTO;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IServicoVenda : IServicoCRUD<Venda>
    {
        IEnumerable<GraficoDTO> ListaGrafico();
    }
}
