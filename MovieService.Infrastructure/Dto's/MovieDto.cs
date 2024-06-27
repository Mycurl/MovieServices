using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Infrastructure.Dto_s
{
    public class MovieDto
    {
        [Required(ErrorMessage = "Field can not be empty")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "field is required")]
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
        public string? ModifiedBy { get; set; }
    }
}
