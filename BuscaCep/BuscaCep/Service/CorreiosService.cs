using BuscaCep.Models;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace BuscaCep.Services
{
    public class CorreiosService
    {

        private readonly HttpClient _httpClient;

        public CorreiosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<endereco> BuscarEnderecoPorCep(string cep)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                var json = await response.Content.ReadAsStringAsync();
                if (json.Length > 20)
                    return JsonConvert.DeserializeObject<endereco>(json);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 

    }
}
