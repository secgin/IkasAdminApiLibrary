namespace IkasAdminApiLibrary.Api.StockLocations.Models.Inputs
{
    public class SaveStockLocationsInput
    {
        public List<ProductStockLocationInput> ProductStockLocationInputs { get; }

        public SaveStockLocationsInput(List<ProductStockLocationInput> inputs)
        {
            ProductStockLocationInputs = inputs;
        }
    }
}
