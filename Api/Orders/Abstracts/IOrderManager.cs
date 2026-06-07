using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Orders.Models;
using IkasAdminApiLibrary.Api.Orders.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Orders.Abstracts
{
    public interface IOrderManager
    {
        Task<IResult<Pagination<Order>>> List(ListOrderInput? input = null);

        Task<IResult<List<OrderTransaction>>> ListTransactions(ListOrderTransactionsInput input);

        Task<IResult<Order>> Fulfill(FulfillOrderInput input);

        Task<IResult<Order>> UpdatePackageStatus(UpdateOrderPackageStatusInput input);

        Task<IResult<List<OrderTag>>> ListTags();

        Task<IResult<OrderTag>> CreateTag(CreateOrderTagInput input);

        Task<IResult<bool>> AddTag(AddOrderTagInput input);

        Task<IResult<Order>> AddInvoice(AddOrderInvoiceInput input);

        Task<IResult<Order>> CancelFulfillment(CancelFulfillmentInput input);
    }
}
