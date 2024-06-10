using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPI_Swagger.Model;

namespace ConsumirAPI.Service
{
    public class FornecedorService
    {
        private readonly HttpClient _httpClient;

        public FornecedorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Fornecedor>> GetAllFornecedoresAsync()
        {
            var response = await _httpClient.GetAsync("api/Fornecedores");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Fornecedor>>();
        }

        public async Task<Fornecedor> GetFornecedorAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Fornecedores/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Fornecedor>();
        }

        public async Task<HttpResponseMessage> PostFornecedorAsync(Fornecedor fornecedor)
        {
            return await _httpClient.PostAsJsonAsync("api/Fornecedores", fornecedor);
        }

        public async Task<HttpResponseMessage> PutFornecedorAsync(int id, Fornecedor fornecedor)
        {
            return await _httpClient.PutAsJsonAsync($"api/Fornecedores/{id}", fornecedor);
        }

        public async Task<HttpResponseMessage> DeleteFornecedorAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/Fornecedores/{id}");
        }
    }
}
