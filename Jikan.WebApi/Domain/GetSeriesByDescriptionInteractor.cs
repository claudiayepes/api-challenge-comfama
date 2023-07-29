using Jikan.WebApi.Entities;
using System.Text.Json;

namespace Jikan.WebApi.Domain
{
    public class GetSeriesByDescriptionInteractor : IGetSeriesByDescriptionInteractor
    {
        readonly IJikanService JikanService;

        public GetSeriesByDescriptionInteractor(IJikanService jikanService)
        {
            JikanService = jikanService;
        }

        public async Task<JikanResponse> GetSeriesByDescription(string description, int page)
        {

            // Consultar el api de Jikan
            string jsonResponse = await JikanService.GetSeriesByDescription(description, page);

            // Deserializar respuesta
            JikanResponse response = JsonSerializer.Deserialize<JikanResponse>(jsonResponse);

            // Hacer los cálculos
            foreach (var item in response.data)
            {
                if (item.score >= 1 & item.score <= 4)
                {
                    item.message = "I do not recommend it";
                }
                if (item.score >= 5 & item.score <= 7)
                {
                    item.message = "You may have fun";
                }
                if (item.score > 7)
                {
                    item.message = "Great, this is one of the best anime";
                }
           }

            return response;
        }
    }
}
