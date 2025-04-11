namespace SaintMichel.View;

public partial class TicketPage : ContentPage
{
    public TicketPage()
    {
        InitializeComponent();
        BindingContext = new TicketPageViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (this.BindingContext is TicketPageViewModel itemViewModel)
        {

            itemViewModel.OnAppearing();
        }
    }
}