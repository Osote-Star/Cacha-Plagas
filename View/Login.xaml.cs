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
        var RecuperarContrase�a = new RecuperarContrase�a();

        await Navigation.PushAsync(RecuperarContrase�a);
    }
}