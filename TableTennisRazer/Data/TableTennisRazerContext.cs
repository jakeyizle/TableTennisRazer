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

        public DbSet<TableTennisRazer.Models.TwoPersonMatch> TwoPersonMatch { get; set; }

        public DbSet<TableTennisRazer.Models.FourPersonMatch> FourPersonMatch { get; set; }
    }
}
