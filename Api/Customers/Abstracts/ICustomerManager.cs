using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Customers.Models;
using IkasAdminApiLibrary.Api.Customers.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Customers.Abstracts
{
    public interface ICustomerManager
    {
        Task<IResult<Pagination<Customer>>> List(ListCustomerInput? input = null);
    }
}
