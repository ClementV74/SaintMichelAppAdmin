namespace SaintMichel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<TicketApi>();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}