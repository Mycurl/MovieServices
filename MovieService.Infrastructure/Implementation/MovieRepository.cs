using Microsoft.EntityFrameworkCore;
using MovieService.Domain.DB;
using MovieService.Domain.Movie;
using MovieService.Infrastructure.Abstraction;
using MovieService.Infrastructure.Dto_s;
#pragma warning disable


namespace MovieService.Infrastructure.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context= context;
        }

        public async Task<Movies> InsertRecord(Movies movies)
        {
            var result = await _context.AddAsync(movies);
            await _context.SaveChangesAsync();

            return movies;
        }

        public async Task<Movies> UpdateRecord(Movies movies)
         {
            _context.Entry(movies).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return movies;
        }

        public async Task<Movies?> GetById(int Id)
        {
            var emplo = await _context.Movie.Where(e => e.MovieId == Id).FirstOrDefaultAsync();
            return emplo;
        }

        public async Task<Movies> CheckIfExist(string name)
        {
            //var emplo = new Movies();
            var emplo = await _context.Movie.Where(x =>x.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
            return emplo;
        }

        public async Task<IEnumerable<Movies>> GetAll()
        {
            var resp = await _context.Movie.ToListAsync();
            return resp;
        }
        public async Task<Movies> Delete(int Id)
        {
            var result = await _context.Movie.Where(x => x.MovieId == Id).FirstOrDefaultAsync();
             _context.Movie.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
