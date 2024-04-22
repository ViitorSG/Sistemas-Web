using BuscaCep.Models;
using BuscaCep.Services;
using BuscaCep.Data;
using Microsoft.AspNetCore.Mvc;

namespace BuscaCep.Controllers
{
    public class CepController : Controller
    {
        private readonly CorreiosService _correiosServices;
        private readonly ApplicationDbContext _context;

        public CepController(CorreiosService correiosServices, ApplicationDbContext context)
        {
            _correiosServices = correiosServices;
            _context = context;
        }

        public IActionResult index()
        {
            return View(new Pessoa()); // Modifique para retornar um objeto Pessoa
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (pessoa.Foto != null && pessoa.Foto.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pessoa.Foto.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await pessoa.Foto.CopyToAsync(stream);
                        }
                        pessoa.CaminhoFoto = "/images/" + pessoa.Foto.FileName;
                    }

                    _context.Pessoas.Add(pessoa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the error (uncomment ex variable name and write a log.)
                    Console.WriteLine(ex.Message);
                    return View("Index", pessoa); // Use the original data to refill the form for user's convenience.
                }
            }

            return View("Index", pessoa);
        }



        [HttpPost]
        public async Task<IActionResult> BuscarEnderecoPorCep(string cep)
        {
            var endereco = await _correiosServices.BuscarEnderecoPorCep(cep);
            if (endereco == null)
            {
                TempData["Mensagem"] = "CEP <strong> não </strong> encontrado";
                return View("Index", new Pessoa());
            }

            // Cria uma nova Pessoa com os dados do endereço buscado
            var pessoa = new Pessoa
            {
                Cep = endereco.cep,
                Logradouro = endereco.Logradouro,
                Bairro = endereco.Bairro,
                Localidade = endereco.Localidade,
                Uf = endereco.uf
            };

            return View("Index", pessoa);
        }


        [HttpPost]
        public async Task<IActionResult> AddPessoa(Pessoa pessoa)
        {



            if (ModelState.IsValid)
            {
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redireciona para a visualização principal
            }
            return View(pessoa);
        }

    }
}
