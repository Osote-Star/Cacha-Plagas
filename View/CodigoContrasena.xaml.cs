using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class CodigoContrasena : ContentPage
{
	public CodigoContrasena()
	{
		InitializeComponent();
        BindingContext = new CodigoContrasenaVM(Navigation);
    }
}