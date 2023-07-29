namespace Jikan.WebApi.Entities
{
    public interface IGetSeriesByDescriptionInteractor
    {
        Task<JikanResponse> GetSeriesByDescription(string description, int page);
    }
}
