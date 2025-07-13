namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class ProductAttributeFilterInput
    {
        public string? Eq { get; }

        public IReadOnlyList<string>? In { get; }

        public IReadOnlyList<string>? Nin { get; }

        private ProductAttributeFilterInput(
            string? equal = null,
            IEnumerable<string>? included = null,
            IEnumerable<string>? notIncluded = null)
        {
            Eq = equal;
            In = included?.ToList().AsReadOnly();
            Nin = notIncluded?.ToList().AsReadOnly();
        }

        public static ProductAttributeFilterInput Equal(string value)
        {
            return new ProductAttributeFilterInput(equal: value);
        }

        public static ProductAttributeFilterInput Included(IEnumerable<string> values)
        {
            return new ProductAttributeFilterInput(included: values);
        }

        public static ProductAttributeFilterInput NotIncluded(IEnumerable<string> values)
        {
            return new ProductAttributeFilterInput(notIncluded: values);
        }

        public override string ToString()
        {
            var filters = new List<string>();

            if (Eq != null)
            {
                filters.Add($"eq: \"{Eq}\"");
            }

            if (In != null && In.Any())
            {
                var inValues = string.Join(", ", In.Select(value => $"\"{value}\""));
                filters.Add($"in: [{inValues}]");
            }

            if (Nin != null && Nin.Any())
            {
                var ninValues = string.Join(", ", Nin.Select(value => $"\"{value}\""));
                filters.Add($"nin: [{ninValues}]");
            }

            return $"{{ {string.Join(", ", filters)} }}";
        }
    }
}
