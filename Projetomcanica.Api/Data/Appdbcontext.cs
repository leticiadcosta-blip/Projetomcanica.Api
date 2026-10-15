using Microsoft.EntityFrameworkCore;
using Projetomecanica.Api.Models;


namespace projetomecanica.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<usuario> Usuarios { get; set; }
        public DbSet <Cliente> Cliente { get; set; }
       public DbSet<veiculo> Veiculos { get; set; }

        public DbSet<Agendamento> Agendamento { get; set; }
    }
}