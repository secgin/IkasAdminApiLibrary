namespace IkasAdminApiLibrary.Api.StockLocations.Models
{
    public class StokLocation
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public StockLocationTypeEnum Type { get; set; }

        public StokLocation()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
