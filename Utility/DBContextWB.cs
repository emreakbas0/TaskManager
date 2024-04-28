using WEBPROJECT2.Models;
using Microsoft.EntityFrameworkCore;
namespace WEBPROJECT2.Utility
{
    public class DBContextWB : DbContext
    {
        public DBContextWB(DbContextOptions options) : base(options) { }

        public DbSet<User> User{ get; set; }

        public DbSet<Tokens> Tokens { get; set; }
        
        public DbSet<Reports> Reports { get; set; }
    }
}