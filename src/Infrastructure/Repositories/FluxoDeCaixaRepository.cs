using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Repositories
{
    public class FluxoDeCaixaRepository : DbContext
    {
        public DbSet<Lancamento> Lancamentos { get; set; }

        public FluxoDeCaixaRepository(DbContextOptions<FluxoDeCaixaRepository> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
