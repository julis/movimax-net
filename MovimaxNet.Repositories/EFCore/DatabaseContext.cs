using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MovimaxNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimaxNet.Repositories.EFCore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Film>? Films { get; set; }
        public DbSet<FilmGenre>? FilmGenre { get; set; }   
        public DbSet<Genre>? Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseSqlite("Data Source=database.db");
            return new DatabaseContext(builder.Options);
        }
    }
}
