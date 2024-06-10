using Microsoft.EntityFrameworkCore;
using WebAPI_Swagger.Model;

namespace WebAPI_Swagger.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome_Produto)
                .HasMaxLength(80);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .HasData(
                    new Produto { Id = 1, Nome_Produto = "Caderno", Preco = 7.99M, Estoque = 50 },
                    new Produto { Id = 2, Nome_Produto = "Lápis", Preco = 1.99M, Estoque = 100 },
                    new Produto { Id = 3, Nome_Produto = "Borracha", Preco = 0.75M, Estoque = 20 }
                );

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.Nome)
                .HasMaxLength(100);

            // Adicione fornecedores durante a migração
            modelBuilder.Entity<Fornecedor>().HasData(
                new Fornecedor { Id = 1, Nome = "Fornecedor A",
                    Contato = "contato@fornecedorA.com",
                    ID_Produto = 1,
                    Nome_Produto = "Caderno",
                    Endereco = "Endereço A" },

                new Fornecedor { Id = 2, Nome = "Fornecedor B",
                    Contato = "contato@fornecedorB.com",
                    ID_Produto = 2,
                    Nome_Produto = "Lápis",
                    Endereco = "Endereço B" },

                new Fornecedor
                {
                    Id = 3,
                    Nome = "Fornecedor C",
                    Contato = "contato@fornecedorC.com",
                    ID_Produto = 3,
                    Nome_Produto = "Borracha",
                    Endereco = "Endereço C"
                }
            );
        }
    }
}
