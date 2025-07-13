using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.StockLocations.Models.Inputs
{
    public class ListStockLocationInput
    {
        public StringFilterInput? Id { get; set; }

        public StringFilterInput? Name { get; set; }

        public DateFilterInput? UpdatedAt { get; set; }
    }
}
