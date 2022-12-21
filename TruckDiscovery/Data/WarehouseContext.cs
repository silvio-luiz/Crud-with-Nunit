using Microsoft.EntityFrameworkCore;
using TruckDiscovery.Models;

namespace TruckDiscovery.Data
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext (DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Truck>().ToTable("Truck");
        }
    }
}