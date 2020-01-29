using Microsoft.EntityFrameworkCore;
using TreeStructure.Models;

namespace TreeStructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Directory>  Directores { get; set; }
    }
}
