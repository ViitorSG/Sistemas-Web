using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace BuscaCep.Models
{
    public class Pessoa
    {
        public int Id { get; set; } // Chave primária
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        // Propriedades de endereço
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }

        // Caminho do arquivo da foto
        public string CaminhoFoto { get; set; }

        // Campo para upload de arquivo
        [NotMapped]  // Não mapear para o banco de dados
        public IFormFile Foto { get; set; }
    }

}