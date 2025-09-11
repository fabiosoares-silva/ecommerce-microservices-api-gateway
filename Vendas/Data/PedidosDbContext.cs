using Microsoft.EntityFrameworkCore;
using Vendas.Models;

namespace Vendas.Data
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options)
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
