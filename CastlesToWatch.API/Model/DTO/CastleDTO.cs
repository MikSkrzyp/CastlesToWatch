using CastlesToWatch.API.Model.Domain;

namespace CastlesToWatch.API.Model.DTO
{
    public class CastleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        

        public Country Country { get; set; }
    }
}
