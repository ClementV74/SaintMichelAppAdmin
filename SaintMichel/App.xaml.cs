namespace SaintMichel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockItemStore>();
            //DependencyService.Register<API_Event>();
            //DependencyService.Register<API_Offres>();
            DependencyService.Register<OffreAPI>();
            DependencyService.Register<EventAPI>();
            UserAppTheme = AppTheme.Dark;

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}