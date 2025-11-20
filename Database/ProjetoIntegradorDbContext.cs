using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Entities;

namespace ProjetoIntegrador.Database
{
    public class ProjetoIntegradorDbContext : DbContext
    {
        public ProjetoIntegradorDbContext(DbContextOptions<ProjetoIntegradorDbContext> options) : base(options) { }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Prato> Pratos { get; set; }
    }
}
