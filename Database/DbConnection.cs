using lab6.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace lab6.Database
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {

        }
        public DbSet<Receipt> Receipts { get; set; } = null!;
        public DbSet<Consumer> Consumers { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Utility> Utilities { get; set; } = null!;

    }
}
