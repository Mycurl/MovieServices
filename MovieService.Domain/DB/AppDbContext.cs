using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Movie;

namespace MovieService.Domain.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option)
            : base(option)
        {

        }
        public DbSet<Movies> Movie { get; set; }

    }
}
