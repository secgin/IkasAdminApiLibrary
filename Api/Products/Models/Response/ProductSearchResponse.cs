using IkasAdminApiLibrary.Api.Products.Models;

namespace IkasAdminApiLibrary.Api.Products.Models.Response
{
    public class ProductSearchResponse
    {
        public float Count { get; set; }

        public float Limit { get; set; }

        public float Page { get; set; }

        public List<SearchProduct> Results { get; set; }

        public float TotalCount { get; set; }

        public ProductSearchResponse()
        {
            Count = 0;
            Limit = 0;
            Page = 0;
            Results = [];
            TotalCount = 0;
        }
    }
}
