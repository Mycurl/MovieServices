using MovieService.Domain.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Infrastructure.Abstraction
{
    public interface IMovieRepository
    {
        Task<Movies> InsertRecord(Movies movies);
        Task<Movies?> CheckIfExist(string name);
        Task<Movies> UpdateRecord(Movies movies);
        Task<Movies?> GetById(int Id);
        Task<IEnumerable<Movies>> GetAll();
        Task<Movies> Delete(int Id);
    }
}
