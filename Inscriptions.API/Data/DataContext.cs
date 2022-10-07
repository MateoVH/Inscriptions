using Inscriptions.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inscriptions.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Asociado> Asociados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asociado>()
            .HasIndex(pt => new { pt.Cedula })
            .IsUnique();
        }
    }
}
