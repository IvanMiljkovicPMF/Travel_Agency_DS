using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MySqlConnector;

namespace TravelAgency.Services
{
    public class BackupService
    {
        private Timer _timer;
        private readonly string _connectionString;
        private readonly string _backupDir;

        public BackupService(string connectionString, string backupDir)
        {
            _connectionString = connectionString;
            _backupDir = backupDir;

            // Pokreni odmah, zatim svakih 24h
            _timer = new Timer(DoBackup, null, TimeSpan.Zero, TimeSpan.FromHours(24));
        }

        private void DoBackup(object state)
        {
            try
            {
                if (_connectionString.Contains(".sqlite") || _connectionString.Contains(".db"))
                {
                    BackupSqlite(_connectionString, _backupDir);
                }
                else if (_connectionString.Contains("server="))
                {
                    BackupMySql(_connectionString, _backupDir);
                }
            }
            catch (Exception ex)
            {
                // Ovde možeš logovati grešku ili pokazati poruku
                Console.WriteLine($"Backup failed: {ex.Message}");
            }
        }

        private void BackupSqlite(string dbPath, string backupDir)
        {
            if (!Directory.Exists(backupDir))
                Directory.CreateDirectory(backupDir);

            string backupFile = Path.Combine(
                backupDir,
                $"travelagencydsbackup_{DateTime.Now:yyyyMMdd_HHmmss}.db"
            );

            File.Copy(dbPath, backupFile, true);
            Console.WriteLine($"SQLite backup created: {backupFile}");
        }

        private void BackupMySql(string connectionString, string backupDir)
        {
            if (!Directory.Exists(backupDir))
                Directory.CreateDirectory(backupDir);

            string backupFile = Path.Combine(
                backupDir,
                $"travelagencydsbackup_{DateTime.Now:yyyyMMdd_HHmmss}.sql"
            );

            var builder = new MySqlConnectionStringBuilder(connectionString);

            string args = $"-u {builder.UserID} -p{builder.Password} -h {builder.Server} {builder.Database}";

            var psi = new ProcessStartInfo
            {
                FileName = "mysqldump",
                Arguments = $"{args} > \"{backupFile}\"",
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                UseShellExecute = true
            };

            Process.Start(psi);
            Console.WriteLine($"MySQL backup created: {backupFile}");
        }
    }
}
