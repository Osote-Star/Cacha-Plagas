using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class CambiarContrasena : ContentPage
{
	public CambiarContrasena(CambiarContrasenaVM viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;	
    }
}