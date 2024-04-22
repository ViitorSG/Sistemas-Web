using BuscaCep.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuscaCep.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Lista()
        {
            // Aqui você pode adicionar qualquer lógica necessária antes de exibir a lista,
            // como buscar dados do banco de dados se necessário.
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
