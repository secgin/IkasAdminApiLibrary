namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class VariantPriceInput
    {
        public ProductPriceInput Price { get; set; }

        public string ProductId { get; set; }

        public string VariantId { get; set; }

        public VariantPriceInput(ProductPriceInput price, string productId, string variantId)
        {
            Price = price;
            ProductId = productId;
            VariantId = variantId;
        }
    }
}
