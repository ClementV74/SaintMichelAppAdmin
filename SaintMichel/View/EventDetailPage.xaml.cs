namespace SaintMichel.View;

public partial class EventDetailPage : ContentPage
{
	public EventDetailPage()
	{
		InitializeComponent();
        BindingContext = new EventDetailPageViewModel();
    }
}