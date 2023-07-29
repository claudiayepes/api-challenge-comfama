namespace Jikan.WebApi.Entities
{
    public interface IJikanService
    {
        Task<string> GetSeriesByDescription(string description, int page);
    }
}
