using Jegymester.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;

namespace Jegymester.DataContext.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>(); // Enum értékeket stringként tárolja
        }
    }
}
