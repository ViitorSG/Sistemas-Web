using Microsoft.AspNetCore.Mvc;
using Trabalho_API.Models;
using Trabalho_API.Service;

namespace Trabalho_API.Controllers
{
    public class CepController : Controller
    {
        private readonly CorreiosService _correiosService;

        public CepController(CorreiosService correiosService)
        {
            _correiosService = correiosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuscarEnderecoPorCep(string cep)
        {
            Endereco? endereco = await _correiosService.BuscarEnderecoPorCep(cep);
            if (endereco == null)
            {
                TempData["Mensagem"] = "CEP <strong> não </strong> encontrado";
            }
            return View("Index", endereco);
        }
    }
}
