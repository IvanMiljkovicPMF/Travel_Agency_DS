using System;
using System.IO;
using Utils.DataConnection;

namespace Utils.DataConfig
{
    public class ConfigReader
    {
        private static ConfigReader? _instance;
        private static readonly object _lock = new object();

        public string? AgencyName { get; private set; }
        public string? ConnectionString { get; private set; }
        public IDataProvider? DatabaseProvider { get; private set; }

        private ConfigReader() { }

        public static ConfigReader Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new ConfigReader();
                    }
                }
                return _instance;
            }
        }

        public void LoadConfig(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Config file not found: {filePath}");

            var lines = File.ReadAllLines(filePath);
            if (lines.Length < 2)
                throw new Exception("Config file must contain at least 2 lines.");

            AgencyName = lines[0].Trim();
            ConnectionString = lines[1].Trim();

            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new Exception("Connection string cannot be empty.");

            // Pick adapter based on connection string
            if (ConnectionString.Contains(".sqlite") || ConnectionString.Contains(".db"))
                DatabaseProvider = new SQLiteAdapter();
            else if (ConnectionString.Contains("server=") && ConnectionString.Contains("uid="))
                DatabaseProvider = new MySQLAdapter();
            else
                throw new Exception("Unknown database type in connection string.");
        }
    }
}
