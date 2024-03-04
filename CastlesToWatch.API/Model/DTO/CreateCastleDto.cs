using System.ComponentModel.DataAnnotations;

namespace CastlesToWatch.API.Model.DTO
{
    public class CreateCastleDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }


        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Address { get; set; }

        [Required]
        [Range(1,5)]
        public double Rating { get; set; }
        public Guid CountryId { get; set; }
    }
}
