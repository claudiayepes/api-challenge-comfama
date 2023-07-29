namespace Jikan.WebApi.Entities
{
    public class JikanResponse
    {
        public Pagination pagination { get; set; }
        public List<Data> data { get; set; }
    }
}
