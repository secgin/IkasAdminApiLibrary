namespace IkasAdminApiLibrary.Api.Common.Models.ValueObjects
{
    public class DateFilterInput
    {
        public string? Eq { get; }

        public IReadOnlyList<string>? In { get; }

        public string? Like { get; }

        public string? Ne { get; }

        public IReadOnlyList<string>? Nin { get; }

        public long? Gt { get; }

        public long? Gte { get; }

        public long? Lt { get; }

        public long? Lte { get; }

        private DateFilterInput(
            string? equal = null,
            IEnumerable<string>? included = null,
            string? like = null,
            string? notEqual = null,
            IEnumerable<string>? notIncluded = null,
            long? greaterThan = null,
            long? greaterThanOrEqual = null,
            long? lessThan = null,
            long? lessThanOrEqual = null)
        {
            Eq = equal;
            In = included?.ToList().AsReadOnly();
            Like = like;
            Ne = notEqual;
            Nin = notIncluded?.ToList().AsReadOnly();
            Gt = greaterThan;
            Gte = greaterThanOrEqual;
            Lt = lessThan;
            Lte = lessThanOrEqual;
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

        public static DateFilterInput GreaterThan(long value)
        {
            return new DateFilterInput(greaterThan: value);
        }

        public static DateFilterInput GreaterThanOrEqual(long value)
        {
            return new DateFilterInput(greaterThanOrEqual: value);
        }

        public static DateFilterInput LessThan(long value)
        {
            return new DateFilterInput(lessThan: value);
        }

        public static DateFilterInput LessThanOrEqual(long value)
        {
            return new DateFilterInput(lessThanOrEqual: value);
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

            if (Gt != null)
                filters.Add($"gt: {Gt}");

            if (Gte != null)
                filters.Add($"gte: {Gte}");

            if (Lt != null)
                filters.Add($"lt: {Lt}");

            if (Lte != null)
                filters.Add($"lte: {Lte}");

            return $"{{ {string.Join(", ", filters)} }}";
        }
    }
}
