using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class CambiarContrasena : ContentPage
{
	public CambiarContrasena()
	{
		InitializeComponent();
		BindingContext = new CambiarContrasenaVM(Navigation);	
    }
}