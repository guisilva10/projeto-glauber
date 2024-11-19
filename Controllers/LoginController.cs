using Microsoft.AspNetCore.Mvc;
using projetopim.Models;
using System.Diagnostics;

namespace projetopim.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public IActionResult Authenticate(string username, string password)
        {
            // Autenticação simplificada (apenas exemplo)
            if (username == "admin" && password == "password")
            {
                // Redireciona para uma página principal após o login bem-sucedido
                return RedirectToAction("Index", "Home");
            }

            // Em caso de falha, retorna à tela de login com uma mensagem de erro
            ViewBag.ErrorMessage = "Nome de usuário ou senha incorretos.";
            return View("Login");
        }
    }
}
