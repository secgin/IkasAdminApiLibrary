using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.PriceLists.Abstracts;
using IkasAdminApiLibrary.Api.PriceLists.Models;
using IkasAdminApiLibrary.Api.PriceLists.Models.Inputs;

namespace IkasAdminApiLibrary.Api.PriceLists
{
    internal class PriceListsManager : IPriceListsManager
    {
        private readonly IGraphQLService graphQLService;

        public PriceListsManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<List<PriceList>>> GetAllAsync(ListPriceList? listPriceList = null)
        {
            var query = graphQLService.CreateQuery<PriceList>("listPriceList")
                .AddArguments(listPriceList ?? new ListPriceList())
                .AddField(p => p.Id)
                .AddField(p => p.Currency)
                .AddField(p => p.CurrencyCode)
                .AddField(p => p.CurrencySymbol)
                .AddField(p => p.Name)
                .AddField(p => p.Type)
                .AddField(p => p.RuleList, prl => prl
                    .AddField(p => p.BasePriceListId)
                    .AddField<PriceListCurrencyRateSettings?>(p => p.CurrencyRateSettings, crs => crs
                        .AddField(p => p!.Amount)
                        .AddField(p => p!.Type))
                    .AddField(p => p.CurrencySettings, cs => cs
                        .AddField(p => p.RoundingFormat))
                    .AddField(p => p.Rules, plr => plr
                        .AddField(p => p.Amount)
                        .AddField(p => p.AmountType)
                        .AddField(p => p.OperationType)));

            return await graphQLService.QueryAsync<List<PriceList>>(query, "listPriceList");
        }
    }
}
