namespace IkasAdminApiLibrary.Api.ProductBrands.Models.Inputs
{
    public class ProductBrandInput
    {
        public string Name { get; set; }

        public IEnumerable<string> SalesChannelIds { get; set; }

        public ProductBrandInput(string name, IEnumerable<string> salesChannelIds)
        {
            Name = name;
            SalesChannelIds = salesChannelIds;
        }
    }
}
