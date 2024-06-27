using MovieService.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Domain.Movie
{
    public class Movies : Entities
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime ReleasedDate { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string? TicketPrice { get; set; }
        [Required]
        public string? Country { get; set; }
        public List<string>? Genre { get; set; }
        public string? Photo { get; set; }
    }
}
