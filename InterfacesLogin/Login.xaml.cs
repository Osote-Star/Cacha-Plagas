namespace CachaPlagas.InterfacesLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		var RecuperarContraseña = new RecuperarContraseña();

		await Navigation.PushAsync(RecuperarContraseña);
    }
}