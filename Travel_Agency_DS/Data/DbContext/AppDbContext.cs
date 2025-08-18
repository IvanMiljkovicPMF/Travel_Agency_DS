using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new ArgumentNullException("Connection string is null or empty.");
            }
            if (_connectionString.Contains(".sqlite") || _connectionString.Contains(".db"))
            {
                // SQLite provider
                optionsBuilder.UseSqlite(_connectionString);
            }
            else
            {
                // Pretpostavljamo MSSQL provider
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
