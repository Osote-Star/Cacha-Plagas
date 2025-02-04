namespace CachaPlagas.InterfacesLogin;

public partial class RecuperarContraseña : ContentPage
{
	public RecuperarContraseña()
	{
		InitializeComponent();
	}
    private  void OnRecoverPasswordClicked(object sender, EventArgs e)
    {
        // Aquí iría la lógica para recuperar la contraseña
         DisplayAlert("Éxito", "Se ha enviado un correo de recuperación", "OK");
    }
}