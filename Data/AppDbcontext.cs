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
    }
}