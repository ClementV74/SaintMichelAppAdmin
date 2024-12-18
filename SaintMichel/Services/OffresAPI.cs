using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.Services
{
    public class OffreAPI : GenericApiService<Offre>
    {
        public OffreAPI() : base("https://saintmichel.alwaysdata.net/GetAllOffrePro")
        {
        }

        /// <summary>
        /// Adds a new shop.
        /// </summary>
        /// <param name="shop">The shop to add.</param>
        /// <returns>True if the shop was successfully added; otherwise, false.</returns>
        public async Task<bool> AddOffreAsync(Offre shop)
        {
            return await AddItemAsync(shop);
        }

        /// <summary>
        /// Updates an existing shop.
        /// </summary>
        /// <param name="shop">The shop to update.</param>
        /// <returns>True if the shop was successfully updated; otherwise, false.</returns>
        public async Task<bool> UpdateOffreAsync(Offre shop)
        {
            return await UpdateItemAsync(shop.IDInterim.ToString(), shop);
        }

        /// <summary>
        /// Deletes a shop by ID.
        /// </summary>
        /// <param name="idshop">The ID of the shop to delete.</param>
        /// <returns>True if the shop was successfully deleted; otherwise, false.</returns>
        public async Task<bool> DeleteOffreAsync(string idshop)
        {
            return await DeleteItemAsync(idshop);
        }

        /// <summary>
        /// Retrieves a shop by ID.
        /// </summary>
        /// <param name="idshop">The ID of the shop to retrieve.</param>
        /// <returns>The shop if found; otherwise, null.</returns>
        public async Task<Offre> GetOffreAsync(string idshop)
        {
            return await GetItemAsync(idshop);
        }

        /// <summary>
        /// Retrieves all shops.
        /// </summary>
        /// <returns>A list of all shops.</returns>
        public async Task<IEnumerable<Offre>> GetAllOffresAsync()
        {
            var toto = await GetItemsAsync();
            return toto;
        }

        /// <summary>
        /// Searches for shops based on a filter.
        /// </summary>
        /// <param name="filter">The search filter.</param>
        /// <returns>A list of matching shops.</returns>
        public async Task<IEnumerable<Offre>> SearchOffresAsync(string filter)
        {
            var allOffres = await GetItemsAsync();
            return allOffres.Where(shop => shop.NameEntreprise.Contains(filter, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Checks if a shop exists by ID.
        /// </summary>
        /// <param name="idshop">The ID of the shop to check.</param>
        /// <returns>True if the shop exists; otherwise, false.</returns>
        public async Task<bool> OffreExistsAsync(string idshop)
        {
            var shop = await GetItemAsync(idshop);
            return shop != null;
        }
    }
}
