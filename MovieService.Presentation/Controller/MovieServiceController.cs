using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MovieService.Application.Abstractions;
using MovieService.Domain.Movie;
using MovieService.Infrastructure.Dto_s;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieService.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController] 
    public class MovieServiceController : ControllerBase
    {
        private readonly IMovieServices _movieServices;

        public MovieServiceController(IMovieServices movieServices)
        {
           _movieServices = movieServices;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _movieServices.GetAll();
            return Ok(result);
        }

        [HttpGet("GetBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _movieServices.GetById(id);
            return Ok(response);
        }
        [HttpPost("CreateMovies")]
        public async Task<IActionResult> Post([FromBody] MovieDto value)
        {
            var post = await _movieServices.Create(value);
            return Ok(post);
        }

        //// PUT api/<MovieServiceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Movies movieDto)
        {
            var result = await _movieServices.Update(id, movieDto);
            return Ok(result);
        }

        // DELETE api/<MovieServiceController>/5
        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _movieServices.Delete(Id);
            return Ok(result);
        }
    }
}
