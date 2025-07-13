namespace IkasAdminApiLibrary.Api.Common.Models.ValueObjects
{
    public class StringFilterInput
    {
        public string? Eq { get; }

        public IReadOnlyList<string>? In { get; }

        public string? Like { get; }

        public string? Ne { get; }

        public IReadOnlyList<string>? Nin { get; }

        private StringFilterInput(
            string? equal = null,
            IEnumerable<string>? included = null,
            string? like = null,
            string? notEqual = null,
            IEnumerable<string>? notIncluded = null)
        {
            Eq = equal;
            In = included?.ToList().AsReadOnly();
            Like = like;
            Ne = notEqual;
            Nin = notIncluded?.ToList().AsReadOnly();
        }

        public static StringFilterInput Equal(string value)
        {
            return new StringFilterInput(equal: value);
        }

        public static StringFilterInput Included(IEnumerable<string> values)
        {
            return new StringFilterInput(included: values);
        }

        public static StringFilterInput Likee(string value)
        {
            return new StringFilterInput(like: value);
        }

        public static StringFilterInput NotEqual(string value)
        {
            return new StringFilterInput(notEqual: value);
        }

        public static StringFilterInput NotIncluded(IEnumerable<string> values)
        {
            return new StringFilterInput(notIncluded: values);
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

            if (Like != null)
            {
                filters.Add($"like: \"{Like}\"");
            }

            if (Ne != null)
            {
                filters.Add($"ne: \"{Ne}\"");
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
