using Microsoft.EntityFrameworkCore;
using flightandticketproject.Models;

namespace flightandticketproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // RowVersion configured as concurrency token
            builder.Entity<Flight>().Property(f => f.RowVersion).IsRowVersion();

            // Make FlightNumber unique
            builder.Entity<Flight>().HasIndex(f => f.FlightNumber).IsUnique();
        }
    }
}