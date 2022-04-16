using Microsoft.EntityFrameworkCore;

namespace Crud.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
                
        }

        public DbSet<Students> Students { get; set; }

        public DbSet<Faculty> Faculty { get; set;}

        public DbSet<Batch> Batch { get; set; }
    }
}
