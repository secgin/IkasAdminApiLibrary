namespace IkasAdminApiLibrary.Api.Common.Models.ValueObjects
{
    public class DateFilterInput
    {
        public string? Eq { get; }

        public IReadOnlyList<string>? In { get; }

        public string? Like { get; }

        public string? Ne { get; }

        public IReadOnlyList<string>? Nin { get; }

        private DateFilterInput(
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

        public static DateFilterInput Equal(string value)
        {
            return new DateFilterInput(equal: value);
        }

        public static DateFilterInput Included(IEnumerable<string> values)
        {
            return new DateFilterInput(included: values);
        }

        public static DateFilterInput Likee(string value)
        {
            return new DateFilterInput(like: value);
        }

        public static DateFilterInput NotEqual(string value)
        {
            return new DateFilterInput(notEqual: value);
        }

        public static DateFilterInput NotIncluded(IEnumerable<string> values)
        {
            return new DateFilterInput(notIncluded: values);
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
