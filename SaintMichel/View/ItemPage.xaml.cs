namespace SaintMichel.View;

public partial class ItemPage : ContentPage
{
    public ItemPage()
    {

        InitializeComponent();
      
        this.BindingContext = new ItemViewModel();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (this.BindingContext is ItemViewModel itemViewModel)
        {

            itemViewModel.OnAppearing();
        }
    }
}