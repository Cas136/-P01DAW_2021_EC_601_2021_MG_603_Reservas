using Microsoft.EntityFrameworkCore;
using P01_2021_EC_601_2021_MG_603.Models;
using P01_2021_EC_601_2021_MG_603.Data;
namespace P01_2021_EC_601_2021_MG_603.Data
{
    public class parqueoContext : DbContext
    {
        public parqueoContext(DbContextOptions<parqueoContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<EspaciosParqueo> EspaciosParqueo { get; set; }
        public DbSet<Reservas> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Correo)
                .IsUnique();

            modelBuilder.Entity<Sucursales>()
                .HasOne<Usuarios>()
                .WithMany()
                .HasForeignKey(s => s.AdministradorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EspaciosParqueo>()
                .HasOne<Sucursales>()
                .WithMany()
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservas>()
                .HasOne<Usuarios>()
                .WithMany()
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservas>()
                .HasOne<EspaciosParqueo>()
                .WithMany()
                .HasForeignKey(r => r.EspacioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
