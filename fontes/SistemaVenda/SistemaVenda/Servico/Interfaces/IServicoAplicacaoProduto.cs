using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoProduto
    {
        IEnumerable<SelectListItem> ListaProdutosDropDownList();
        IEnumerable<ProdutoViewModel> Listagem();
        void Cadastrar(ProdutoViewModel produtoViewModel);
        ProdutoViewModel CarregarRegistro(int codigoProduto);
        void Excluir(int id);
    }
}
