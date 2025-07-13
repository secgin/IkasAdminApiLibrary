using GraphQL.Query.Builder;

namespace IkasAdminApiLibrary.Abstracts
{
    internal interface IGraphQLService
    {
        public Task<IResult<T>> QueryAsync<T>(IQuery query, string path);

        public Task<IResult<T>> MutationQueryAsync<T>(IQuery query, string path);

        public IQuery<T> CreateQuery<T>(string name);
    }
}
