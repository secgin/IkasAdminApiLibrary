using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.Categories.Models.Inputs
{
    public class ListCategoriesInput
    {
        public StringFilterInput? Id { get; set; }

        public StringFilterInput? Name { get; set; }

        public CategoryPathFilterInput? CategoryPath { get; set; }
    }
}
