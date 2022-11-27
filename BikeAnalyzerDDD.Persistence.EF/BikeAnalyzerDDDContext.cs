using BikeAnalyzerDDD.Domain.Entities;
using BikeAnalyzerDDD.Persistence.EF.DummyData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Persistence.EF
{
    public class BikeAnalyzerDDDContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=BikeAnalyzerDDD;Trusted_Connection=True;";
        public DbSet<Bike> Bikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BikeAnalyzerDDDContext).Assembly);

            foreach (var item in DummyBike.GetBikes())
            {
                modelBuilder.Entity<Bike>().HasData(item);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}