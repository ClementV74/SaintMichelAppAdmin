namespace SaintMichel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //register to the root
            Routing.RegisterRoute(nameof(OffreDetailPage), typeof(OffreDetailPage));
            Routing.RegisterRoute(nameof(EventDetailPage), typeof(EventDetailPage));
            Routing.RegisterRoute(nameof(ItemPage), typeof(ItemPage));
            Routing.RegisterRoute(nameof(FoodPage), typeof(FoodPage));
            Routing.RegisterRoute(nameof(ShopPage), typeof(ShopPage));
            Routing.RegisterRoute(nameof(GestionUtilisateurPage), typeof(GestionUtilisateurPage));
            Routing.RegisterRoute(nameof(SupervisionPage), typeof(SupervisionPage));
            Routing.RegisterRoute(nameof(TicketPage), typeof(TicketPage));
        }
    }
}
