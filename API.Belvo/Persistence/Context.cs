using API.Belvo.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Belvo.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);

        // C
        public virtual DbSet<Cuenta> Cuentas { get; set; }

        // L
        public virtual DbSet<Link> Links { get; set; }

        // T
        public virtual DbSet<Transaccion> Transacciones { get; set; }
    }
}
