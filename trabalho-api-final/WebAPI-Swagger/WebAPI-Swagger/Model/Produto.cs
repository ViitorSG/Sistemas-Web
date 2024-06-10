// Modelo Produto
namespace WebAPI_Swagger.Model
{
    public class Produto
    {
        public int? Id { get; set; }
        public string? Nome_Produto { get; set; }
        public decimal? Preco { get; set; }
        public int? Estoque { get; set; }

        //// Chave estrangeira para o fornecedor
        //public int? FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
    }
}
