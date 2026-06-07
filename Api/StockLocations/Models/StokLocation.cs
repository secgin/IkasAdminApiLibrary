using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Products.Models;

namespace IkasAdminApiLibrary.Api.StockLocations.Models
{
    public class StokLocation
    {
        public Address? Address { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public string? DeliveryTime { get; set; }

        public string? Description { get; set; }

        public string Id { get; set; }

        public bool? IsRemindOutOfStockEnabled { get; set; }

        public string Name { get; set; }

        public List<string> OutOfStockMailList { get; set; }

        public List<ProductTranslation> Translations { get; set; }

        public StockLocationTypeEnum? Type { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public StokLocation()
        {
            Id = string.Empty;
            Name = string.Empty;
            OutOfStockMailList = [];
            Translations = [];
        }
    }
}
