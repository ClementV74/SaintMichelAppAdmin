﻿namespace SaintMichel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //DependencyService.Register<API_Event>();
            DependencyService.Register<UserAPI>();
            DependencyService.Register<OffreAPI>();
            DependencyService.Register<EventAPI>();
            UserAppTheme = AppTheme.Dark;
            DependencyService.Register<TicketApi>();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}