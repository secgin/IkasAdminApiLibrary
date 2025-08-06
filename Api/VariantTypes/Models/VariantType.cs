using System.Globalization;

namespace IkasAdminApiLibrary.Api.VariantTypes.Models
{
    public class VariantType
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public VariantSelectionTypeEnum SelectionType { get; set; }

        public List<VariantValue> Values { get; set; }

        public VariantType()
        {
            Id = string.Empty;
            Name = string.Empty;
            Values = [];
        }

        public bool HasValueByName(string name)
        {
            return Values.Any(x => EqualsTurkishIgnoreCase(x.Name, name));
        }

        public VariantValue? GetValueByName(string name)
        {
            return Values.FirstOrDefault(x => EqualsTurkishIgnoreCase(x.Name, name));
        }

        public static bool EqualsTurkishIgnoreCase(string a, string b)
        {
            a = a.ToLower(new CultureInfo("tr-TR"));
            b = b.ToLower(new CultureInfo("tr-TR"));

            return a.Equals(b, StringComparison.CurrentCulture);
        }
    }
}
