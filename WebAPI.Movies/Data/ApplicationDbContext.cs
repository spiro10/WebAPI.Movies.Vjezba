using Microsoft.EntityFrameworkCore;
using WebAPI.Movies.Models.Dbo;

namespace WebAPI.Movies.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Movie> Movies { get; set; }
    }
}
