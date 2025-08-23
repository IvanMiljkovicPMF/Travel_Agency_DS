using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.DataConnection
{
    public interface IDataProvider
    {   
        DbContextOptions<AppDbContext> GetOptions(string connectionString);
    }
}
