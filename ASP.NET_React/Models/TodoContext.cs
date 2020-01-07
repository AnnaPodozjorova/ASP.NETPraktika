using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_React.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<City> city { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<Person> person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;Database=CountryDB;Trusted_Connection=False;");
        }

        public TodoContext(DbContextOptions<TodoContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(c => c.City);
            
        }
    }
}
