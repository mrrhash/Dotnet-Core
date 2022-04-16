using Microsoft.EntityFrameworkCore;

namespace CrudWithjQueryAjax.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

       public DbSet<Candidate> Candidates { get; set; } 
    }
}
