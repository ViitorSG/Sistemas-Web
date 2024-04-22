using Microsoft.EntityFrameworkCore;
using BuscaCep.Models;  // Importante para incluir suas classes de modelo

namespace BuscaCep.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Defina as DbSets para as entidades que você precisa no banco de dados
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
