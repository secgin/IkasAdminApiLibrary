using IkasAdminApiLibrary.Abstracts;

namespace IkasAdminApiLibrary
{
    internal class Result<T> : IResult<T>
    {
        private readonly bool success;

        private readonly string? code;

        private readonly string? message;

        public T Data { get; }

        private Result(bool success, string? code, string? message)
        {
            this.success = success;
            this.code = code;
            this.message = message;
            Data = default!;
        }

        private Result(bool success, string? code, string? message, T data) : this(success, code, message)
        {
            Data = data;
        }

        public static IResult<T> Success(T data, string? code = null, string? message = null)
        {
            return new Result<T>(true, code, message, data);
        }

        public static IResult<T> Fail(string? code = null, string? message = null)
        {
            return new Result<T>(false, code, message);
        }

        public static IResult<T> FromResult<S>(IResult<S> result, T data)
        {
            if (result.IsSuccess())
                return (IResult<T>)result;

            return Result<T>.Success(data, result.GetCode(), result.GetMessage());
        }

        public string GetCode() => code ?? string.Empty;

        public string GetMessage() => message ?? string.Empty;

        public bool IsSuccess() => success;

        public bool IsFail() => !success;
    }
}
