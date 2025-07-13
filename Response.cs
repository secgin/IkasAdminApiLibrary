using Newtonsoft.Json.Linq;

namespace IkasAdminApiLibrary
{
    internal class Response
    {
        public List<Error> Errors { get; set; } = [];

        public bool IsSuccess() => Errors.Count == 0;

        public string GetCode() => Errors.Count > 0 ? Errors[0]?.Extensions?.Code ?? string.Empty : string.Empty;

        public string GetMessage()
        {
            if (Errors.Count == 0)
                return string.Empty;

            Error error = Errors[0];

            string errorMessage = error.Message ?? string.Empty;

            if (error.Extensions != null && error.Extensions.ValidationErrors != null)
            {
                string validationErrorMessage = "";

                foreach (var validationError in error.Extensions.ValidationErrors)
                {
                    validationErrorMessage += "(" + validationError.Property;

                    if (validationError.Constraints != null)
                    {
                        foreach (var constraint in validationError.Constraints)
                            validationErrorMessage += " - " + constraint.Key + ":" + constraint.Value;                        
                    }

                    validationErrorMessage += ") ";
                }

                if (!string.IsNullOrWhiteSpace(validationErrorMessage))
                    errorMessage += " " + validationErrorMessage;
            }
            return errorMessage;
        }

        public bool IsLoginRequired() => GetCode() == "LOGIN_REQUIRED";
    }

    internal class Error
    {
        public string? Message { get; set; }

        public IEnumerable<string>? Path { get; set; }

        public Extensions? Extensions { get; set; }
    }

    internal class Extensions
    {
        public string Code { get; set; }

        public string ServiceName { get; set; }

        public List<ValidationError>? ValidationErrors { get; set; }

        public Extensions()
        {
            Code = string.Empty;
            ServiceName = string.Empty;
        }
    }

    internal class ValidationError
    {
        public string? Property { get; set; }

        public JObject? Constraints { get; set; }
    }
}
