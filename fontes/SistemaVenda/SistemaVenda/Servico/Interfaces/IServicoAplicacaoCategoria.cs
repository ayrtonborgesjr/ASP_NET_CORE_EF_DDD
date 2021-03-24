using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<SelectListItem> ListaCategoriasDropDownList();
        IEnumerable<CategoriaViewModel> Listagem();
        void Cadastrar(CategoriaViewModel categoriaViewModel);
        CategoriaViewModel CarregarRegistro(int codigoCategoria);
        void Excluir(int id);
    }
}
