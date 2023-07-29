using Jikan.WebApi.Entities;

namespace Jikan.WebApi.Gateways
{
    public class JikanService : IJikanService
    {
        readonly HttpClient HttpClient;

        public JikanService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<string>  GetSeriesByDescription(string description, int page)
        {

            string jsonResponse = string.Empty;
            string apiUrl = $"https://api.jikan.moe/v4/anime?q={description}&page={page}&sfw";

            // Instanciar HttpClient
            using (HttpClient)
            {
                // Realizar solicitud HTTP GET
                HttpResponseMessage response = await HttpClient.GetAsync(apiUrl);

                // Verificar si la solicitud fue exitosa (código de estado 200)
                if (response.IsSuccessStatusCode)
                {
                    // Leer el contenido de la respuesta como una cadena JSON
                    jsonResponse = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Error en la solicitud. Código de estado: {response.StatusCode}");
                }
            }

            return jsonResponse;

        }
    }
}
