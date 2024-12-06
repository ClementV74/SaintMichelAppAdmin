using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.Services
{
    public class DAO_SaintMichelAPI
    {
        private readonly HttpClient _httpClient;

        public DAO_SaintMichelAPI()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://saintmichel.alwaysdata.net/") 
            };
        }

        public async Task<List<Event>> GetEventsAsync()
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

        public async Task<List<Offre>> GetOffresAsync()
        {
            try
            {
                var endpoint = "GetAllOffrePro";
                var response = await _httpClient.GetAsync(endpoint);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // Read the JSON content as a string
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a list of User objects
                var offres = JsonConvert.DeserializeObject<List<Offre>>(jsonResponse);

                return offres;
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
