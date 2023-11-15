using API.Belvo.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Belvo.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // C
            modelBuilder.Entity<Cuenta>().HasOne(x => x.Link).WithMany(x => x.Cuentas).HasForeignKey(x => x.IdLink).OnDelete(DeleteBehavior.Restrict);

            // T
            modelBuilder.Entity<Transaccion>().HasOne(x => x.Cuenta).WithMany(x => x.Transacciones).HasForeignKey(x => x.IdCuenta).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Transaccion>().HasOne(x => x.Link).WithMany(x => x.Transacciones).HasForeignKey(x => x.IdLink).OnDelete(DeleteBehavior.Restrict);
        }

        // C
        public virtual DbSet<Cuenta> Cuentas { get; set; }

        // L
        public virtual DbSet<Link> Links { get; set; }

        // T
        public virtual DbSet<Transaccion> Transacciones { get; set; }
    }
}
