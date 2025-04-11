namespace SaintMichel.Model
{
    public class Message
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public bool IsFromCurrentUser { get; set; }
    }
}