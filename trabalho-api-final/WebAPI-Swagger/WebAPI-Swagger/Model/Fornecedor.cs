// Modelo Fornecedor
namespace WebAPI_Swagger.Model
{
    public class Fornecedor
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Contato { get; set; }
        public string? Endereco { get; set; }

        public int? ID_Produto { get; set; }

        public string? Nome_Produto { get; set; }


        // Lista de produtos do fornecedor
        public ICollection<Produto>? Produtos { get; set; }
    }
}