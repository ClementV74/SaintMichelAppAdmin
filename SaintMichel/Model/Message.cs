namespace SaintMichel.Model
{
    public class Message
    {
        public int id_message { get; set; }
        public int ticket_id { get; set; }
        public string content { get; set; }
        public DateTime timestamp { get; set; }
        public bool is_support { get; set; } // true si envoyé par le support, false si par l'utilisateur
        public string sender_name { get; set; } // Nom de l'expéditeur

        // Propriété calculée pour déterminer l'alignement du message dans l'UI
        public bool IsFromCurrentUser => is_support; // Pour l'application de support
    }
}