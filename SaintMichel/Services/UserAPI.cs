using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.Services
{
    public class UserAPI : GenericApiService<User>
    {
        public UserAPI() : base("https://saintmichel.alwaysdata.net/getAllUsers")
        {
        }

        /// <summary>
        /// Adds a new shop.
        /// </summary>
        /// <param name="shop">The shop to add.</param>
        /// <returns>True if the shop was successfully added; otherwise, false.</returns>
        public async Task<bool> AddUserAsync(User shop)
        {
            return await AddItemAsync(shop);
        }

        /// <summary>
        /// Updates an existing shop.
        /// </summary>
        /// <param name="shop">The shop to update.</param>
        /// <returns>True if the shop was successfully updated; otherwise, false.</returns>
        public async Task<bool> UpdateUserAsync(User shop)
        {
            return await UpdateItemAsync(shop.iduser.ToString(), shop);
        }

        /// <summary>
        /// Deletes a shop by ID.
        /// </summary>
        /// <param name="idshop">The ID of the shop to delete.</param>
        /// <returns>True if the shop was successfully deleted; otherwise, false.</returns>
        public async Task<bool> DeleteUserAsync(string idshop)
        {
            return await DeleteItemAsync(idshop);
        }

        /// <summary>
        /// Retrieves a shop by ID.
        /// </summary>
        /// <param name="idshop">The ID of the shop to retrieve.</param>
        /// <returns>The shop if found; otherwise, null.</returns>
        public async Task<User> GetUserAsync(string idshop)
        {
            return await GetItemAsync(idshop);
        }

        /// <summary>
        /// Retrieves all shops.
        /// </summary>
        /// <returns>A list of all shops.</returns>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var toto = await GetItemsAsync();
            return toto;
        }

        /// <summary>
        /// Searches for shops based on a filter.
        /// </summary>
        /// <param name="filter">The search filter.</param>
        /// <returns>A list of matching shops.</returns>
        public async Task<IEnumerable<User>> SearchUsersAsync(string filter)
        {
            var allUsers = await GetItemsAsync();
            return allUsers.Where(shop => shop.pseudo.Contains(filter, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Checks if a shop exists by ID.
        /// </summary>
        /// <param name="idshop">The ID of the shop to check.</param>
        /// <returns>True if the shop exists; otherwise, false.</returns>
        public async Task<bool> UserExistsAsync(string idshop)
        {
            var shop = await GetItemAsync(idshop);
            return shop != null;
        }
    }
}
