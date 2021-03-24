using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {
        readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;
        readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;
        readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;

        public VendaController(
            IServicoAplicacaoVenda servicoAplicacaoVenda,
            IServicoAplicacaoCliente servicoAplicacaoCliente,
            IServicoAplicacaoProduto servicoAplicacaoProduto)
        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoVenda.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();
            if (id != null)
            {
                viewModel = ServicoAplicacaoVenda.CarregarRegistro((int)id);
            }

            viewModel.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
            viewModel.ListaProdutos = ServicoAplicacaoProduto.ListaProdutosDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoVenda.Cadastrar(viewModel);
            }
            else
            {
                viewModel.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
                viewModel.ListaProdutos = ServicoAplicacaoProduto.ListaProdutosDropDownList();
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoVenda.Excluir(id);

            return RedirectToAction("Index");
        }

        //private IEnumerable<SelectListItem> ListaProdutos()
        //{
        //    List<SelectListItem> lista = new List<SelectListItem>();
        //    lista.Add(new SelectListItem()
        //    {
        //        Value = string.Empty,
        //        Text = string.Empty
        //    });

        //    foreach (var item in Context.Produtos.ToList())
        //    {
        //        lista.Add(new SelectListItem()
        //        {
        //            Value = item.Codigo.ToString(),
        //            Text = item.Descricao.ToString()
        //        });
        //    }

        //    return lista;
        //}

        //private IEnumerable<SelectListItem> ListaClientes()
        //{
        //    List<SelectListItem> lista = new List<SelectListItem>();
        //    lista.Add(new SelectListItem()
        //    {
        //        Value = string.Empty,
        //        Text = string.Empty
        //    });

        //    foreach (var item in Context.Clientes.ToList())
        //    {
        //        lista.Add(new SelectListItem()
        //        {
        //            Value = item.Codigo.ToString(),
        //            Text = item.Nome.ToString()
        //        });
        //    }

        //    return lista;
        //}

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto)
        {
            return (decimal)ServicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;
        }
    }
}
