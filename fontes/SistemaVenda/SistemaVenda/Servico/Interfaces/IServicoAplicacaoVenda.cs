using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoVenda
    {
        IEnumerable<VendaViewModel> Listagem();
        void Cadastrar(VendaViewModel clienteViewModel);
        VendaViewModel CarregarRegistro(int codigoVenda);
        void Excluir(int id);
        IEnumerable<GraficoViewModel> ListaGrafico();
    }
}
