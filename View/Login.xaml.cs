using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
        BindingContext = new LoginVM(Navigation);

    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var RecuperarContraseņa = new RecuperarContraseņa();

        await Navigation.PushAsync(RecuperarContraseņa);
    }
}
