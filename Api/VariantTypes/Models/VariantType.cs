using System.Globalization;
using System.Xml.Linq;

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
            return Normalize(a) == Normalize(b);
        }

        public static string Normalize(string? input)
        {
            if (input == null) return string.Empty;

            return input
                .ToLowerInvariant()
                .Replace("ı", "i")
                .Replace("İ", "i")
                .Replace("I", "i")
                .Replace("ş", "s")
                .Replace("ç", "c")
                .Replace("ğ", "g")
                .Replace("ü", "u")
                .Replace("ö", "o");
        }
    }
}
