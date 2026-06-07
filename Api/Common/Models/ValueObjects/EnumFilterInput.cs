namespace IkasAdminApiLibrary.Api.Common.Models.ValueObjects
{
    public class EnumFilterInput
    {
        public string? Eq { get; }

        public IReadOnlyList<string>? In { get; }

        public string? Ne { get; }

        public IReadOnlyList<string>? Nin { get; }

        private EnumFilterInput(
            string? equal = null,
            IEnumerable<string>? included = null,
            string? notEqual = null,
            IEnumerable<string>? notIncluded = null)
        {
            Eq = equal;
            In = included?.ToList().AsReadOnly();
            Ne = notEqual;
            Nin = notIncluded?.ToList().AsReadOnly();
        }

        public static EnumFilterInput Equal(string value)
        {
            return new EnumFilterInput(equal: value);
        }

        public static EnumFilterInput Included(IEnumerable<string> values)
        {
            return new EnumFilterInput(included: values);
        }

        public static EnumFilterInput NotEqual(string value)
        {
            return new EnumFilterInput(notEqual: value);
        }

        public static EnumFilterInput NotIncluded(IEnumerable<string> values)
        {
            return new EnumFilterInput(notIncluded: values);
        }
    }
}
