using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<SeaPackage> SeaPackages { get; set; }
        public DbSet<MountainPackage> MountainPackages { get; set; }
        public DbSet<ExcursionPackage> ExcursionPackages { get; set; }
        public DbSet<CruisePackage> CruisePackages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new ArgumentNullException("Connection string is null or empty.");
            }
            if (_connectionString.Contains(".sqlite") || _connectionString.Contains(".db"))
            {
                // SQLite provider
                optionsBuilder.UseSqlite(_connectionString);
            }
            else if (_connectionString.Contains("server=") && _connectionString.Contains("uid="))
            {
                // MySQL provider (Pomelo)
                optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
            }
            else
            {
                // MSSQL provider
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
