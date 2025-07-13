namespace IkasAdminApiLibrary.Api.Categories.Models.Inputs
{
    public class CategoryPathFilterInput
    {
        public IReadOnlyList<string>? In { get; }

        private CategoryPathFilterInput(IEnumerable<string>? included = null)
        {
            In = included?.ToList().AsReadOnly();
        }

        public static CategoryPathFilterInput Included(IEnumerable<string> values)
        {
            return new CategoryPathFilterInput(included: values);
        }
    }
}
