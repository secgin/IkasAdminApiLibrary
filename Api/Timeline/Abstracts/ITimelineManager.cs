using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Timeline.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Timeline.Abstracts
{
    public interface ITimelineManager
    {
        Task<IResult<bool>> AddOrderTimelineEntry(PublicTimelineInput input);
    }
}
