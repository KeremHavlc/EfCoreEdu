using Microsoft.EntityFrameworkCore;

namespace EfCoreEdu.Models
{
    public class DenemeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HEK9VG2;Database=efcore;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<SimpleTable> SimpleTables { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
