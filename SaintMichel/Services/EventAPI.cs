using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.Services
{
    public class EventAPI: GenericApiService<Event>
    {
        public EventAPI() : base("https://saintmichel.alwaysdata.net/GetAllEvent")
        {
        }

        /// <summary>
        /// Adds a new shop.
        /// </summary>
        /// <param name="shop">The shop to add.</param>
        /// <returns>True if the shop was successfully added; otherwise, false.</returns>
        public async Task<bool> AddEventAsync(Event shop)
        {
            return await AddItemAsync(shop);
        }

        /// <summary>
        /// Updates an existing shop.
        /// </summary>
        /// <param name="shop">The shop to update.</param>
        /// <returns>True if the shop was successfully updated; otherwise, false.</returns>
        public async Task<bool> UpdateEventAsync(Event shop)
        {
            return await UpdateItemAsync(shop.IDevent.ToString(), shop);
        }

        /// <summary>
        /// Deletes a shop by ID.
        /// </summary>
        /// <param name="idshop">The ID of the shop to delete.</param>
        /// <returns>True if the shop was successfully deleted; otherwise, false.</returns>
        public async Task<bool> DeleteEventAsync(string idshop)
        {
            return await DeleteItemAsync(idshop);
        }

        /// <summary>
        /// Retrieves a shop by ID.
        /// </summary>
        /// <param name="idshop">The ID of the shop to retrieve.</param>
        /// <returns>The shop if found; otherwise, null.</returns>
        public async Task<Event> GetEventAsync(string idshop)
        {
            return await GetItemAsync(idshop);
        }

        /// <summary>
        /// Retrieves all shops.
        /// </summary>
        /// <returns>A list of all shops.</returns>
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            var toto = await GetItemsAsync();
            return toto;
        }

        /// <summary>
        /// Searches for shops based on a filter.
        /// </summary>
        /// <param name="filter">The search filter.</param>
        /// <returns>A list of matching shops.</returns>
        public async Task<IEnumerable<Event>> SearchEventsAsync(string filter)
        {
            var allEvents = await GetItemsAsync();
            return allEvents.Where(shop => shop.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Checks if a shop exists by ID.
        /// </summary>
        /// <param name="idshop">The ID of the shop to check.</param>
        /// <returns>True if the shop exists; otherwise, false.</returns>
        public async Task<bool> EventExistsAsync(string idshop)
        {
            var shop = await GetItemAsync(idshop);
            return shop != null;
        }
    }
}
