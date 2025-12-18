using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SicaberdomiWeb.Models;

namespace SicaberdomiWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ComentarioCliente> ComentariosCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Pedido>()
                .HasOne(p => p.Domiciliario)
                .WithMany(u => u.PedidosComoDomiciliario)
                .HasForeignKey(p => p.DomiciliarioId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(u => u.PedidosComoCliente)
                .HasForeignKey(p => p.ClienteId)
                .IsRequired();
        }
    }
}
