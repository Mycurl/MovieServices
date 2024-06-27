using MovieService.Application.Messages;
using MovieService.Domain.Movie;
using MovieService.Infrastructure.Dto_s;

namespace MovieService.Application.Abstractions
{
    public interface IMovieServices
    {
        Task<MessageResponse> Create(MovieDto movie);
        Task<MessageResponse> GetById(int id);
        Task<MessageResponse> GetAll();
        Task<MessageResponse> Delete(int Id);
        Task<MessageResponse> Update(int id, Movies movieDto);
    }
}
