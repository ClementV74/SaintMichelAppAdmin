namespace SaintMichel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //register to the root
           
            Routing.RegisterRoute(nameof(ItemPage), typeof(ItemPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(FoodPage), typeof(FoodPage));
            Routing.RegisterRoute(nameof(ShopPage), typeof(ShopPage));
            Routing.RegisterRoute(nameof(GestionUtilisateurPage), typeof(GestionUtilisateurPage));
            Routing.RegisterRoute(nameof(SupervisionPage), typeof(SupervisionPage));
            Routing.RegisterRoute(nameof(TicketPage), typeof(TicketPage));
        }
    }
}
