using Microsoft.AspNetCore.Mvc;

namespace SistemaVenda.Controllers
{
    public class ConfiguracaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
