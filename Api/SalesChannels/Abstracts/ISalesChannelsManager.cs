using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.SalesChannels.Models;
using IkasAdminApiLibrary.Api.SalesChannels.Models.Inputs;

namespace IkasAdminApiLibrary.Api.SalesChannels.Abstracts
{
    public interface ISalesChannelsManager
    {
        public Task<IResult<List<SalesChannel>>> List(ListSalesChannelInput? input = null);

        public Task<IResult<SalesChannel>> Get();
    }
}
