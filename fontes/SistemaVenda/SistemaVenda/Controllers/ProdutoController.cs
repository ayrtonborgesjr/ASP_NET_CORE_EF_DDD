using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVenda.Controllers
{
    public class ProdutoController : Controller
    {
        protected readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        protected readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public ProdutoController(IServicoAplicacaoProduto servicoAplicacaoProduto, IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoProduto.Listagem());
        }
      
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();

            if (id != null)
            {
                viewModel = ServicoAplicacaoProduto.CarregarRegistro((int)id);
            }

            viewModel.ListaCategorias = ServicoAplicacaoCategoria.ListaCategoriasDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoProduto.Cadastrar(viewModel);
            }
            else
            {
                viewModel.ListaCategorias = ServicoAplicacaoCategoria.ListaCategoriasDropDownList();

                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoProduto.Excluir(id);

            return RedirectToAction("Index");
        }

        //private IEnumerable<SelectListItem> ListaCategorias()
        //{
        //    List<SelectListItem> lista = new List<SelectListItem>();
        //    lista.Add(new SelectListItem()
        //    {
        //        Value = string.Empty,
        //        Text = string.Empty
        //    });

        //    List<CategoriaViewModel> categorias = ServicoAplicacaoCategoria.Listagem().ToList();
        //    foreach (var item in categorias)
        //    {
        //        lista.Add(new SelectListItem()
        //        {
        //            Value = item.Codigo.ToString(),
        //            Text = item.Descricao.ToString()
        //        });
        //    }

        //    return lista;
        //}
    }
}
