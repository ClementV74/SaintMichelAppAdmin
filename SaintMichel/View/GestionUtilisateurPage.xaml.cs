using System.Globalization;

namespace SaintMichel.View;

public partial class GestionUtilisateurPage : ContentPage
{
	public GestionUtilisateurPage()
	{
		InitializeComponent();

        BindingContext = new GestionUtilisateurPageViewModel();

    }
    public class InitialsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string fullName && !string.IsNullOrEmpty(fullName))
            {
                var parts = fullName.Split(' ');
                if (parts.Length >= 2)
                {
                    return $"{parts[0][0]}{parts[1][0]}".ToUpper();
                }
                return fullName[0].ToString().ToUpper();
            }
            return "?";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}