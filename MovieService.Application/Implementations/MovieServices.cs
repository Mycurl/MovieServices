using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MovieService.Application.Abstractions;
using MovieService.Application.Messages;
using MovieService.Domain.Movie;
using MovieService.Infrastructure.Abstraction;
using MovieService.Infrastructure.Dto_s;

namespace MovieService.Application.Implementations
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _movieRepository;
        private readonly SuccessResponseService _successService;

        public MovieServices(IMovieRepository movieRepository, IOptions<SuccessResponseService> successService)
        {
            _movieRepository = movieRepository;
            _successService = successService.Value;
        }
        public async Task<MessageResponse> Create(MovieDto movie) 
        {
            var ifexist = await _movieRepository.CheckIfExist(movie.Name ?? "");
            if (ifexist != null)
            {
                return new MessageResponse() { ResponseCode = _successService.NotFoundCode, ResponseMessage = _successService.NotFoundMessage };
            }
            var ist = new Movies
            {
                Country = movie.Country,
                Name = movie.Name,
                CreatedDate = DateTime.Now,
                DateModified = DateTime.Now,
                Description = movie.Description,
                Genre = movie.Genre,
                Photo = movie.Photo,
                Rating = movie.Rating,
                ReleasedDate = movie.ReleasedDate,
                TicketPrice = movie.TicketPrice,
            };
            var response = await _movieRepository.InsertRecord(ist);
            return new MessageResponse() { ResponseCode = _successService.SuccessCode, ResponseMessage = _successService.SuccessMessage, ResponseData = response };
        }
        public async Task<MessageResponse> GetById(int id)
        {
            var getById = await _movieRepository.GetById(id);
            if (getById == null)
            {
                return new MessageResponse() { ResponseCode = _successService.NotFoundCode, ResponseMessage = _successService.NotFoundMessage };
            }
            else
            {
                return new MessageResponse() { ResponseCode = _successService.SuccessCode, ResponseMessage = _successService.SuccessMessage, ResponseData = getById };
            }
        }
        public async Task<MessageResponse> GetAll()
        {
            var result = await _movieRepository.GetAll();

            if (result is null)
            {
                return new MessageResponse() { ResponseCode = _successService.ErrorOccuredCode, ResponseMessage = _successService.ErrorOccuredMessage };
            }
            if (result.Count() == 0)
            {
                return new MessageResponse() { ResponseCode = _successService.NotFoundCode, ResponseMessage = _successService.NotFoundMessage};
            }
            else
            {
                return new MessageResponse() { ResponseCode = _successService.SuccessCode, ResponseMessage = _successService.SuccessMessage, ResponseData = result };
            }
        }
        public async Task<MessageResponse> Delete(int Id)
        {
            var result = await _movieRepository.Delete(Id);
            if (result != null)
            {
                 return new MessageResponse() { ResponseCode = _successService.SuccessCode, ResponseMessage = _successService.SuccessMessage, ResponseData = "Deleted Successfully" };
            }
            return new MessageResponse() { ResponseCode = _successService.NotFoundCode, ResponseMessage = _successService.NotFoundMessage, ResponseData = "No Record Found" };
        }
        public async Task<MessageResponse> Update(int id, Movies movieDto)
        {
            var data = await _movieRepository.GetById(id);
            if (data != null)
            {
                data.Name = movieDto.Name;
                data.Photo = movieDto.Photo;
                data.Rating = movieDto.Rating;
                data.ReleasedDate = DateTime.Now;
                data.TicketPrice = movieDto.TicketPrice;
                data.ModifiedBy = movieDto.ModifiedBy;
                data.Country = movieDto.Country;
                data.Description = movieDto.Description;
                data.DateModified = DateTime.Now;
                data.Genre = movieDto.Genre;
                data.CreatedDate = DateTime.Now;

                 await _movieRepository.UpdateRecord(data);
                return new MessageResponse { ResponseCode = _successService.SuccessCode, ResponseMessage = _successService.SuccessMessage, ResponseData= "Updated Successfully" };
            }
            else
            {
                return new MessageResponse() { ResponseCode = _successService.NotFoundCode, ResponseMessage = _successService.NotFoundMessage };
            } 
            


                //var movie = new Movies
                //{
                //    MovieId = id,
                //    Name = movieDto.Name,
                //    Description = movieDto.Description,
                //    Country = movieDto.Country,
                //    CreatedDate = DateTime.Now,
                //    DateModified = DateTime.Now,
                //    ModifiedBy = movieDto.ModifiedBy,
                //    Genre = movieDto.Genre,
                //    Photo = movieDto.Photo,
                //    Rating = movieDto.Rating,
                //    TicketPrice= movieDto.TicketPrice,
                //    ReleasedDate = DateTime.Now,
                //};
                // Updating the Record Value

                //data.MovieId = movieDto.MovieId;
               
                
               
            
        }
    }
}
