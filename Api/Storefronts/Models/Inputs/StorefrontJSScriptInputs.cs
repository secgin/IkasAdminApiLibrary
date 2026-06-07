namespace IkasAdminApiLibrary.Api.Storefronts.Models.Inputs
{
    public class CreateStorefrontJSScriptInput
    {
        public string ContentType { get; set; } = "SCRIPT";

        public string? FileName { get; set; }

        public bool IsHighPriority { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ScriptContent { get; set; } = string.Empty;

        public string StorefrontId { get; set; } = string.Empty;
    }

    public class UpdateStorefrontJSScriptInput : CreateStorefrontJSScriptInput
    {
        public string Id { get; set; } = string.Empty;
    }
}
