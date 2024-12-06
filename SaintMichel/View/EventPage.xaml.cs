namespace SaintMichel.View;

public partial class EventPage : ContentPage
{
	public EventPage()
	{
		InitializeComponent();
        BindingContext = new EventPageViewModel();
    }
}