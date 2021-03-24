using Aplicacao.Servico.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoCliente Servico;
        private readonly IMapper Mapper;

        public ServicoAplicacaoCliente(IServicoCliente servico, IMapper mapper)
        {
            Servico = servico;
            Mapper = mapper;
        }

        public void Cadastrar(ClienteViewModel clienteViewModel)
        {
            Cliente cliente = new Cliente();
            cliente = Mapper.Map<Cliente>(clienteViewModel);
            Servico.Cadastrar(cliente);
        }

        public ClienteViewModel CarregarRegistro(int codigoCliente)
        {
            var cliente = Servico.CarregarRegistro(codigoCliente);
            var clienteVM = new ClienteViewModel();

            clienteVM = Mapper.Map<ClienteViewModel>(cliente);

            return clienteVM;
        }

        public void Excluir(int id)
        {
            Servico.Excluir(id);
        }

        public IEnumerable<SelectListItem> ListaClientesDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();
            foreach (var item in lista)
            {
                SelectListItem cliente = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome,
                };
                retorno.Add(cliente);
            }
            return retorno;
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            var lista = Servico.Listagem();
            List<ClienteViewModel> listaVM = new List<ClienteViewModel>();

            foreach (var item in lista)
            {
                listaVM.Add(Mapper.Map<ClienteViewModel>(item));
            }

            return listaVM;
        }
    }
}
