using System.Text.Json;

namespace FullBookInfoViaOpenLibrary.Services
{
    public static class HttpService<T> where T : new()
    {
        public static async Task<T> Get(string url)
        {
            T? data = new();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        data = JsonSerializer.Deserialize<T>(responseData);
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error: {ex.Message}");
                }
            }
            return data;
        }
    }
}
