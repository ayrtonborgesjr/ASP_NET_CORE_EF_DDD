using System;
using System.Linq;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SistemaVenda.Controllers
{
    public class RelatorioController : Controller
    {
        protected IServicoAplicacaoVenda Servico;

        public RelatorioController(IServicoAplicacaoVenda servico)
        {
            Servico = servico;
        }

        public IActionResult Grafico()
        {
            var lista = Servico.ListaGrafico().ToList();

            string labels = string.Empty;
            string cores = string.Empty;
            string valores = string.Empty;

            var random = new Random();
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalVendido.ToString() + ",";
                labels += "'" + lista[i].Descricao.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;

            return View();
        }
    }
}
