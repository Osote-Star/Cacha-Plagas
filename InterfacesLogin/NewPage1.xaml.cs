namespace CachaPlagas.InterfacesLogin;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private void OnCrearCuentaClicked(object sender, EventArgs e)
    {

        DisplayAlert("Registro", "Cuenta creada exitosamente", "OK");
    }
}