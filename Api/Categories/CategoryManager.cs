using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Categories.Abstracts;
using IkasAdminApiLibrary.Api.Categories.Models;
using IkasAdminApiLibrary.Api.Categories.Models.Inputs;
using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.Categories
{
    internal class CategoryManager : ICategoryManager
    {
        private readonly IGraphQLService graphQLService;

        public CategoryManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<List<Category>>> ListByNames(IEnumerable<string> names)
        {
            return await List(new ListCategoriesInput
            {
                Name = StringFilterInput.Included(names)
            });
        }

        public async Task<IResult<List<Category>>> List(ListCategoriesInput? input = null)
        {
            var query = graphQLService.CreateQuery<Category>("listCategory")
               .AddArguments(input ?? new ListCategoriesInput())
               .AddField(p => p.ParentId)
               .AddField(p => p.Id)
               .AddField(p => p.Name)
               .AddField(p => p.CreatedAt);

            return await graphQLService.QueryAsync<List<Category>>(query, "listCategory");
        }

        public async Task<IResult<Category>> Save(CategoryInput categoryInput)
        {
            var query = graphQLService.CreateQuery<Category>("saveCategory")
               .AddArguments(new
               {
                   input = categoryInput
               })
               .AddField(p => p.ParentId)
               .AddField(p => p.Id)
               .AddField(p => p.Name)
               .AddField(p => p.CreatedAt);

            return await graphQLService.MutationQueryAsync<Category>(query, "saveCategory");
        }

        public Task<IResult<Category>> SaveByName(string name, string? parentId)
        {
            var categoryInput = new CategoryInput(name);
            if (!string.IsNullOrWhiteSpace(parentId))
                categoryInput.ParentId = parentId;

            return Save(categoryInput);
        }
    }
}
