namespace CachaPlagas.InterfacesLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		var RecuperarContrase�a = new RecuperarContrase�a();

		await Navigation.PushAsync(RecuperarContrase�a);
    }
}