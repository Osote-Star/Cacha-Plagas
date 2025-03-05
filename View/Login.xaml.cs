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
        var RecuperarContraseña = new RecuperarContraseña();

        await Navigation.PushAsync(RecuperarContraseña);
    }
}