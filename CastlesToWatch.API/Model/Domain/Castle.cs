using System.ComponentModel.DataAnnotations.Schema;

namespace CastlesToWatch.API.Model.Domain
{
    public class Castle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public Guid CountryId { get; set; }

        public Country Country { get; set; }
    }
}
