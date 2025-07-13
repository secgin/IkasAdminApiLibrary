namespace IkasAdminApiLibrary.Api.Common.Models
{
    public class Pagination<T>
    {
        public int Count { get; set; }

        public List<T> Data { get; set; }

        public bool HasNext { get; set; }

        public int Limit { get; set; }

        public int Page { get; set; }

        public Pagination()
        {
            Count = 0;
            Data = [];
            HasNext = false;
            Limit = 0;
            Page = 0;
        }
    }
}
