using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TableTennisRazer.Models;

namespace TableTennisRazer.Models
{
    public class TableTennisRazerContext : DbContext
    {
        public TableTennisRazerContext (DbContextOptions<TableTennisRazerContext> options)
            : base(options)
        {
        }
        public DbSet<TableTennisRazer.Models.Person> Person { get; set; }

        public DbSet<TableTennisRazer.Models.Match> Match { get; set; }

        public DbSet<TableTennisRazer.Models.MatchPerson> MatchPeople { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            modelBuilder.Entity<MatchPerson>()
                .HasKey(m => new { m.PersonName, m.MatchId });
            modelBuilder.Entity<Match>()
                .Property(m => m.time)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Person>()
                .HasIndex(p => p.PersonName)
                .IsUnique();
        }


    }
}
