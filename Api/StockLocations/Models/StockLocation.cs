namespace IkasAdminApiLibrary.Api.StockLocations.Models
{
    public class StockLocation
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public StockLocation()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
