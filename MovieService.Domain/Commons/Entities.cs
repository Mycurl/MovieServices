using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Domain.Commons
{
    public class Entities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
