using IkasAdminApiLibrary.Api.Common.Models;

namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class UpdateSalesChannelStatusInput
    {
        public List<ProductSalesChannelStatusInput> Data { get; set; } = [];

        public string SalesChannelId { get; set; } = string.Empty;
    }

    public class ProductSalesChannelStatusInput
    {
        public string ProductId { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }

    public class ProductSalesChannelStatusErrorData
    {
        public string ProductId { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }

    public class UpdateSalesChannelStatusResult : BulkOperationResult<ProductSalesChannelStatusErrorData>
    {
    }
}
