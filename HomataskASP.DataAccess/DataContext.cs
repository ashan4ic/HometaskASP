using HomataskASP.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HomataskASP.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<DbUser> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Mydb;Username=postgres;Password=n7vwfn5twF");
        }
    }
}
