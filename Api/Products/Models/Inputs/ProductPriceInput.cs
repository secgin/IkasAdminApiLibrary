namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class ProductPriceInput
    {
        public double SellPrice { get; set; }

        public double? BuyPrice { get; set; }

        public double? DiscountPrice { get; set; }

        public string? Currency { get; set; }

        public string? PriceListId { get; set; }

        public ProductPriceInput()
        {
            BuyPrice = null;
            Currency = null;
            PriceListId = null;
            DiscountPrice = null;
        }

        public ProductPriceInput(double price) : base()
        {
            SellPrice = price;
        }
    }
}
