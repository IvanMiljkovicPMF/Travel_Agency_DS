using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.DataConnection
{
    public class MySQLAdapter : IDataProvider
    {
        public DbContextOptions<AppDbContext> GetOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return optionsBuilder.Options;
        }
    }
}
