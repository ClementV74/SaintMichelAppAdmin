using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.Services
{
    public class API_Offres : IitemStore<Offre>
    {
        private readonly HttpClient _httpClient;
        public API_Offres() { 
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://saintmichel.alwaysdata.net/")
            };
        }

        public async Task<bool> AddItemAsync(Offre Offre)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Offre Offre)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await Task.FromResult(true);
        }


        public async Task<Offre> GetItemAsync(string id)
        {
            Offre offre = new Offre();
            return await Task.FromResult(offre);
        }

        public async Task<IEnumerable<Offre>> GetItemsAsync(bool test)
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
