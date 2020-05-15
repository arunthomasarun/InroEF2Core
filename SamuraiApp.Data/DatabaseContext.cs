using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class DatabaseContext : DbContext
    {
        public static readonly LoggerFactory loggerFactory =
            new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name && 
                level == LogLevel.Information, true)
            });

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .UseSqlServer("Server=DESKTOP-C8CNSOE\\SQLEXPRESS;Database=IntroEF2CoreSamuraiApp;user id=sa;password=SqlExpress@9;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new {s.SamuraiId, s.BattleId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
