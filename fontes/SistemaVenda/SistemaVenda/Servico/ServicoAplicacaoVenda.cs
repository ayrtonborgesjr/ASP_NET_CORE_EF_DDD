using Aplicacao.Servico.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Newtonsoft.Json;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoVenda Servico;
        private readonly IMapper Mapper;

        public ServicoAplicacaoVenda(IServicoVenda servico, IMapper mapper)
        {
            Servico = servico;
            Mapper = mapper;
        }

        public void Cadastrar(VendaViewModel vendaViewModel)
        {
            Cliente cliente = new Cliente();
            cliente = Mapper.Map<Cliente>(vendaViewModel.Cliente);
            Venda item = new Venda()
            {
                Codigo = vendaViewModel.Codigo,
                Data = (DateTime)vendaViewModel.Data,
                CodigoCliente = (int)vendaViewModel.CodigoCliente,
                Cliente = cliente,
                Total = vendaViewModel.Total,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(vendaViewModel.JsonProdutos)
            };

            Servico.Cadastrar(item);
        }

        public VendaViewModel CarregarRegistro(int codigoVenda)
        {
            JsonSerializerSettings options = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var registro = Servico.CarregarRegistro(codigoVenda);
            ClienteViewModel cliente = new ClienteViewModel();
            cliente = Mapper.Map<ClienteViewModel>(registro.Cliente);
            VendaViewModel venda = new VendaViewModel()
            {
                Codigo = registro.Codigo,
                Data = (DateTime)registro.Data,
                CodigoCliente = (int)registro.CodigoCliente,
                Cliente = cliente,
                Total = registro.Total,
                JsonProdutos = JsonConvert.SerializeObject(registro.Produtos, options)
            };

            return venda;
        }

        public void Excluir(int id)
        {
            Servico.Excluir(id);
        }

        public IEnumerable<VendaViewModel> Listagem()
        {
            JsonSerializerSettings options = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var lista = Servico.Listagem();
            List<VendaViewModel> listaVenda = new List<VendaViewModel>();
            foreach (var item in lista)
            {
                ClienteViewModel cliente = new ClienteViewModel();
                cliente = Mapper.Map<ClienteViewModel>(item.Cliente);
                VendaViewModel venda = new VendaViewModel()
                {
                    Codigo = item.Codigo,
                    Data = (DateTime)item.Data,
                    CodigoCliente = (int)item.CodigoCliente,
                    Cliente = cliente,
                    Total = item.Total,
                    JsonProdutos = JsonConvert.SerializeObject(item.Produtos, options)
                };

                listaVenda.Add(venda);
            }

            return listaVenda;
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            var listaGraficoDTO = Servico.ListaGrafico();
            List<GraficoViewModel> listaGraficoVM = new List<GraficoViewModel>();
            foreach (var graficoDTO in listaGraficoDTO)
            {
                listaGraficoVM.Add(Mapper.Map<GraficoViewModel>(graficoDTO));
            }

            return listaGraficoVM;
        }
    }
}
