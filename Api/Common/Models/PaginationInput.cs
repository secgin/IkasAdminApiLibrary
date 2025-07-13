namespace IkasAdminApiLibrary.Api.Common.Models
{
    public record PaginationInput
    {
        public int Limit { get; }

        public int Page { get; }

        public PaginationInput(int limit, int page)
        {
            Limit = limit;
            Page = page;
        }
    }
}
