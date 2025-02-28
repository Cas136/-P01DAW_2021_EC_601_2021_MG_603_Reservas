using Microsoft.EntityFrameworkCore;
using P01_2021_EC_601_2021_MG_603.Models;

namespace P01_2021_EC_601_2021_MG_603.Data
{
    public class parqueoContext : DbContext
    {
        public parqueoContext(DbContextOptions<parqueoContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<EspacioParqueo> EspaciosParqueo { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Correo)
                .IsUnique();

            modelBuilder.Entity<Sucursal>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(s => s.AdministradorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EspacioParqueo>()
                .HasOne<Sucursal>()
                .WithMany()
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reserva>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reserva>()
                .HasOne<EspacioParqueo>()
                .WithMany()
                .HasForeignKey(r => r.EspacioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
