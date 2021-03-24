using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositorio.DAL;
using SistemaVenda.Models;
using System.Diagnostics;

namespace SistemaVenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        protected ApplicationDbContext Repositorio;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext repositorio)
        {
            _logger = logger;
            Repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
