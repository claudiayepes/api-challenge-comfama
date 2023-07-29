using Jikan.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Jikan.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Jikan : ControllerBase
    {
        readonly IGetSeriesByDescriptionInteractor Interactor;

        public Jikan(IGetSeriesByDescriptionInteractor interactor)
        {
            Interactor = interactor;
        }

        [HttpGet(Name = "GetAnime")]
        public async Task<JikanResponse> Get(string q, int page = 1)
        {
            return await Interactor.GetSeriesByDescription(q, page);
        }
    }
}
