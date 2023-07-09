using MontyHall.Models;
using Microsoft.EntityFrameworkCore;
using MontyHall.DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace MontyHall.DataAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-226B4N5U;Initial Catalog=MontyHall; Integrated Security=true ;TrustServerCertificate=true");
        }

        public DbSet<GameData> GameData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameData>().HasKey(o => new { o.GameDataId });
        }
    }
}