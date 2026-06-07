using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Timeline.Abstracts;
using IkasAdminApiLibrary.Api.Timeline.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Timeline
{
    internal class TimelineManager : ITimelineManager
    {
        private const string AddOrderTimelineEntryMutation = """
            mutation AddOrderTimelineEntry($input: PublicTimelineInput!) {
              addOrderTimelineEntry(input: $input)
            }
            """;

        private readonly IGraphQLService graphQLService;

        public TimelineManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<bool>> AddOrderTimelineEntry(PublicTimelineInput input)
        {
            return await graphQLService.MutationQueryAsync<bool>(
                AddOrderTimelineEntryMutation,
                new { input },
                "addOrderTimelineEntry");
        }
    }
}
