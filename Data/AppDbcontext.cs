using Microsoft.EntityFrameworkCore;
using SistemaDeVenda.Models;

namespace SistemaDeVenda.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fatura>()
                .Property(f => f.Valor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Venda>()
                .Property(v => v.Valor)
                .HasPrecision(10, 2);
        }
    }
}