using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Helpers;
using SistemaVenda.Models;
using System.Linq;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {
        protected ApplicationDbContext Context;
        protected IHttpContextAccessor HttpContextAccessor;

        public LoginController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            HttpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(int? id )
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContextAccessor.HttpContext.Session.Clear();
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErroLogin"] = string.Empty;

            if (ModelState.IsValid)
            {
                var senha = Criptografia.GetMd5Hash(model.Senha);
                var usuario = Context.Usuarios.Where(u => u.Email == model.Email && u.Senha == senha).FirstOrDefault();
                
                if (usuario == null)
                {
                    ViewData["ErroLogin"] = "O E-mail ou Senha informado não existe no Sistema!";

                    return View(model);
                }
                else
                {
                    // colocar os dados do usuário na sessão
                    HttpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    HttpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    HttpContextAccessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int) usuario.Codigo);
                    HttpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}
