using DotNetCourseAPI.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCourseAPI.Utilities
{
    public class DataContextEF : DbContext
    {
        private static string _connectionString = "";
        private IConfiguration _configuration;
        public DbSet<Computer> Computer { get; set; }
        public DataContextEF(IConfiguration config)
        {
            _configuration = config;
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId);
        }
    }
}
