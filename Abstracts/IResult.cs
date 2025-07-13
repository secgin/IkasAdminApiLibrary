namespace IkasAdminApiLibrary.Abstracts
{
    public interface IResult<T>
    {
        public T Data { get; }

        public bool IsSuccess();

        public bool IsFail();

        public string GetMessage();

        public string GetCode();
    }
}
