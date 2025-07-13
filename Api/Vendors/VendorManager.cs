using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.ProductBrands.Models;
using IkasAdminApiLibrary.Api.Vendors.Abstracts;
using IkasAdminApiLibrary.Api.Vendors.Models;
using IkasAdminApiLibrary.Api.Vendors.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Vendors
{
    internal class VendorManager : IVendorService
    {
        private readonly IGraphQLService graphQLService;

        public VendorManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<List<Vendor>>> List(ListVendorInput input)
        {
            var query = graphQLService.CreateQuery<ProductBrand>("listVendor")
               .AddArguments(input ?? new ListVendorInput())
              .AddField(p => p.Id)
              .AddField(p => p.Name);

            return await graphQLService.QueryAsync<List<Vendor>>(query, "listVendor");
        }

        public async Task<IResult<Vendor>> Save(VendorInput input)
        {
            var query = graphQLService.CreateQuery<Vendor>("saveVendor")
               .AddArguments(new
               {
                   input
               })
               .AddField(p => p.Id)
               .AddField(p => p.Name);

            return await graphQLService.MutationQueryAsync<Vendor>(query, "saveVendor");
        }
    }
}
