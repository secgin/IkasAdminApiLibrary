using IkasAdminApiLibrary.Api.Common.Models;

namespace IkasAdminApiLibrary.Api.Customers.Models.Inputs
{
    public class ListCustomerInput
    {
        public PaginationInput Pagination { get; set; } = new(20, 1);

        public string? Search { get; set; }
    }
}
