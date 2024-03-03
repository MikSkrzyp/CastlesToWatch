namespace CastlesToWatch.API.Model.DTO
{
    public class UpdateCastleDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public Guid CountryId { get; set; }
    }
}
