using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Categories.Models;
using IkasAdminApiLibrary.Api.Categories.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Categories.Abstracts
{
    public interface ICategoryManager
    {
        public Task<IResult<Category>> Save(CategoryInput categoryInput);

        public Task<IResult<Category>> SaveByName(string name, string? parentId);


        public Task<IResult<List<Category>>> List(ListCategoriesInput? input = null);

        public Task<IResult<List<Category>>> ListByNames(IEnumerable<string> names);
    }
}
