using BuscaCep.Data;
using BuscaCep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Importa o namespace do ILogger
using System.IO;
using System.Threading.Tasks;

namespace BuscaCep.Controllers
{
    public class PessoaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PessoaController> _logger; // Declara uma variável para o logger

        // Injeta o logger no construtor
        public PessoaController(ApplicationDbContext context, ILogger<PessoaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                if (pessoa.Foto != null && pessoa.Foto.Length > 0)
                {
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var filePath = Path.Combine(folderPath, pessoa.Foto.FileName);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await pessoa.Foto.CopyToAsync(fileStream);
                    }

                    pessoa.CaminhoFoto = filePath;  // Salve o caminho onde o arquivo foi salvo
                }

                // Supondo que _context é seu DbContext
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  // Redireciona para a lista de pessoas ou para a página principal
            }
            return RedirectToAction("Lista", "Home");
        }

    }
}
