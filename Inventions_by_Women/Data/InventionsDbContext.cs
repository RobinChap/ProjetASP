using Inventions_by_Women.Providers;
using Inventions_by_Women.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventions_by_Women.Data
{
    public class InventionsDbContext : DbContext
    {
        public InventionsDbContext(DbContextOptions<InventionsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(x => x.Mail).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var fact = new LoggerFactory();
            fact.AddProvider(new SQLLoggerProvider());
            optionsBuilder.UseLoggerFactory(fact);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Inventions_by_Women.Models.Invention> Invention { get; set; }

    }
}
