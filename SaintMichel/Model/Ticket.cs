namespace SaintMichel.Model
{
    public class Ticket
    {
        public int id_ticket { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public int user_iduser { get; set; }

        // Propriété calculée pour le texte du statut
        public string StatusText
        {
            get
            {
                return status == 1 ? "En cours de traitement" : "Fermé";
            }
        }

        // Propriété calculée pour la couleur du statut
        public string StatusColor
        {
            get
            {
                return status == 1 ? "Green" : "Red";
            }
        }
    }
}