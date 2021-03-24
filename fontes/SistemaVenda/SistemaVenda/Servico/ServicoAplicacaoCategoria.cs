using Aplicacao.Servico.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoCategoria Servico;
        private readonly IMapper Mapper;

        public ServicoAplicacaoCategoria(IServicoCategoria servico, IMapper mapper)
        {
            Servico = servico;
            Mapper = mapper;
        }

        public void Cadastrar(CategoriaViewModel categoriaViewModel)
        {
            Categoria categoria = new Categoria();
            categoria = Mapper.Map<Categoria>(categoriaViewModel);
            Servico.Cadastrar(categoria);
        }

        public CategoriaViewModel CarregarRegistro(int codigoCategoria)
        {
            var categria = Servico.CarregarRegistro(codigoCategoria);
            var categoriaVM = new CategoriaViewModel();

            categoriaVM = Mapper.Map<CategoriaViewModel>(categria);

            return categoriaVM;
        }

        public void Excluir(int id)
        {
            Servico.Excluir(id);
        }

        public IEnumerable<SelectListItem> ListaCategoriasDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();
            foreach (var item in lista)
            {
                SelectListItem categoria = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao,
                };
                retorno.Add(categoria);
            }
            return retorno;
        }

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            var lista = Servico.Listagem();
            List<CategoriaViewModel> listaVM = new List<CategoriaViewModel>();

            foreach (var item in lista)
            {
                listaVM.Add(Mapper.Map<CategoriaViewModel>(item));
            }

            return listaVM;
        }
    }
}
