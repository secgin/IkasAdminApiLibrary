using IkasAdminApiLibrary.Api.Common.Models;

namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class SearchProductInput
    {
        public List<string>? BarcodeList { get; set; }

        public PaginationInput Pagination { get; set; }

        public List<string>? ProductIdList { get; set; }

        public string? Query { get; set; }

        public List<string>? SkuList { get; set; }

        public SearchProductInput(PaginationInput paginationInput)
        {
            Pagination = paginationInput;
        }
    }
}
