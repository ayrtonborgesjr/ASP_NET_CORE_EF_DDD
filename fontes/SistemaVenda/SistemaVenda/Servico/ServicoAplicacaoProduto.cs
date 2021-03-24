using Aplicacao.Servico.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoProduto Servico;
        private readonly IMapper Mapper;

        public ServicoAplicacaoProduto(IServicoProduto servico, IMapper mapper)
        {
            Servico = servico;
            Mapper = mapper;
        }

        public void Cadastrar(ProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto();
            produto = Mapper.Map<Produto>(produtoViewModel);
            Servico.Cadastrar(produto);
        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {
            var produto = Servico.CarregarRegistro(codigoProduto);
            var produtoVM = new ProdutoViewModel();

            produtoVM = Mapper.Map<ProdutoViewModel>(produto);

            return produtoVM;
        }

        public void Excluir(int id)
        {
            Servico.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = Servico.Listagem();
            List<ProdutoViewModel> listaVM = new List<ProdutoViewModel>();

            foreach (var item in lista)
            {
                listaVM.Add(Mapper.Map<ProdutoViewModel>(item));
            }

            return listaVM;
        }

        public IEnumerable<SelectListItem> ListaProdutosDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();
            foreach (var item in lista)
            {
                SelectListItem produto = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao,
                };
                retorno.Add(produto);
            }
            return retorno;
        }
    }
}
