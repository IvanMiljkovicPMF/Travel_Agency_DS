using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Utils.DataConnection
{
    public static class DatabaseInitializer
    {
        // Ensures the database exists. Returns AppDbContext if successful.
        public static AppDbContext InitializeDatabase(string? connectionString, IDataProvider? provider)
        {
            if (string.IsNullOrWhiteSpace(connectionString) || provider == null)
                throw new InvalidOperationException("Invalid connection string or provider.");
            // Fix missing quotes in SQLite Data Source paths
            if (connectionString.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
            {
                var pathPart = connectionString.Substring("Data Source=".Length).Trim();
                if (!pathPart.StartsWith("\"") && !pathPart.EndsWith("\""))
                    pathPart = $"\"{pathPart}\"";

                connectionString = $"Data Source={pathPart}";
            }

            // Try to connect or create database at the given path
            var options = provider.GetOptions(connectionString);
            using (var testContext = new AppDbContext(options))
            {
                testContext.Database.EnsureCreated();
            }
            return new AppDbContext(options);
        }

        // Creates a new SQLite database at the specified path.
        public static AppDbContext CreateNewSQLiteDatabase()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Database\\travelagencyds.db");

            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

            var sqliteProvider = new SQLiteAdapter();
            var options = sqliteProvider.GetOptions($"Data Source={dbPath}");
            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
