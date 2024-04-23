using Microsoft.EntityFrameworkCore;
using Trabalho_API.Models;

namespace Trabalho_API.Data
{
    public class AppCont : DbContext
    {
      
            public AppCont(DbContextOptions<AppCont> options) : base(options)
            {

            } 

            public DbSet<Cliente> Clientes { get; set; } 

        
    }
}
