using System.ComponentModel.DataAnnotations;

namespace CastlesToWatch.API.Model.DTO
{
    public class CreateCountryDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(4)]
        public string ShortName { get; set; }
    }
}
