using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class CategoriaController : Controller
    {
        protected readonly IServicoAplicacaoCategoria ServicoAplicacao;

        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacao)
        {
            ServicoAplicacao = servicoAplicacao;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacao.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();
            if (id != null)
            {
                viewModel = ServicoAplicacao.CarregarRegistro((int)id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacao.Cadastrar(viewModel);
            }
            else
            {
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacao.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}
