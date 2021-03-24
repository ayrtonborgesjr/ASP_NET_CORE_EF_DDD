using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCliente
    {
        IEnumerable<SelectListItem> ListaClientesDropDownList();
        IEnumerable<ClienteViewModel> Listagem();
        void Cadastrar(ClienteViewModel clienteViewModel);
        ClienteViewModel CarregarRegistro(int codigoCliente);
        void Excluir(int id);
    }
}
