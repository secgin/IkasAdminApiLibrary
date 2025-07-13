using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Vendors.Models;
using IkasAdminApiLibrary.Api.Vendors.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Vendors.Abstracts
{
    public interface IVendorService
    {
        public Task<IResult<List<Vendor>>> List(ListVendorInput input);

        public Task<IResult<Vendor>> Save(VendorInput input);
    }
}
