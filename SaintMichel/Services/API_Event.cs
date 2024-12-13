using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
namespace SaintMichel.Services
{
    public class API_Event: IitemStore<Event>
    {
        private readonly HttpClient _httpClient;

        public API_Event()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://saintmichel.alwaysdata.net/")
            };

        }

        public async Task<bool> AddItemAsync(Event Event)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Event Event)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await Task.FromResult(true);
        }

        public async Task<Event> GetItemAsync(string id)
        {
            Event @event = new Event();
            return await Task.FromResult(@event);
        }

        public async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                var endpoint = "GetAllEvent";
                var response = await _httpClient.GetAsync(endpoint);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // Read the JSON content as a string
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a list of User objects
                var events = JsonConvert.DeserializeObject<List<Event>>(jsonResponse);

                return events;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw; // Optionally rethrow the exception for handling at a higher level
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }


    }
}
