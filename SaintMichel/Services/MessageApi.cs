namespace SaintMichel.Services
{
    public class MessageApi : GenericApiService<Message>
    {
        public MessageApi() : base("https://saintmichel.alwaysdata.net") { }

        // Obtenir tous les messages d'un ticket
        public async Task<IEnumerable<Message>> GetTicketMessagesAsync(int ticketId)
        {
            return await GetItemsAsync();
        }

        // Envoyer un nouveau message
        public async Task<bool> SendMessageAsync(Message message)
        {
            var url = GetUrl("AddMessage");
            return await AddItemAsync(message);
        }
    }
}