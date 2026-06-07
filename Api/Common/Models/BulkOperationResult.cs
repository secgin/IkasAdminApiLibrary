namespace IkasAdminApiLibrary.Api.Common.Models
{
    public class BulkOperationResult<TErrorData>
    {
        public List<BulkOperationError<TErrorData>> Errors { get; set; } = [];
    }

    public class BulkOperationError<TErrorData>
    {
        public string? ErrorCode { get; set; }

        public int? InputArrayIndex { get; set; }

        public TErrorData? InputData { get; set; }
    }
}
