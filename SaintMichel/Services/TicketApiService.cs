using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaintMichel.Services
{
    public class TicketApi : GenericApiService<Ticket>
    {
        public TicketApi() : base("https://saintmichel.alwaysdata.net") { }

        // Obtenir tous les tickets
        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await GetItemsAsync();
        }

        // Obtenir un ticket par ID
        public async Task<Ticket> GetTicketAsync(string idticket)
        {
            var url = GetUrl($"GetTicket/{idticket}");
            return await GetItemAsync(url);
        }

        // Mettre à jour un ticket
        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            var url = GetUrl($"UpdateTicket/{ticket.id_ticket}");
            return await UpdateItemAsync(url, ticket);
        }

        // Ajouter un ticket
        public async Task<bool> AddTicketAsync(Ticket ticket)
        {
            return await AddItemAsync(ticket);
        }

        // Supprimer un ticket
        public async Task<bool> DeleteTicketAsync(string idticket)
        {
            var url = GetUrl($"DeleteTicket/{idticket}");
            return await DeleteItemAsync(url);
        }
    }
}
