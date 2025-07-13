using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.StockLocations.Models.Inputs
{
    public class ListProductStockLocationInput
    {
        public StringFilterInput? ProductId { get; set; }
    }
}
