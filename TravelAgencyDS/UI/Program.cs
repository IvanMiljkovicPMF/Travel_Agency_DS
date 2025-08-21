using Data;
using TravelAgency.Services;

namespace UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\travelagencyds.db");
            string connectionString = $"Data Source={dbPath};";

            using (var context = new AppDbContext(connectionString))
            {
                context.Database.EnsureCreated();
            }

            // Start backup service (runs every 24h)
            var backupService = new BackupService(connectionString, "Backups");

            Application.Run(new Form1(connectionString));
        }
    }
}