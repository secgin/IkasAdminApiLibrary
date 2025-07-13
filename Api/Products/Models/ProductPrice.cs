namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class ProductPrice
    {
        public float? BuyPrice { get; set; }

        public string? Currency { get; set; }

        public string? CurrencyCode { get; set; }

        public string? CurrencySymbol { get; set; }

        public float? DiscountPrice { get; set; }

        public string? PriceListId { get; set; }

        public float SellPrice { get; set; }

        public ProductPrice()
        {
            BuyPrice = null;
            Currency = null;
            CurrencyCode = null;
            CurrencySymbol = null;
            DiscountPrice = null;
            PriceListId = null;
        }

        public ProductPrice(float sellPrice) : base()
        {
            SellPrice = sellPrice;
        }
    }
}
